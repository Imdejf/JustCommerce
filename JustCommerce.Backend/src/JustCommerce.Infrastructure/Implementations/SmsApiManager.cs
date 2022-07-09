//using JustCommerce.Application.Common.Interfaces;
//using JustCommerce.Domain.Entities.Sms;
//using JustCommerce.Domain.Enums;
//using JustCommerce.Infrastructure.Configurations;
//using JustCommerce.Persistence.DataAccess;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;
//using SMSApi.Api;

//namespace JustCommerce.Infrastructure.Implementations
//{
//    internal sealed class SmsApiManager : ISmsApiManager
//    {
//        private readonly JustCommerceDbContext _justCommerceDbContext;
//        public SmsApiManager(JustCommerceDbContext justCommerceDbContext)
//        {
//            _justCommerceDbContext = justCommerceDbContext;
//        }

//        public async Task SendSmsForSetStatus(string to, Guid shopId, Guid languageId, SmsType smsType,int orderNumber, CancellationToken cancellationToken = default)
//        {
//            var template = await _justCommerceDbContext._SmsTemplate
//                                                       .Include(c => c.SmsAccount)
//                                                       .Include(c => c.SmsTemplateLang.Where(c => c.LanguageId == languageId))
//                                                       .FirstOrDefaultAsync(c => c.SmsType == smsType && c.Active == true && c.ShopId == shopId, cancellationToken);
//            var text = template.SmsTemplateLang.First(c => c.SmsTemplateId == template.Id);

//            text.Text.Replace("[ORDERNUMBER]", orderNumber.ToString());

//            sendSms(template.SmsAccount.SmsGate, template.SmsAccount.Token, text.Text, to, template.SmsAccount.From, template.SmsAccount.Test);
//        }

//        private void sendSms(SmsGate smsGate,string token, string text, string to, string sender, bool test = false)
//        {
//            switch (smsGate)
//            {
//                case SmsGate.SmsApi:
//                    IClient client = new ClientOAuth(token);
//                    var smsApi = new SMSFactory(client);

//                    var result = smsApi.ActionSend()
//                           .SetText(text)
//                           .SetTo(to)
//                           .SetSender(sender)
//                           .SetTest(test)
//                           .Execute();

//                    break;
//            }
//        }
//    }
//}
