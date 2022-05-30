using JustCommerce.Application.Models.MessageBus.Abstract;
using JustCommerce.Domain.Enums;

namespace JustCommerce.Application.Models.MessageBus
{
    internal class UserCreatedNotificationBusEvent : BaseNotificationEvent
    {
        public override NotificationType NotificationType => NotificationType.CreatedUser;
        protected override string _Description => "User with {userEmail} email created";

        private string _userEmail;

        public UserCreatedNotificationBusEvent(string email)
        {
            _userEmail = email;
        }

        public override string GetDescription()
        {
            return _Description.Replace("{userEmail}", _userEmail);
        }
    }
}
