using MergeDatRom.Models;

namespace MergeDatRom.Models
{
    public class MergeSettings
    {
        public MergeType Method { get; set; }
        public TagPosition TagPosition { get; set; }
        public bool AlsoTagDesc { get; set; }
        public bool OpenFileAfterCreated { get; set; }
        public bool StripTagsForMatching { get; set; }
        public bool UseSquareBrackets { get; set; }
        public bool UseBrackets { get; set; }
        public string GlobalIncludeTags { get; set; }
        public string GlobalExcludeTags { get; set; }
    }
}