using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class BookReturn
    {
        //BookId, StudentId, Fine, dtBookReturn
        public int BookId { get; set; }
        public int StudentId { get; set; }
        public float Fine { get; set; }
        public DateTime dtBookReturn { get; set; }

    }
}
