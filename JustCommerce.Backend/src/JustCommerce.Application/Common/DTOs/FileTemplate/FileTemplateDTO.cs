using JustCommerce.Shared.Models;

namespace JustCommerce.Application.Common.DTOs.FileTemplate
{
    public class FileTemplateDTO
    {
        public string? HtmlTemplate { get; set; }
        public Base64File? Base64File { get; set; }
    }
}
