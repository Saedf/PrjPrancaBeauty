using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Domain.Users.AccessLevelAgg.Contracts;

namespace PrancaBeauty.Application.Apps.AccessLevels
{
    public class AccesslevelApplication:IAccesslevelApplication
    {
        private readonly IAccesslevelRepository _accesslevelRepository;

        public AccesslevelApplication(IAccesslevelRepository accesslevelRepository)
        {
            _accesslevelRepository = accesslevelRepository;
        }

        public async Task<string> GetIdByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name Can not null");
            }

            var qData = await _accesslevelRepository.GetNoTraking.Where(a => a.Name == name).Select(a => a.Id.ToString()).SingleOrDefaultAsync();

            if (qData == null)
                return Guid.Empty.ToString();

            return qData;
        }
    }
}
