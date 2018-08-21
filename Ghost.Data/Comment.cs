using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghost.Data
{
    public class Comment
    {

            [Key]
            public int CommentId { get; set; }

            [Required]
            public Guid OwnerId { get; set; }

            [Required]
            public string Content { get; set; }

            [Required]
            public DateTimeOffset CreatedUtc { get; set; }

            public DateTimeOffset? ModifiedUtc { get; set; }
        }
    }