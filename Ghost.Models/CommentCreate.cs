using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghost.Models
{
    public class CommentCreate
    {
        [Required]
        public string Content { get; set; }
        public string Postedby { get; set; }
        

        public override string ToString() => Content;
    }
}
