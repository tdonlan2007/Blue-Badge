using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ghost.Contracts;
using Ghost.Data;
using Ghost.Models;

public class GhostService : IGhostService
{
    private readonly Guid _userId;

    public GhostService(Guid userId)
    {
        _userId = userId;
    }

    public bool CreateGhost(GhostCreate model)
    {

        var entity =
            new Ghostt()
            {
                OwnerId = _userId,
                Title = model.Title,
                Content = model.Content,
                CreatedUtc = DateTimeOffset.Now
            };

        using (var ctx = new ApplicationDbContext())
        {
            ctx.Ghosts.Add(entity);
            return ctx.SaveChanges() == 1;
        }
    }

    public IEnumerable<GhostListItem> GetGhosts()
    {
        using (var ctx = new ApplicationDbContext())
        {
            var query =
                ctx
                    .Ghosts
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new GhostListItem
                            {
                                GhostId = e.GhostId,
                                Title = e.Title,
                                CreatedUtc = e.CreatedUtc

                            }
                    );

            return query.ToArray();
        }
    }

    public GhostDetail GetGhostById(int ghostId)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                    .Ghosts
                    .Single(e => e.GhostId == ghostId && e.OwnerId == _userId);
            return
                new GhostDetail
                {
                    GhostId = entity.GhostId,
                    Title = entity.Title,
                    Content = entity.Content,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
        }
    }

    public bool UpdateGhost(GhostEdit model)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                    .Ghosts
                    .Single(e => e.GhostId == model.GhostId && e.OwnerId == _userId);

            entity.Title = model.Title;
            entity.Content = model.Content;
            entity.ModifiedUtc = DateTimeOffset.UtcNow;

            return ctx.SaveChanges() == 1;
        }
    }
    public bool DeleteGhost(int GhostId)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                    .Ghosts
                    .Single(e => e.GhostId == GhostId && e.OwnerId == _userId);

            ctx.Ghosts.Remove(entity);

            return ctx.SaveChanges() == 1;
        }
    }
}












