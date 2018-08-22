using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ghost.Data;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ghost.Contracts
{
    public interface IAdminService
    {
        bool IsAdminUser();
        IEnumerable<ApplicationUser> GetUserList();
        IEnumerable<IdentityRole> GetRolesList();
    }
}