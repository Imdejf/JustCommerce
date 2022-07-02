using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Language;
using JustCommerce.Application.Common.Factories.DtoFactories.Language;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Language;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.ManagemenetFeatures.Language.Command
{
    public static class CreateLanguage
    {

        public sealed record Command(Guid ShopId, string NameOrginal, string NameInternational,string IsoCode, bool IsActive, bool DefaultLanguage) : IRequestWrapper<LanguageDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, LanguageDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<LanguageDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                bool exist = await _unitOfWorkManagmenet.Language.ExistNameOrIsoCode(request.NameOrginal, request.IsoCode);
                
                if (exist)
                {
                    throw new InvalidRequestException("Passed language name or isocode exist in database");
                }

                var newLanguage = LanguageEntityFactory.CreateFromShopCommand(request);

                await _unitOfWorkManagmenet.Language.AddAsync(newLanguage, cancellationToken);

                return LanguageDtoFactory.CreateFromEntity(newLanguage);
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.NameOrginal).NotEmpty();
                RuleFor(c => c.IsoCode).NotEmpty();
                RuleFor(c => c.NameInternational).NotEmpty();
                RuleFor(c => c.ShopId).NotEqual(Guid.Empty);
            }
        }

    }
}
