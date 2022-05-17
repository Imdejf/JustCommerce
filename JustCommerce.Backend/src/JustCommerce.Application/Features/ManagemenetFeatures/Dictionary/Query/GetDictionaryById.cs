using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Dictionary;
using JustCommerce.Application.Common.Factories.DtoFactories.Dictionary;
using JustCommerce.Application.Common.Interfaces;

namespace JustCommerce.Application.Features.ManagemenetFeatures.Dictionary.Query
{
    public static class GetDictionaryById
    {

        public sealed record Query(Guid DictionaryId) : IRequestWrapper<DictionaryDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Query, DictionaryDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<DictionaryDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var dictionary = await _unitOfWorkManagmenet.Dictionary.GetFullyObject(request.DictionaryId, cancellationToken);

                return DictionaryDtoFactory.CreateFromEntity(dictionary);
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.DictionaryId).NotEqual(Guid.Empty);
            }
        }

    }
}
