using JustCommerce.Application.Models;
using JustCommerce.Shared.Abstract;

namespace JustCommerce.Application.Common.Exceptions
{
    public sealed class IdentityException : BaseAppException
    {
        public IdentityException(string message) : base(message)
        {
        }
        public IdentityException(Dictionary<string, string[]> errors) : base(errors)
        {
        }
        public IdentityException(IdentityActionResult identityActionResult) : base(new Dictionary<string, string[]>() { { "Message", identityActionResult.Errors } }) { }

        public override int StatusCodeToRise => 400;
    }
}
