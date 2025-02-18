﻿namespace MadEyeMatt.AspNetCore.Identity.Permissions.EntityFrameworkCore.Configuration.Permissions
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using JetBrains.Annotations;
	using MadEyeMatt.AspNetCore.Identity.Permissions.EntityFrameworkCore.Properties;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

	/// <summary>
	///     An entity type configuration.
	/// </summary>
	/// <typeparam name="TTenant"></typeparam>
	[PublicAPI]
	public class TenantConfiguration<TTenant> : TenantConfiguration<TTenant, string>
		where TTenant : IdentityTenant<string>
	{
	}

	/// <summary>
	///     An entity type configuration.
	/// </summary>
	/// <typeparam name="TTenant"></typeparam>
	/// <typeparam name="TKey"></typeparam>
	[PublicAPI]
	public class TenantConfiguration<TTenant, TKey> : IEntityTypeConfiguration<TTenant>
		where TTenant : IdentityTenant<TKey>
		where TKey : IEquatable<TKey>
	{
		/// <summary>
		///     Gets or sets the table name.
		/// </summary>
		public string Table { get; init; } = "AspNetTenants";

		/// <summary>
		///     Specifies the maximum length.
		/// </summary>
		/// <remarks>The default is 256.</remarks>
		public int MaxKeyLength { get; init; } = 256;

        /// <summary>
        ///     If set, all properties on type <typeparamref name="TTenant" /> marked with a
        ///     <see cref="ProtectedPersonalDataAttribute" /> will be converted using this <see cref="ValueConverter" />.
        /// </summary>
        public ValueConverter<string, string> PersonalDataConverter { get; init; }

		/// <inheritdoc />
		public virtual void Configure(EntityTypeBuilder<TTenant> builder)
		{
			builder.ToTable(this.Table);

			builder.HasKey(x => x.Id);
			builder.HasIndex(x => x.NormalizedName).HasDatabaseName("TenantsNormalizedNameIndex").IsUnique();

			builder.Property(x => x.ConcurrencyStamp).IsConcurrencyToken();
			builder.Property(x => x.Name).HasMaxLength(this.MaxKeyLength);
			builder.Property(x => x.NormalizedName).HasMaxLength(this.MaxKeyLength);

			if(this.PersonalDataConverter is not null)
			{
				builder.ApplyProtectedPersonalDataConverter(this.PersonalDataConverter);
			}
		}
	}
}
