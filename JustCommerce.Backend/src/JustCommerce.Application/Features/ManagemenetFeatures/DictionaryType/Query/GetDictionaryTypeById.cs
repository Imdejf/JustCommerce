using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Dictionary;
using JustCommerce.Application.Common.Factories.DtoFactories.Dictionary;
using JustCommerce.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.ManagemenetFeatures.DictionaryType.Query
{
    public class GetDictionaryTypeById
    {

        public sealed record Query(Guid DictionaryTypeId) : IRequestWrapper<DictionaryTypeDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Query, DictionaryTypeDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<DictionaryTypeDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var dictionaryType = await _unitOfWorkManagmenet.DictionaryType.GetByIdAsync(request.DictionaryTypeId, cancellationToken);

                return DictionaryTypeDtoFactory.CreateFromEntity(dictionaryType);
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {

            }
        }

    }
}
