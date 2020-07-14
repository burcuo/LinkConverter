using Trendyol.LinkConverter.Application.Helpers;
using Trendyol.LinkConverter.Application.Interfaces;
using Trendyol.LinkConverter.Domain;
using Trendyol.LinkConverter.Domain.Enums;

namespace Trendyol.LinkConverter.Application
{
    public class ConverterHelper : IConverterHelper
    {
        ILinkConverter _homeLinkConverter = new HomeLinkConverter();
        ILinkConverter _productLinkConverter = new ProductLinkConverter();
        ILinkConverter _searchLinkConverter = new SearchLinkConverter();
        ILinkConverter _otherLinkConverter = new GeneralLinkConverter();

        public WebUrlDto ConvertDeeplinkToWebLink(DeeplinkDto deeplinkDto)
        {
            LinkType type = GetPageLinkType(deeplinkDto.deeplink, false);
            WebUrlDto webUrlDto = null;
            switch (type)
            {
                case LinkType.HomePage:
                    webUrlDto = _homeLinkConverter.DeeplinkToWebUrl(deeplinkDto);
                    break;
                case LinkType.ProductDetailPage:
                    webUrlDto = _productLinkConverter.DeeplinkToWebUrl(deeplinkDto);
                    break;
                case LinkType.SearchPage:
                    webUrlDto = _searchLinkConverter.DeeplinkToWebUrl(deeplinkDto);
                    break;
                default:
                    webUrlDto = _otherLinkConverter.DeeplinkToWebUrl(deeplinkDto);
                    break;
            }

            return webUrlDto;
        }

        public DeeplinkDto ConvertWebLinkToDeeplink(WebUrlDto webUrlDto)
        {
            LinkType type = GetPageLinkType(webUrlDto.webUrl);

            DeeplinkDto deeplinkDto = null;
            switch (type)
            {
                case LinkType.HomePage:
                    deeplinkDto = _homeLinkConverter.WebUrlToDeeplink(webUrlDto);
                    break;
                case LinkType.ProductDetailPage:
                    deeplinkDto = _productLinkConverter.WebUrlToDeeplink(webUrlDto);
                    break;
                case LinkType.SearchPage:
                    deeplinkDto = _searchLinkConverter.WebUrlToDeeplink(webUrlDto);
                    break;
                default:
                    deeplinkDto = _otherLinkConverter.WebUrlToDeeplink(webUrlDto);
                    break;
            }

            return deeplinkDto;

        }

        /* Determines given link's page type
         * 
         */
        private LinkType GetPageLinkType(string link, bool isSiteLink = true)
        {
            if (isSiteLink)
            {
                if (link.Contains("/butik/liste"))
                    return LinkType.HomePage;
                else if (link.Contains("-p-"))
                    return LinkType.ProductDetailPage;
                else if (link.Contains("/tum-urunler?q"))
                    return LinkType.SearchPage;
                else
                    return LinkType.OtherPage;
            }
            else
            {
                if (link.Contains("Page=Home"))
                    return LinkType.HomePage;
                else if (link.Contains("Page=Product"))
                    return LinkType.ProductDetailPage;
                else if (link.Contains("Page=Search"))
                    return LinkType.SearchPage;
                else
                    return LinkType.OtherPage;
            }            
        }
    }
}
