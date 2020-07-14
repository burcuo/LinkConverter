using Trendyol.LinkConverter.Domain;

namespace Trendyol.LinkConverter.Contracts
{
    public interface IDeeplinkConverterController
    {
        public WebUrlDto GetWebUrl(DeeplinkDto rDto);
    }
}
