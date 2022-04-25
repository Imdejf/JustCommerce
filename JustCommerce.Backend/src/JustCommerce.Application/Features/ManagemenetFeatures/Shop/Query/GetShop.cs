using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Company;
using JustCommerce.Application.Common.Factories.DtoFactories.Company;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.ManagemenetFeatures.Shop.Query
{
    public static class GetShop
    {

        public sealed record Query() : IRequestWrapper<List<ShopDTO>>;

        public sealed class Handler : IRequestHandlerWrapper<Query, List<ShopDTO>>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<List<ShopDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var shopList = await _unitOfWorkManagmenet.Shop.GetAllAsync(cancellationToken);

                return shopList.Select(c => ShopDtoFactory.CreateFromEntity(c)).ToList();
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
