using Trendyol.LinkConverter.Domain;

namespace Trendyol.LinkConverter.Application
{
    public interface IConverterHelper
    {
        public DeeplinkDto ConvertWebLinkToDeeplink(WebUrlDto webUrlDto);

        public WebUrlDto ConvertDeeplinkToWebLink(DeeplinkDto deeplinkDto);
    }
}
