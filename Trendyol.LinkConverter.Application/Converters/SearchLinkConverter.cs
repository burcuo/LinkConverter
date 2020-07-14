using Org.BouncyCastle.Asn1.CryptoPro;
using System;
using System.Web;
using Trendyol.LinkConverter.Application.Interfaces;
using Trendyol.LinkConverter.Domain;

namespace Trendyol.LinkConverter.Application.Helpers
{
    /*
     * Handles conversion of both deeplink and weburl related with Search Page
     */

    public class SearchLinkConverter : ILinkConverter
    {
        public WebUrlDto DeeplinkToWebUrl(DeeplinkDto deeplinkObj)
        {
            WebUrlDto webUrlDto = new WebUrlDto();
            webUrlDto.webUrl = deeplinkObj.deeplink.Replace(LinkInfoHelper.siteDeeplink, LinkInfoHelper.siteWeb).Replace("?Page=Search", "/tum_urunler").Replace("&Query=", "?q=");
            return webUrlDto;            
        }

        public DeeplinkDto WebUrlToDeeplink(WebUrlDto webUrlObj)
        {
            Uri unparsedUrl = new Uri(webUrlObj.webUrl);

            string query = unparsedUrl.Query;
            var qParams = HttpUtility.ParseQueryString(query);

            DeeplinkDto deeplinkDto = new DeeplinkDto();
            deeplinkDto.deeplink = $"{LinkInfoHelper.siteWeb}?Page=Search&{qParams.ToString().Replace("q=","Query=")}";

            return deeplinkDto;
        }
    }
}
