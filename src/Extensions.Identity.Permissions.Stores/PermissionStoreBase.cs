﻿namespace MadEyeMatt.AspNetCore.Identity.Permissions
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Threading;
	using System.Threading.Tasks;
	using JetBrains.Annotations;
	using Microsoft.AspNetCore.Identity;

	/// <summary>
	///     Initializes a new instance of a persistence store for roles.
	/// </summary>
	/// <typeparam name="TPermission">The type of the class representing a permission.</typeparam>
	/// <typeparam name="TRole">The type representing a role.</typeparam>
	/// <typeparam name="TKey">The type of the primary key for a permission.</typeparam>
	[PublicAPI]
	public abstract class PermissionStoreBase<TPermission, TRole, TKey> : IPermissionStore<TPermission>, IRolePermissionStore<TPermission>
		where TPermission : IdentityPermission<TKey>
		where TRole : IdentityRole<TKey>
		where TKey : IEquatable<TKey>
	{
		private bool disposed;

		/// <summary>
		///     Constructs a new instance of <see cref="PermissionStoreBase{TPermission,TRole,TKey}" />.
		/// </summary>
		/// <param name="describer">The <see cref="IdentityErrorDescriber" />.</param>
		protected PermissionStoreBase(IdentityErrorDescriber describer)
		{
			this.ErrorDescriber = describer ?? throw new ArgumentNullException(nameof(describer));
		}

		/// <summary>
		///     Gets or sets the <see cref="IdentityErrorDescriber" /> for any error that occurred with the current operation.
		/// </summary>
		public IdentityErrorDescriber ErrorDescriber { get; set; }

		/// <inheritdoc />
		public abstract Task<IdentityResult> CreateAsync(TPermission permission, CancellationToken cancellationToken = default);

		/// <inheritdoc />
		public abstract Task<IdentityResult> UpdateAsync(TPermission permission, CancellationToken cancellationToken = default);

		/// <inheritdoc />
		public abstract Task<IdentityResult> DeleteAsync(TPermission permission, CancellationToken cancellationToken = default);

		/// <inheritdoc />
		public abstract Task<TPermission> FindByIdAsync(string permissionId, CancellationToken cancellationToken);

		/// <inheritdoc />
		public abstract Task<TPermission> FindByNameAsync(string normalizedPermissionName, CancellationToken cancellationToken);

		/// <inheritdoc />
		public virtual Task<string> GetPermissionIdAsync(TPermission permission, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			this.ThrowIfDisposed();
			if(permission == null)
			{
				throw new ArgumentNullException(nameof(permission));
			}

			return Task.FromResult(this.ConvertIdToString(permission.Id));
		}

		/// <inheritdoc />
		public virtual Task<string> GetPermissionNameAsync(TPermission permission, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			this.ThrowIfDisposed();
			if(permission == null)
			{
				throw new ArgumentNullException(nameof(permission));
			}

			return Task.FromResult(permission.Name);
		}

		/// <inheritdoc />
		public virtual Task SetPermissionNameAsync(TPermission permission, string permissionName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			this.ThrowIfDisposed();
			if(permission == null)
			{
				throw new ArgumentNullException(nameof(permission));
			}

			permission.Name = permissionName;
			return Task.CompletedTask;
		}

		/// <inheritdoc />
		public virtual Task SetNormalizedPermissionNameAsync(TPermission permission, string normalizedPermissionName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			this.ThrowIfDisposed();
			if(permission == null)
			{
				throw new ArgumentNullException(nameof(permission));
			}

			permission.NormalizedName = normalizedPermissionName;
			return Task.CompletedTask;
		}

		/// <inheritdoc />
		public virtual Task<string> GetNormalizedPermissionNameAsync(TPermission permission, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			this.ThrowIfDisposed();
			if(permission == null)
			{
				throw new ArgumentNullException(nameof(permission));
			}

			return Task.FromResult(permission.NormalizedName);
		}

		/// <summary>
		///     Dispose the stores
		/// </summary>
		public void Dispose()
		{
			this.disposed = true;
		}

		/// <inheritdoc />
		public abstract Task AddToRoleAsync(TPermission permission, string normalizedRoleName, CancellationToken cancellationToken = default);

		/// <inheritdoc />
		public abstract Task RemoveFromRoleAsync(TPermission permission, string normalizedRoleName, CancellationToken cancellationToken);

		/// <inheritdoc />
		public abstract Task<IList<string>> GetRolesAsync(TPermission permission, CancellationToken cancellationToken);

		/// <inheritdoc />
		public abstract Task<IList<string>> GetRoleIdsAsync(TPermission permission, CancellationToken cancellationToken);

		/// <inheritdoc />
		public abstract Task<bool> IsInRoleAsync(TPermission permission, string normalizedRoleName, CancellationToken cancellationToken);

		/// <inheritdoc />
		public abstract Task<IList<TPermission>> GetPermissionsInRoleAsync(string normalizedRoleName, CancellationToken cancellationToken);

		/// <summary>
		///     Return a role with the normalized name if it exists.
		/// </summary>
		/// <param name="normalizedRoleName">The normalized role name.</param>
		/// <param name="cancellationToken">
		///     The <see cref="CancellationToken" /> used to propagate notifications that the operation
		///     should be canceled.
		/// </param>
		/// <returns>The role if it exists.</returns>
		protected abstract Task<TRole> FindRoleAsync(string normalizedRoleName, CancellationToken cancellationToken);

		/// <summary>
		///     Converts the provided <paramref name="id" /> to a strongly typed key object.
		/// </summary>
		/// <param name="id">The id to convert.</param>
		/// <returns>An instance of <typeparamref name="TKey" /> representing the provided <paramref name="id" />.</returns>
		protected virtual TKey ConvertIdFromString(string id)
		{
			if(id == null)
			{
				return default;
			}

			return (TKey)TypeDescriptor.GetConverter(typeof(TKey)).ConvertFromInvariantString(id);
		}

		/// <summary>
		///     Converts the provided <paramref name="id" /> to its string representation.
		/// </summary>
		/// <param name="id">The id to convert.</param>
		/// <returns>An <see cref="string" /> representation of the provided <paramref name="id" />.</returns>
		protected virtual string ConvertIdToString(TKey id)
		{
			return id.Equals(default) ? null : id.ToString();
		}

		/// <summary>
		///     Throws if this class has been disposed.
		/// </summary>
		protected void ThrowIfDisposed()
		{
			if(this.disposed)
			{
				throw new ObjectDisposedException(this.GetType().Name);
			}
		}
	}
}
