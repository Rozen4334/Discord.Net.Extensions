namespace Discord.Extensions
{
    public struct HeaderFormat
    {
        public string Format { get; }

        /// <summary>
        ///     The biggest header type.
        /// </summary>
        public static readonly HeaderFormat H1 = new("#");

        /// <summary>
        ///     An above-average sized header.
        /// </summary>
        public static readonly HeaderFormat H2 = new("##");

        /// <summary>
        ///     An average-sized header.
        /// </summary>
        public static readonly HeaderFormat H3 = new("###");

        /// <summary>
        ///     A subheader.
        /// </summary>
        public static readonly HeaderFormat H4 = new("####");

        /// <summary>
        ///     A smaller subheader.
        /// </summary>
        public static readonly HeaderFormat H5 = new("#####");

        /// <summary>
        ///     Slightly bigger than regular bold markdown.
        /// </summary>
        public static readonly HeaderFormat H6 = new("######");

        private HeaderFormat(string format)
        {
            Format = format;
        }

        /// <summary>
        ///     Formats this header into markdown, appending provided string.
        /// </summary>
        /// <param name="input">The string to turn into a header.</param>
        /// <returns>A markdown formatted header title.</returns>
        public string ToMarkdown(string input)
            => $"{Format} {input}";

        /// <summary>
        ///     Gets the markdown format for this header.
        /// </summary>
        /// <returns>The markdown format for this header.</returns>
        public override string ToString()
            => $"{Format}";
    }
}
