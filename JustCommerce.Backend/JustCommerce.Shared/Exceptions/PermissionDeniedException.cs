﻿using JustCommerce.Shared.Abstract;

namespace JustCommerce.Shared.Exceptions
{
    public sealed class PermissionDeniedException : BaseAppException
    {
        public override int StatusCodeToRise => 403;
        public PermissionDeniedException(string message) : base(message) { }
        public PermissionDeniedException(Dictionary<string, string[]> errors) : base(errors) { }
    }
}
