using System;
using System.Collections.Generic;
using System.Text;
using Trendyol.LinkConverter.Application.Interfaces;
using Trendyol.LinkConverter.Domain;

namespace Trendyol.LinkConverter.Application.Helpers
{
    /*
     * Handles all other link conversions that are not handled.
     */

    public class GeneralLinkConverter : ILinkConverter
    {
        public WebUrlDto DeeplinkToWebUrl(DeeplinkDto deeplinkObj)
        {
            return new WebUrlDto() { webUrl = LinkInfoHelper.siteWeb };
        }

        public DeeplinkDto WebUrlToDeeplink(WebUrlDto webUrlObj)
        {
            return new DeeplinkDto() { deeplink = LinkInfoHelper.siteDeeplink + "?Page=Home" };
        }
    }
}
