using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Domain.Contracts;
using PrancaBeauty.Domain.Region.LanguagesAgg.Entities;

namespace PrancaBeauty.Domain.Templates.TemplatesAgg.Entitis
{
    public class Template:IEntity
    {
        public Guid Id { get; set; }
        public Guid LangId { get; set; }
        public string Name { get; set; }
        public string GeneralTemplate { get; set; }

        public virtual Language Language { get; set; }
    }
}
