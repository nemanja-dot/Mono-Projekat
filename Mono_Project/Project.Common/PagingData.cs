using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Common
{
    public class PagingData
    {
        public int? Page { get; set; }
        public int? Count { get; set; }
        public string? SearchString { get; set; }
        public string? SortOrder { get; set; }

        public int? VehicleMakeId { get; set; }
    }
}
