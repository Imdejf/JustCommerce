using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Language;
using JustCommerce.Application.Common.Factories.DtoFactories.Language;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.ManagemenetFeatures.Language.Query
{
    public static class GetLangaugeById
    {

        public sealed record Query(Guid LanguageId) : IRequestWrapper<LanguageDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Query, LanguageDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<LanguageDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var language = await _unitOfWorkManagmenet.Language.GetByIdAsync(request.LanguageId, cancellationToken);

                return LanguageDtoFactory.CreateFromEntity(language);
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.LanguageId).NotEqual(Guid.Empty);
            }
        }

    }
}
