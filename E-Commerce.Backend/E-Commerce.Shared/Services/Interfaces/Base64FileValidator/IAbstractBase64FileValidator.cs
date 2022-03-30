using E_Commerce.Shared.Models;

namespace E_Commerce.Shared.Services.Interfaces.Base64FileValidator
{
    public interface IAbstractBase64FileValidatorFileStage<TChildValidator> where TChildValidator : IAbstractBase64FileValidatorValidationStage<TChildValidator>
    {
        TChildValidator OnFile(Base64File base64File);
    }
    public interface IAbstractBase64FileValidatorValidationStage<TChildValidator> where TChildValidator : IAbstractBase64FileValidatorValidationStage<TChildValidator>
    {
        TChildValidator WithExtension(params string[] extensions);
        TChildValidator WithoutExtension(params string[] extensions);
        TChildValidator WithMaxFileSize(double fileSizeInMb);
        TChildValidator WithMinFileSize(double fileSizeInMb);
        bool IsValid(out string[] errors);
    }
}
