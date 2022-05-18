using FluentValidation;
using JustCommerce.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.ManagemenetFeatures.DictionaryType.Query
{
    public class GetDictionaryTypeEnum
    {

        public sealed record Query() : IRequestWrapper<List<string>>;

        public sealed class Handler : IRequestHandlerWrapper<Query, List<string>>
        {
            public Handler()
            {
            }


            public async Task<List<string>> Handle(Query request, CancellationToken cancellationToken)
            {
                var dictionaryTypeEnumList = Enum.GetValues(typeof(Domain.Enums.Dictionary.DictionaryType)).Cast<Domain.Enums.Dictionary.DictionaryType>()
                                                                                                           .Select(c => c.ToString())
                                                                                                           .ToList();
                
                return dictionaryTypeEnumList;
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
