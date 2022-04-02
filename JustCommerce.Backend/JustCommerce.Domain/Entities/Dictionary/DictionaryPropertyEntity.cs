using JustCommerce.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Domain.Entities.Dictionary
{
    public sealed class DictionaryPropertyEntity : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid DictionaryId { get; set; }
        public DictionaryEntity Dictionary { get; set; }
    }
}
