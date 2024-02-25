using FrameWork.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrancaBeauty.Domain.Region.LanguagesAgg.Entities;

namespace PrancaBeauty.Domain.Settings.SettingsAgg.Entities
{
    public class Setting : IEntity
    {
        public Guid Id { get; set; }
        public Guid LangId { get; set; }
        public string SiteTitle { get; set; }
        public string SiteUrl { get; set; }
        public string SiteDescription { get; set; }
        public string Sitemail { get; set; }
        public string SitePhoneNumber { get; set; }
        public bool IsInManufacture { get; set; }
        public bool IsEnable { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Language Language { get; set; }
    }
}
