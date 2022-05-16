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
    public class GetDictionaryType
    {

        public sealed record Query(Guid ShopId) : IRequestWrapper<List<DictionaryTypeDTO>>;

        public sealed class Handler : IRequestHandlerWrapper<Query, List<DictionaryTypeDTO>>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;

            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<List<DictionaryTypeDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var dictionaryTypeList = await _unitOfWorkManagmenet.DictionaryType.GetAllByShopId(request.ShopId, cancellationToken);

                return dictionaryTypeList.Select(c => DictionaryTypeDtoFactory.CreateFromEntity(c)).ToList();
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
