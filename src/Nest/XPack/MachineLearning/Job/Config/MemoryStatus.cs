﻿using System.Runtime.Serialization;
using Elasticsearch.Net;


namespace Nest
{
	/// <summary>
	/// The status of the mathematical models.
	/// </summary>
	[StringEnum]
	public enum MemoryStatus
	{
		/// <summary>
		/// The models stayed below the configured value.
		/// </summary>
		[EnumMember(Value = "ok")]
		Ok,

		/// <summary>
		/// The models used more than 60% of the configured memory limit and older
		/// unused models will be pruned to free up space.
		/// </summary>
		[EnumMember(Value = "soft_limit")]
		SoftLimit,

		/// <summary>
		/// The models used more space than the configured memory limit.
		/// As a result, not all incoming data was processed.
		/// </summary>
		[EnumMember(Value = "hard_limit")]
		HardLimit
	}
}
