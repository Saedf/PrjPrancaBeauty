using FrameWork.Infrastructure;
using PrancaBeauty.Domain.Templates.TemplatesAgg.Contracts;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrancaBeauty.Domain.Templates.TemplatesAgg.Entitis;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.Templates
{
    public class TemplateRepository : BaseRepository<Template>, ITemplateRepository
    {
        public TemplateRepository(MainContext Context) : base(Context)
        {

        }
    }
}
