using JustCommerce.Shared.Abstract;

namespace JustCommerce.Shared.Exceptions
{
    public sealed class InvalidRequestException : BaseAppException
    {
        public override int StatusCodeToRise => 400;
        public InvalidRequestException(string message) : base(message) { }
        public InvalidRequestException(Dictionary<string, string[]> errors) : base(errors) { }
    }
}
