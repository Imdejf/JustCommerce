using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Language;
using JustCommerce.Application.Common.Factories.DtoFactories.Language;
using JustCommerce.Application.Common.Interfaces;

namespace JustCommerce.Application.Features.ManagemenetFeatures.Language.Query
{
    public static class GetLanguage
    {

        public sealed record Query(Guid ShopId) : IRequestWrapper<List<LanguageDTO>>;

        public sealed class Handler : IRequestHandlerWrapper<Query, List<LanguageDTO>>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<List<LanguageDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var languageList = await _unitOfWorkManagmenet.Language.GetLanguageByShopId(request.ShopId, cancellationToken);

                return languageList.Select(c => LanguageDtoFactory.CreateFromEntity(c)).ToList();
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.ShopId).NotEqual(Guid.Empty);
            }
        }
    }
}
