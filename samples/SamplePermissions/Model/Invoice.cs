﻿namespace SamplePermissions.Model
{
	using System;

	public class Invoice
	{
		public Guid Id { get; set; }

		public decimal Total { get; set; }

		public string Note { get; set; }
	}
}
