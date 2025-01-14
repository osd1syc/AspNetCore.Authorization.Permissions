﻿namespace MadEyeMatt.AspNetCore.Identity.Permissions
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using JetBrains.Annotations;
	using Microsoft.AspNetCore.Identity;

	/// <summary>
	///     Provides the default validation of permissions.
	/// </summary>
	/// <typeparam name="TPermission">The type encapsulating a permission.</typeparam>
	[PublicAPI]
	public class PermissionValidator<TPermission> : IPermissionValidator<TPermission>
		where TPermission : class
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="PermissionValidator{TPermission}" /> type.
		/// </summary>
		/// <param name="errors">The <see cref="PermissionIdentityErrorDescriber" /> used to provider error messages.</param>
		public PermissionValidator(PermissionIdentityErrorDescriber errors = null)
		{
			this.Describer = errors ?? new PermissionIdentityErrorDescriber();
		}

		private PermissionIdentityErrorDescriber Describer { get; }

		/// <summary>
		///     Validates a permission as an asynchronous operation.
		/// </summary>
		/// <param name="manager">The <see cref="PermissionManager{TPermission}" /> managing the permission store.</param>
		/// <param name="permission">The permission to validate.</param>
		/// <returns>
		///     A <see cref="Task{TResult}" /> that represents the <see cref="IdentityResult" /> of the asynchronous
		///     validation.
		/// </returns>
		public async Task<IdentityResult> ValidateAsync(PermissionManager<TPermission> manager, TPermission permission)
		{
			if(manager == null)
			{
				throw new ArgumentNullException(nameof(manager));
			}

			if(permission == null)
			{
				throw new ArgumentNullException(nameof(permission));
			}

			List<IdentityError> errors = new List<IdentityError>();
			await this.ValidatePermissionName(manager, permission, errors);

			return errors.Count > 0
				? IdentityResult.Failed(errors.ToArray())
				: IdentityResult.Success;
		}

		private async Task ValidatePermissionName(PermissionManager<TPermission> manager, TPermission permission, ICollection<IdentityError> errors)
		{
			string permissionName = await manager.GetPermissionNameAsync(permission);
			if(string.IsNullOrWhiteSpace(permissionName))
			{
				errors.Add(this.Describer.InvalidPermissionName(permissionName));
			}
			else
			{
				TPermission owner = await manager.FindByNameAsync(permissionName);
				if(owner != null && !string.Equals(await manager.GetPermissionIdAsync(owner), await manager.GetPermissionIdAsync(permission)))
				{
					errors.Add(this.Describer.DuplicatePermissionName(permissionName));
				}
			}
		}
	}
}
