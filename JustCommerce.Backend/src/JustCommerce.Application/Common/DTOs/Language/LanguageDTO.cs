using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.DTOs.Language
{
    public class LanguageDTO
    {
        public Guid Id { get; set; }
        public string IsoCode { get; set; }
        public string NameOrginal { get; set; }
        public string NameInternational { get; set; }
        public Guid ShopId { get; set; }
        public bool IsActive { get; set; }
        public bool DefaultLanguage { get; set; }
    }
}
