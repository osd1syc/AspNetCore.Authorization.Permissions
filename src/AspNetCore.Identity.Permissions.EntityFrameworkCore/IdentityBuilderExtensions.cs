﻿namespace MadEyeMatt.AspNetCore.Identity.Permissions.EntityFrameworkCore
{
	using System;
	using JetBrains.Annotations;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.DependencyInjection.Extensions;

	/// <summary>
	///     Extension methods for the <see cref="IdentityBuilderExtensions" /> type.
	/// </summary>
	[PublicAPI]
	public static class IdentityBuilderExtensions
	{
		/// <summary>
		///     Adds the EF Core store implementations for Identity and the permissions library.
		/// </summary>
		/// <typeparam name="TContext"></typeparam>
		/// <param name="builder"></param>
		/// <returns></returns>
		public static IdentityBuilder AddPermissionsEntityFrameworkStores<TContext>(this IdentityBuilder builder)
			where TContext : DbContext
		{
			if(builder is PermissionIdentityBuilder permissionBuilder)
			{
				builder.AddEntityFrameworkStores<TContext>();
				AddStores(permissionBuilder.Services, permissionBuilder.TenantType, permissionBuilder.UserType, permissionBuilder.RoleType, permissionBuilder.PermissionType, typeof(TContext));
				return builder;
			}

			throw new InvalidOperationException($"The builder was not of {nameof(PermissionIdentityBuilder)} type.");
		}

		private static void AddStores(IServiceCollection services, Type tenantType, Type userType, Type roleType, Type permissionType, Type contextType)
		{
			if(tenantType is not null)
			{
				Type identityTenantType = FindGenericBaseType(tenantType, typeof(IdentityTenant<>));
				if(identityTenantType == null)
				{
					throw new InvalidOperationException("The given type is not an identity tenant type.");
				}
			}

			Type identityUserType = FindGenericBaseType(userType, tenantType is null ? typeof(IdentityUser<>) : typeof(IdentityTenantUser<>));
			if(identityUserType == null)
			{
				throw new InvalidOperationException("The given type is not an identity user type.");
			}

			if(roleType == null)
			{
				throw new InvalidOperationException("The permissions extension needs a role type to work.");
			}

			Type identityPermissionType = FindGenericBaseType(permissionType, typeof(IdentityPermission<>));
			if(identityPermissionType == null)
			{
				throw new InvalidOperationException("The given type is not an identity permission type.");
			}

			Type keyType = identityPermissionType.GenericTypeArguments[0];

			Type identityRoleType = FindGenericBaseType(roleType, typeof(IdentityRole<>));
			if(identityRoleType == null)
			{
				throw new InvalidOperationException("The given type is not an identity role type.");
			}

			// Configure permission store.
			Type permissionStoreType = typeof(PermissionStore<,,,>).MakeGenericType(permissionType, roleType, contextType, keyType);
			services.TryAddScoped(typeof(IPermissionStore<>).MakeGenericType(permissionType), permissionStoreType);

			if(tenantType is not null)
			{
				// Configure tenant store.
				Type tenantsStoreType = typeof(TenantStore<,,,>).MakeGenericType(tenantType, roleType, contextType, keyType);
				services.TryAddScoped(typeof(ITenantStore<>).MakeGenericType(tenantType), tenantsStoreType);
			}
		}

		private static Type FindGenericBaseType(Type currentType, Type genericBaseType)
		{
			Type type = currentType;
			while(type != null)
			{
				Type genericType = type.IsGenericType ? type.GetGenericTypeDefinition() : null;
				if(genericType != null && genericType == genericBaseType)
				{
					return type;
				}

				type = type.BaseType;
			}

			return null;
		}
	}
}
