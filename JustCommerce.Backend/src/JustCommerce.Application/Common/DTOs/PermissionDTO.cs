using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.DTOs
{
    public class PermissionDTO
    {
        public string PermissionDomainName { get; set; }
        public string PermissionFlagName { get; set; }
        public int PermissionFlagValue { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is not PermissionDTO) return false;
            var castedObj = obj as PermissionDTO;
            return PermissionDomainName == castedObj.PermissionDomainName &&
                   PermissionFlagName == castedObj.PermissionFlagName &&
                   PermissionFlagValue == castedObj.PermissionFlagValue;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
