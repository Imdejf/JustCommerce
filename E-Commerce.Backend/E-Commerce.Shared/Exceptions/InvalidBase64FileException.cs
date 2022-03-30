using E_Commerce.Shared.Abstract;

namespace E_Commerce.Shared.Exceptions
{
    public sealed class InvalidBase64FileException : BaseAppException
    {
        public override int StatusCodeToRise => 400;
        public InvalidBase64FileException(string message) : base(message)
        {
        }
    }
}
