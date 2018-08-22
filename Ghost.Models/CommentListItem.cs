using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghost.Models
{
    public class CommentListItem
    {
       
        public string Content { get; set; }
        public string Postedby { get; set; }
        public int CommentId { get; set; }

        public override string ToString() => Content;

        

        
       
    }
}
