using Trendyol.LinkConverter.Domain;

namespace Trendyol.LinkConverter.Application.Interfaces
{
    public interface ILinkConverter
    {
        public DeeplinkDto WebUrlToDeeplink(WebUrlDto webUrlObj);

        public WebUrlDto DeeplinkToWebUrl(DeeplinkDto deeplinkObj);
    }
}
