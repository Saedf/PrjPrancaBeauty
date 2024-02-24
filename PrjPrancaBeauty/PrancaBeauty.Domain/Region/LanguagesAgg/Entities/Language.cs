using FrameWork.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrancaBeauty.Domain.Templates.TemplatesAgg.Entitis;

namespace PrancaBeauty.Domain.Region.LanguagesAgg.Entities
{
    public class Language : IEntity
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Abbr { get; set; }
        public string NativeName { get; set; }
        public bool IsRtl { get; set; }
        public bool IsActive { get; set; }
        public bool UseForSiteLanguage { get; set; }

        public virtual ICollection<Template> Templates { get; set; }
    }
}
