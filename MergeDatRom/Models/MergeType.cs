using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MergeDatRom.Models
{
    internal enum MergeType
    {
        [Description("Tag all")]
        TagAll,

        [Description("Tag all but Priority")]
        TagAllButPriority,

        [Description("Priority Only")]
        KeepPriorityOnly,
    }
}