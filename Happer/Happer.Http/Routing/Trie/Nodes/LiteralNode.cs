namespace Happer.Http.Routing.Trie.Nodes
{
    using System;

    /// <summary>
    /// Literal string node e.g. goo
    /// Literal segments - (10,000) - /some/literal/segments which require an exact match.
    /// </summary>
    public class LiteralNode : TrieNode
    {
        /// <summary>
        /// Score for this node
        /// </summary>
        public override int Score
        {
            get { return 10000; }
        }

        public LiteralNode(TrieNode parent, string segment, ITrieNodeFactory nodeFactory)
            : base(parent, segment, nodeFactory)
        {
        }

        /// <summary>
        /// Matches the segment for a requested route
        /// </summary>
        /// <param name="segment">Segment string</param>
        /// <returns>A <see cref="SegmentMatch"/> instance representing the result of the match</returns>
        public override SegmentMatch Match(string segment)
        {
            var comparisonType = StringComparison.OrdinalIgnoreCase;

            if (string.Equals(
                    segment,
                    this.RouteDefinitionSegment,
                    comparisonType))
            {
                return new SegmentMatch(true);
            }

            return SegmentMatch.NoMatch;
        }
    }
}