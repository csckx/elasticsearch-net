using System.Runtime.Serialization;

namespace Nest
{
	/// <summary>
	/// A values source that can be applied on date values to build fixed size interval over the values.
	/// The interval parameter defines a date/time expression that determines how values should be transformed.
	/// For instance an interval set to month will translate any values to its closest month interval..
	/// </summary>
	public interface IDateHistogramCompositeAggregationSource : ICompositeAggregationSource
	{
		/// <summary>
		/// Return a formatted date string as the key instead an epoch long
		/// </summary>
		/// <remarks> Valid for Elasticsearch 6.3.0+ </remarks>
		[DataMember(Name ="format")]
		string Format { get; set; }

		/// <summary>
		/// 	The interval to use when bucketing documents
		/// </summary>
		[DataMember(Name ="interval")]
		Union<DateInterval?, Time> Interval { get; set; }

		/// <summary>
		/// Used to indicate that bucketing should use a different time zone.
		/// Time zones may either be specified as an ISO 8601 UTC offset (e.g. +01:00 or -08:00)
		/// or as a timezone id, an identifier used in the TZ database like America/Los_Angeles.
		/// </summary>
		[DataMember(Name ="time_zone")]
		string TimeZone { get; set; }
	}

	/// <inheritdoc cref="IDateHistogramCompositeAggregationSource" />
	public class DateHistogramCompositeAggregationSource : CompositeAggregationSourceBase, IDateHistogramCompositeAggregationSource
	{
		public DateHistogramCompositeAggregationSource(string name) : base(name) { }

		/// <inheritdoc />
		public string Format { get; set; }

		/// <inheritdoc />
		public Union<DateInterval?, Time> Interval { get; set; }

		/// <inheritdoc />
		public string TimeZone { get; set; }

		/// <inheritdoc />
		protected override string SourceType => "date_histogram";
	}

	/// <inheritdoc cref="IDateHistogramCompositeAggregationSource" />
	public class DateHistogramCompositeAggregationSourceDescriptor<T>
		: CompositeAggregationSourceDescriptorBase<DateHistogramCompositeAggregationSourceDescriptor<T>, IDateHistogramCompositeAggregationSource, T>,
			IDateHistogramCompositeAggregationSource
	{
		public DateHistogramCompositeAggregationSourceDescriptor(string name) : base(name, "date_histogram") { }

		string IDateHistogramCompositeAggregationSource.Format { get; set; }
		Union<DateInterval?, Time> IDateHistogramCompositeAggregationSource.Interval { get; set; }
		string IDateHistogramCompositeAggregationSource.TimeZone { get; set; }

		/// <inheritdoc cref="IDateHistogramCompositeAggregationSource.Interval" />
		public DateHistogramCompositeAggregationSourceDescriptor<T> Interval(DateInterval? interval) =>
			Assign(interval, (a, v) => a.Interval = v);

		/// <inheritdoc cref="IDateHistogramCompositeAggregationSource.Interval" />
		public DateHistogramCompositeAggregationSourceDescriptor<T> Interval(Time interval) =>
			Assign(interval, (a, v) => a.Interval = v);

		/// <inheritdoc cref="IDateHistogramCompositeAggregationSource.TimeZone" />
		public DateHistogramCompositeAggregationSourceDescriptor<T> TimeZone(string timezone) => Assign(timezone, (a, v) => a.TimeZone = v);

		/// <inheritdoc cref="IDateHistogramCompositeAggregationSource.TimeZone" />
		public DateHistogramCompositeAggregationSourceDescriptor<T> Format(string format) => Assign(format, (a, v) => a.Format = v);
	}
}
