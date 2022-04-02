using JustCommerce.Shared.Services.Interfaces.Base64FileValidator;

namespace JustCommerce.Shared.Services.Implementations.Base64FileValidator
{
    internal sealed class Base64ImageFileValidator : AbstractBase64FileValidator<IBase64ImageFileValidatorValidationStage>,
        IBase64ImageFileValidatorValidationStage,
        IBase64ImageFileValidator
    {
    }
}
