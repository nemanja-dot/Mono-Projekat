using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mono_Project.Models
{
    public class PagingDataViewModel
    {
        public int? Page { get; set; }
        public int? Count { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }
    }
}
