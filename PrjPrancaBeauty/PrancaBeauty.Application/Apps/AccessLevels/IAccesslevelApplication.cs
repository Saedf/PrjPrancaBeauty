﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.AccessLevels
{
    public interface IAccesslevelApplication
    {
        Task<string> GetIdByNameAsync(string name);
    }
}
