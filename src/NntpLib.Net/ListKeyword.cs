using System.ComponentModel;

namespace NntpLib.Net
{
    public enum ListKeyword
    {
        [Description("ACTIVE")]
        Active,

        [Description("ACTIVE.TIMES")]
        ActiveTimes,

        [Description("DISTRIB.PATS")]
        DistribPats,

        [Description("HEADERS")]
        Headers,

        [Description("NEWSGROUPS")]
        NewsGroups,

        [Description("OVERVIEW.FMT")]
        OverviewFormat
    }
}