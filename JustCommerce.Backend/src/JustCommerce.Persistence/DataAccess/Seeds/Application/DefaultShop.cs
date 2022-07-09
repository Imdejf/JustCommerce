using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Entities.Email;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Seeds.Application
{
    public static class DefaultShop
    {
        static Guid mailDataSharpGuid = Guid.NewGuid();
        static Guid mailTestGuid = Guid.NewGuid();
        static Guid ShopDataSharpGuid = Guid.NewGuid();
        static Guid ShopTestGuid = Guid.NewGuid();

        public static void Shop(this ModelBuilder modelBuilder)
        {
            CreateShop(modelBuilder);
            CreateEmailAccount(modelBuilder);
        }
        
        public static void CreateEmailAccount(ModelBuilder modelBuilder)
        {
            List<EmailAccountEntity> mail = EmailList();
            modelBuilder.Entity<EmailAccountEntity>().HasData(mail);
        }

        public static void CreateShop(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreEntity>().HasData(ShopList());
        }

        private static List<StoreEntity> ShopList()
        {
            return new List<StoreEntity>()
            {
                new StoreEntity() { Id = ShopDataSharpGuid, Name="DataSharp"},
                new StoreEntity() { Id = ShopTestGuid, Name="DefualtShop"},
            };
        }

        private static List<EmailAccountEntity> EmailList()
        {
            return new List<EmailAccountEntity>()
            {
                new EmailAccountEntity() { Id = mailDataSharpGuid, Name = "DataSharp Email Sender" ,EmailAddress = "kontakt@emagazynowo.pl",
                    SmtpLogin= "kontakt@emagazynowo.pl", SmtpPassword = "kaHBV(.q4F", SmtpPort = 587, SmtpServer = "serwer2299342.home.pl", ShopId = ShopDataSharpGuid },

                new EmailAccountEntity() { Id = mailTestGuid, Name = "DefualtShop Email Sender" ,EmailAddress = "DefualtShop@DefualtTest.pl",
                    SmtpLogin= "DefualtShop@DefualtTest.pl", SmtpPassword = "kaHBV(.q4F", SmtpPort = 587, SmtpServer = "serwer2299342.home.pl", ShopId = ShopTestGuid }
            };
        }
    }
}
