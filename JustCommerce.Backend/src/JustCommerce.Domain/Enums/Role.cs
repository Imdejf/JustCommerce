using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Domain.Enums
{
    public enum Roles
    {
        SuperVisior,
        Manager,
        Seller,
        Basic
    }

    public static class RoleConstant
    {
        public static readonly Guid SuperVisior = Guid.NewGuid();
        public static readonly Guid Manager = Guid.NewGuid();
        public static readonly Guid Seller = Guid.NewGuid();
        public static readonly Guid Basic = Guid.NewGuid();
    }
}
