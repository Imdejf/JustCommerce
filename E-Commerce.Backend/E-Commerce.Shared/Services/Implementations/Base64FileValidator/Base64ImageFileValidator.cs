using E_Commerce.Shared.Services.Interfaces.Base64FileValidator;

namespace E_Commerce.Shared.Services.Implementations.Base64FileValidator
{
    internal sealed class Base64ImageFileValidator : AbstractBase64FileValidator<IBase64ImageFileValidatorValidationStage>,
        IBase64ImageFileValidatorValidationStage,
        IBase64ImageFileValidator
    {
    }
}
