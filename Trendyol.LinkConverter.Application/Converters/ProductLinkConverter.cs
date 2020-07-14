using System;
using System.Text.RegularExpressions;
using System.Web;
using Trendyol.LinkConverter.Application.Interfaces;
using Trendyol.LinkConverter.Domain;

namespace Trendyol.LinkConverter.Application.Helpers
{
    /*
     * Handles conversion of both deeplink and weburl related with Product Detail Page
     */

    public class ProductLinkConverter : ILinkConverter
    {
        public WebUrlDto DeeplinkToWebUrl(DeeplinkDto deeplinkObj)
        {
            string contentId = Regex.Match(deeplinkObj.deeplink, @"(?<=&ContentId=)\d+").Value;
            string boutiqueId = Regex.Match(deeplinkObj.deeplink, @"(?<=&CampaignId=)\d+").Value;
            string merchantId = Regex.Match(deeplinkObj.deeplink, @"(?<=&MerchantId=)\d+").Value;

            string c_link = $"{LinkInfoHelper.siteWeb}/brand/name-p-{contentId}";

            if (!string.IsNullOrEmpty(boutiqueId))
            {
                c_link += $"?boutiqueId={boutiqueId}"; 
            }

            if (!string.IsNullOrEmpty(merchantId))
            {
                c_link += (c_link.Contains("?") ? "&" : "?") + $"merchantId={merchantId}";
            }

            WebUrlDto webUrlDto = new WebUrlDto() { webUrl = c_link };

            return webUrlDto;
        }

        public DeeplinkDto WebUrlToDeeplink(WebUrlDto webUrlObj)
        {
            string contentId = Regex.Match(webUrlObj.webUrl, @"(?<=-p-)\d+").Value;

            Uri unparsedUrl = new Uri(webUrlObj.webUrl);
            var queryParams = HttpUtility.ParseQueryString(unparsedUrl.Query);

            string boutiqueId = queryParams["boutiqueId"];
            string merchantId = queryParams["merchantId"];

            string c_link = $"{LinkInfoHelper.siteDeeplink}?Page=Product&ContentId={contentId}";

            c_link += (boutiqueId != null ? $"&CampaignId={boutiqueId}" : "") + (merchantId != null ? $"MerchantId={merchantId}":"");

            DeeplinkDto deeplinkDto = new DeeplinkDto() { deeplink = c_link };
            return deeplinkDto;
        }
    }
}
