using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Customer.Vendor;
using JustCommerce.Domain.Entities.Vendor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Customer.Vendor
{
    internal sealed class VendorRepository : BaseRepository<VendorEntity>, IVendorRepository
    {
        public VendorRepository(DbSet<VendorEntity> entity) : base(entity)
        {
        }
    }
}
