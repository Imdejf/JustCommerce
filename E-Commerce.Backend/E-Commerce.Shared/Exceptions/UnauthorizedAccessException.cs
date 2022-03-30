using E_Commerce.Shared.Abstract;

namespace E_Commerce.Shared.Exceptions
{
    public sealed class UnauthorizedAccessException : BaseAppException
    {
        public override int StatusCodeToRise => 401;
        public UnauthorizedAccessException(string message) : base(message) { }
        public UnauthorizedAccessException(Dictionary<string, string[]> errors) : base(errors) { }
    }
}
