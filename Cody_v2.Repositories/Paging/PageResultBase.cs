﻿namespace Cody_v2.Repositories.Paging
{
    public class PageResultBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public Func<int?, string> GenerateUrl { get; set; }

        public int FirstRowOnPage { get { return (CurrentPage - 1) * PageSize + 1; } }
        public int LastRowOnPage { get { return Math.Min(CurrentPage * PageSize, RowCount); } }
    }
}
