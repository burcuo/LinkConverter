using Trendyol.LinkConverter.Domain;

namespace Trendyol.LinkConverter.Application
{
    public interface IShortLinkConverter
    {
        public LinkDto GetLinks(ShortLinkDto shortlink);

        public ShortLinkDto GetShortLink(DeeplinkDto deeplinkDto);

        public ShortLinkDto GetShortLink(WebUrlDto webUrlDto);

    }
}
