using Trendyol.LinkConverter.Application.Helpers;
using Trendyol.LinkConverter.Domain;
using Trendyol.LinkConverter.EntityFramework.Interfaces;
using Trendyol.LinkConverter.EntityFramework.Models;

namespace Trendyol.LinkConverter.Application
{
    /*
     * Handles generation of short link and related functions
     */

    public class ShortLinkConverter : IShortLinkConverter
    {
        private IShortLinkRepositorty _repository;
        private IConverterHelper _helper;

        public ShortLinkConverter(IShortLinkRepositorty repositorty, IConverterHelper helper)
        {
            _repository = repositorty;
            _helper = helper;
        }

        public LinkDto GetLinks(ShortLinkDto shortLinkDto)
        {
            ShortLinkEntity entity = _repository.GetLinks(shortLinkDto.shortlink);

            return new LinkDto() { deeplink = entity.Deeplink, webUrl = entity.WebUrl };
        }

        public ShortLinkDto GetShortLink(DeeplinkDto deeplinkDto)
        {
            ShortLinkEntity entity = _repository.GetByDeeplink(deeplinkDto.deeplink);

            if (entity == null)
            {
                string shortlink = ShortLinkHelper.GenerateShortLink();

                WebUrlDto webUrlDto = _helper.ConvertDeeplinkToWebLink(deeplinkDto);

                entity = _repository.Insert(deeplinkDto.deeplink, webUrlDto.webUrl, shortlink);
            }

            return new ShortLinkDto() { shortlink = entity.ShortLink };
        }

        public ShortLinkDto GetShortLink(WebUrlDto webUrlDto)
        {
            ShortLinkEntity entity = _repository.GetByWebUrl(webUrlDto.webUrl);
            if (entity == null)
            {
                string shortlink = ShortLinkHelper.GenerateShortLink();

                DeeplinkDto deeplinkDto = _helper.ConvertWebLinkToDeeplink(webUrlDto);

                entity = _repository.Insert(deeplinkDto.deeplink, webUrlDto.webUrl, shortlink);
            }

            return new ShortLinkDto() { shortlink = entity.ShortLink };
        }
    }
}
