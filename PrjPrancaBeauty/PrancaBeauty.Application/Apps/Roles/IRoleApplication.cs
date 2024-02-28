using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Roles
{
    public interface IRoleApplication
    {
        //Task<string> GetIdByNameAsync(InpGetIdByName Input);
        Task<List<string>> GetRolesByUserAsync(string userId);
        //Task<List<OutListOfRoles>> ListOfRolesAsync(InpListOfRoles Input);
        //Task<string[]> ListOfRolesByAccessLevelIdAsync(InpListOfRolesByAccessLevelId Input);
    }
}
