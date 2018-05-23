using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CustomFilters
{
   public interface ISoftDeleted
    {
        bool Deleted { get; set; }
    }
}
