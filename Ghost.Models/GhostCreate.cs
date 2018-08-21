using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghost.Models
{
    public class GhostCreate
    {
        [Required]
        public string Title { get; set; }

        [MaxLength(8000)]
        public string Content { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
