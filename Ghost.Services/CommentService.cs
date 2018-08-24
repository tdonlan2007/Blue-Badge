using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ghost.Data;
using Ghost.Models;

namespace Ghost.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    OwnerId = _userId,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now,
                    Postedby = model.Postedby,
                    GhostId = model.GhostId
                    

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    Content = e.Content,
                                    Postedby = e.Postedby,
                                    CommentId = e.CommentId
                                }
                        );

                return query.ToArray();
            }
        }

        public CommentDetail GetCommentById(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                .Comments
                .Single(e => e.CommentId == commentId && e.OwnerId == _userId);

                return
                new CommentDetail
                {
                    CommentId = entity.CommentId,
                    Content = entity.Content,
                    Postedby = entity.Postedby,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == model.CommentId && e.OwnerId == _userId);

                entity.Postedby = model.Postedby;
                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == commentId && e.OwnerId == _userId);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
    



