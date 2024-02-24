using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Domain.Contracts;
using PrancaBeauty.Domain.Region.LanguagesAgg.Entities;

namespace PrancaBeauty.Domain.Region.LanguagesAgg.Contracts
{
    public interface ILanguageRepository:IRepository<Language>
    {
    }
}
