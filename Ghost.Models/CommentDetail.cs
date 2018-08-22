using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghost.Models
{
    public class CommentDetail
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public string Postedby { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{CommentId}] {Postedby}";

    }
}
