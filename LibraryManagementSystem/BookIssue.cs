using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class BookIssue
    {
        //BookId, StudentId, dtBookIssue
     public int BookId { get; set; }
     public int StudentId { get; set; }
        public DateTime dtBookIssue { get; set; }
        
    }
}
