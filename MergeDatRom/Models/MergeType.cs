using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MergeDatRom.Models
{
    internal enum MergeType
    {
        [Description("Priority Only")]
        PriorityOnly,

        [Description("Tag all but Priority")]
        TagAllButPriority,

        [Description("Tag all")]
        TagAll,
    }
}