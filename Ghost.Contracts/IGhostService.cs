using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ghost.Models;

namespace Ghost.Contracts
{
    public interface IGhostService
    {
       bool CreateGhost(GhostCreate model);
       IEnumerable<GhostListItem> GetGhosts();
       GhostDetail GetGhostById(int ghostId);
       bool UpdateGhost(GhostEdit model);
       bool DeleteGhost(int GhostId);

    }
}
