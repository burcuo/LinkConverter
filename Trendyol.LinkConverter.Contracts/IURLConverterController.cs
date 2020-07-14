using Trendyol.LinkConverter.Domain;

namespace Trendyol.LinkConverter.Contracts
{
    public interface IURLConverterController
    {
        public DeeplinkDto GetDeeplink(WebUrlDto rDto);

    }
}
