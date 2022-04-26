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
        public string Name { get; set; }
    }
}
