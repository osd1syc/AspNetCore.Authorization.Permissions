﻿namespace MadEyeMatt.AspNetCore.Identity.Permissions.EntityFrameworkCore
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using JetBrains.Annotations;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;

	/// <summary>
	///     Represents a new instance of a persistence store for the specified tenant, role and db context types.
	/// </summary>
	/// <typeparam name="TTenant">The type of the class representing a tenant.</typeparam>
	/// <typeparam name="TRole">The type representing a role.</typeparam>
	/// <typeparam name="TContext">The type of the data context class used to access the store.</typeparam>
	[PublicAPI]
	public class TenantStore<TTenant, TRole, TContext> : TenantStore<TTenant, TRole, TContext, string>
		where TTenant : IdentityTenant
		where TRole : IdentityRole
		where TContext : DbContext
	{
		/// <inheritdoc />
		public TenantStore(TContext context, IdentityErrorDescriber describer = null)
			: base(context, describer)
		{
		}
	}

	/// <summary>
	///     Represents a new instance of a persistence store for the specified tenant, role, db context and key types.
	/// </summary>
	/// <typeparam name="TTenant">The type of the class representing a tenant.</typeparam>
	/// <typeparam name="TRole">The type representing a role.</typeparam>
	/// <typeparam name="TContext">The type of the data context class used to access the store.</typeparam>
	/// <typeparam name="TKey">The type of the primary key for a role.</typeparam>
	[PublicAPI]
	public class TenantStore<TTenant, TRole, TContext, TKey> : TenantStore<TTenant, TRole, TContext, TKey, IdentityTenantRole<TKey>>
		where TTenant : IdentityTenant<TKey>
		where TRole : IdentityRole<TKey>
		where TContext : DbContext
		where TKey : IEquatable<TKey>
	{
		/// <inheritdoc />
		public TenantStore(TContext context, IdentityErrorDescriber describer = null)
			: base(context, describer)
		{
		}
	}

	/// <summary>
	///     Represents a new instance of a persistence store for the specified tenant, role, db context, key and role types.
	/// </summary>
	/// <typeparam name="TTenant">The type of the class representing a tenant.</typeparam>
	/// <typeparam name="TRole">The type representing a role.</typeparam>
	/// <typeparam name="TContext">The type of the data context class used to access the store.</typeparam>
	/// <typeparam name="TKey">The type of the primary key for a tenant.</typeparam>
	/// <typeparam name="TTenantRole">The type representing a tenant role.</typeparam>
	[PublicAPI]
	public class TenantStore<TTenant, TRole, TContext, TKey, TTenantRole> : TenantStoreBase<TTenant, TRole, TKey>,
		IQueryableTenantStore<TTenant>
		where TTenant : IdentityTenant<TKey>
		where TRole : IdentityRole<TKey>
		where TKey : IEquatable<TKey>
		where TContext : DbContext
		where TTenantRole : IdentityTenantRole<TKey>, new()
	{
		/// <inheritdoc />
		public TenantStore(TContext context, IdentityErrorDescriber describer = null)
			: base(describer)
		{
			Guard.ThrowIfNull(context);

			this.Context = context;
        }

		/// <summary>
		///     Gets the database context for this store.
		/// </summary>
		public virtual TContext Context { get; }

		private DbSet<TRole> Roles => this.Context.Set<TRole>();

		private DbSet<TTenantRole> TenantRoles => this.Context.Set<TTenantRole>();

		/// <summary>
		///     Gets or sets a flag indicating if changes should be persisted after CreateAsync, UpdateAsync and DeleteAsync are
		///     called.
		/// </summary>
		/// <value>
		///     True if changes should be automatically persisted, otherwise false.
		/// </value>
		public bool AutoSaveChanges { get; set; } = true;

		/// <inheritdoc />
		public override async Task<IdentityResult> CreateAsync(TTenant tenant, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			this.ThrowIfDisposed();
			Guard.ThrowIfNull(tenant);

            tenant.ConcurrencyStamp = Guid.NewGuid().ToString("N");
            this.Context.Add(tenant);
			await this.SaveChanges(cancellationToken);
			return IdentityResult.Success;
		}

		/// <inheritdoc />
		public override async Task<IdentityResult> UpdateAsync(TTenant tenant, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			this.ThrowIfDisposed();
			Guard.ThrowIfNull(tenant);

            this.Context.Attach(tenant);
			tenant.ConcurrencyStamp = Guid.NewGuid().ToString("N");
			this.Context.Update(tenant);
			try
			{
				await this.SaveChanges(cancellationToken);
			}
			catch(DbUpdateConcurrencyException)
			{
				return IdentityResult.Failed(this.ErrorDescriber.ConcurrencyFailure());
			}

			return IdentityResult.Success;
		}

		/// <inheritdoc />
		public override async Task<IdentityResult> DeleteAsync(TTenant tenant, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			this.ThrowIfDisposed();
			Guard.ThrowIfNull(tenant);

            this.Context.Remove(tenant);
			try
			{
				await this.SaveChanges(cancellationToken);
			}
			catch(DbUpdateConcurrencyException)
			{
				return IdentityResult.Failed(this.ErrorDescriber.ConcurrencyFailure());
			}

			return IdentityResult.Success;
		}

		/// <inheritdoc />
		public override Task<TTenant> FindByIdAsync(string tenantId, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			this.ThrowIfDisposed();

			TKey roleId = this.ConvertIdFromString(tenantId);
			return this.Tenants.FirstOrDefaultAsync(u => u.Id.Equals(roleId), cancellationToken);
		}

		/// <inheritdoc />
		public override Task<TTenant> FindByNameAsync(string normalizedTenantName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			this.ThrowIfDisposed();

			return this.Tenants.FirstOrDefaultAsync(r => r.NormalizedName == normalizedTenantName, cancellationToken);
		}

		/// <inheritdoc />
		public IQueryable<TTenant> Tenants => this.Context.Set<TTenant>();

		/// <inheritdoc />
		public override async Task AddToRoleAsync(TTenant tenant, string normalizedRoleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			this.ThrowIfDisposed();
			Guard.ThrowIfNull(tenant);
			Guard.ThrowIfNullOrWhiteSpace(normalizedRoleName);

            TRole role = await this.FindRoleAsync(normalizedRoleName, cancellationToken);
			if(role == null)
			{
				throw new InvalidOperationException($"The role '{normalizedRoleName}' was not found.");
			}

			this.TenantRoles.Add(this.CreateTenantRole(tenant, role));
		}

		/// <inheritdoc />
		public override async Task RemoveFromRoleAsync(TTenant tenant, string normalizedRoleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			this.ThrowIfDisposed();
			Guard.ThrowIfNull(tenant);
			Guard.ThrowIfNullOrWhiteSpace(normalizedRoleName);

            TRole role = await this.FindRoleAsync(normalizedRoleName, cancellationToken);
			if(role != null)
			{
				TTenantRole rolePermission = await this.FindTenantRoleAsync(tenant.Id, role.Id, cancellationToken);
				if(rolePermission != null)
				{
					this.TenantRoles.Remove(rolePermission);
				}
			}
		}

		/// <inheritdoc />
		public override async Task<IList<string>> GetRolesAsync(TTenant tenant, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			this.ThrowIfDisposed();
			Guard.ThrowIfNull(tenant);

            TKey userId = tenant.Id;
			IQueryable<string> query = from tenantRole in this.TenantRoles
									   join role in this.Roles on tenantRole.RoleId equals role.Id
									   where tenantRole.TenantId.Equals(userId)
									   select role.Name;

			return await query.ToListAsync(cancellationToken);
		}

		/// <inheritdoc />
		public override async Task<IList<string>> GetRoleIdsAsync(TTenant tenant, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			this.ThrowIfDisposed();
			Guard.ThrowIfNull(tenant);

			TKey userId = tenant.Id;
			IQueryable<TKey> query = from tenantRole in this.TenantRoles
									   join role in this.Roles on tenantRole.RoleId equals role.Id
									   where tenantRole.TenantId.Equals(userId)
									   select role.Id;

			IList<TKey> keys = await query.ToListAsync(cancellationToken);
			return keys.Select(this.ConvertIdToString).ToList();
        }

		/// <inheritdoc />
		public override async Task<bool> IsInRoleAsync(TTenant tenant, string normalizedRoleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			this.ThrowIfDisposed();
			Guard.ThrowIfNull(tenant);
			Guard.ThrowIfNullOrWhiteSpace(normalizedRoleName);

			TRole role = await this.FindRoleAsync(normalizedRoleName, cancellationToken);
			if(role != null)
			{
				TTenantRole tenantRole = await this.FindTenantRoleAsync(tenant.Id, role.Id, cancellationToken);
				return tenantRole != null;
			}

			return false;
		}

		/// <inheritdoc />
		public override async Task<IList<TTenant>> GetTenantsInRoleAsync(string normalizedRoleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			this.ThrowIfDisposed();
			Guard.ThrowIfNullOrWhiteSpace(normalizedRoleName);

			TRole role = await this.FindRoleAsync(normalizedRoleName, cancellationToken);

			if(role != null)
			{
				IQueryable<TTenant> query = from tenantRole in this.TenantRoles
											join user in this.Tenants on tenantRole.TenantId equals user.Id
											where tenantRole.RoleId.Equals(role.Id)
											select user;

				return await query.ToListAsync(cancellationToken);
			}

			return new List<TTenant>();
		}

		/// <inheritdoc />
		protected override Task<TRole> FindRoleAsync(string normalizedRoleName, CancellationToken cancellationToken)
		{
			return this.Roles.SingleOrDefaultAsync(r => r.NormalizedName == normalizedRoleName, cancellationToken);
		}

		/// <summary>
		///     Return a tenant role for the tenantId and roleId if it exists.
		/// </summary>
		/// <param name="tenantId">The tenant's id.</param>
		/// <param name="roleId">The role's id.</param>
		/// <param name="cancellationToken">
		///     The <see cref="CancellationToken" /> used to propagate notifications that the operation
		///     should be canceled.
		/// </param>
		/// <returns>The user role if it exists.</returns>
        protected virtual Task<TTenantRole> FindTenantRoleAsync(TKey tenantId, TKey roleId, CancellationToken cancellationToken)
		{
			return this.TenantRoles.FindAsync(new object[] { tenantId, roleId }, cancellationToken).AsTask();
		}

		/// <inheritdoc />
		protected override Task<TTenant> FindTenantAsync(TKey userId, CancellationToken cancellationToken)
		{
			return this.Tenants.SingleOrDefaultAsync(u => u.Id.Equals(userId), cancellationToken);
		}

		/// <summary>
		///     Called to create a new instance of a <see cref="IdentityTenantRole{TKey}" />.
		/// </summary>
		/// <param name="tenant">The associated tenant.</param>
		/// <param name="role">The associated role.</param>
		/// <returns></returns>
		protected virtual TTenantRole CreateTenantRole(TTenant tenant, TRole role)
		{
			return new TTenantRole
			{
				TenantId = tenant.Id,
				RoleId = role.Id
			};
		}

        /// <summary>Saves the current store.</summary>
        /// <param name="cancellationToken">
        ///     The <see cref="CancellationToken" /> used to propagate notifications that the operation
        ///     should be canceled.
        /// </param>
        /// <returns>The <see cref="Task" /> that represents the asynchronous operation.</returns>
        private async Task SaveChanges(CancellationToken cancellationToken)
		{
			if(this.AutoSaveChanges)
			{
				await this.Context.SaveChangesAsync(cancellationToken);
			}
		}
	}
}
