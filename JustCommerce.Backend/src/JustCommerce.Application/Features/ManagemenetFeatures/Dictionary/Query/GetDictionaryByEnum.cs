using FluentValidation;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.ManagemenetFeatures.Dictionary.Query
{
    public static class GetDictionaryByEnum
    {

        public sealed record Query(Domain.Enums.Dictionary.DictionaryType DictionaryType) : IRequestWrapper<List<string>>;

        public sealed class Handler : IRequestHandlerWrapper<Query, List<string>>
        {
            public Handler()
            {
            }

            public async Task<List<string>> Handle(Query request, CancellationToken cancellationToken)
            {

                var dictionary = getDictionaryEnum(request.DictionaryType);

                if(dictionary is null)
                {
                    throw new InvalidRequestException($"Enum with number: {request.DictionaryType} not exist");
                }

                return dictionary;
            }
        }

        private static List<string> getDictionaryEnum(Domain.Enums.Dictionary.DictionaryType dictionaryEnum)
        {
            switch (dictionaryEnum)
            {
                case Domain.Enums.Dictionary.DictionaryType.Sms:
                        return Enum.GetValues(typeof(Domain.Enums.Dictionary.Sms)).Cast<Domain.Enums.Dictionary.Sms>()
                                                                                                               .Select(c => c.ToString())
                                                                                                               .ToList();
                    break;
                default:
                    return null;
                    break;
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
