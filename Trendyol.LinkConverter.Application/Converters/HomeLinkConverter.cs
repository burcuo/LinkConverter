using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Trendyol.LinkConverter.Application.Interfaces;
using Trendyol.LinkConverter.Domain;

namespace Trendyol.LinkConverter.Application.Helpers
{
    /*
     * Handles conversion of both deeplink and weburl related with Home Page
     */

    public class HomeLinkConverter : ILinkConverter
    {
        private Dictionary<int, string> sectionMap = new Dictionary<int, string>();

        public HomeLinkConverter()
        {
            sectionMap.Add(1, "Kadın");
            sectionMap.Add(2, "Erkek");
            sectionMap.Add(3, "Süpermarket");
            sectionMap.Add(4, "Çocuk");
        }

        public WebUrlDto DeeplinkToWebUrl(DeeplinkDto deeplinkObj)
        {
            string sectionId = Regex.Match(deeplinkObj.deeplink, @"(?<=SectionId=)\d+").Value;

            string sectionName = sectionMap[Convert.ToInt32(sectionId)];

            WebUrlDto webUrlDto = new WebUrlDto();
            webUrlDto.webUrl = $"{LinkInfoHelper.siteWeb}/butik/liste/{ReplaceTurkishChars(sectionName).ToLower(new CultureInfo("en-US", false))}";

            return webUrlDto;
        }

        public DeeplinkDto WebUrlToDeeplink(WebUrlDto webUrlObj)
        {
            string sectionName = Regex.Match(webUrlObj.webUrl, @"(?<=\/butik\/liste\/)\w+").Value;
            int sectionId = sectionMap.FirstOrDefault(x => ReplaceTurkishChars(x.Value).ToUpper() == sectionName.ToUpper()).Key;

            DeeplinkDto deeplinkDto = new DeeplinkDto();
            deeplinkDto.deeplink = $"{LinkInfoHelper.siteDeeplink}?Page=Home&SectionId={sectionId}";

            return deeplinkDto;
        }

        private string ReplaceTurkishChars(string text)
        {
            text = text.Replace("ı", "i");
            text = text.Replace("ö", "o");
            text = text.Replace("ü", "u");
            text = text.Replace("ş", "s");
            text = text.Replace("ğ", "g");
            text = text.Replace("ç", "c");

            text = text.Replace("Ü", "U");
            text = text.Replace("İ", "I");
            text = text.Replace("Ö", "O");
            text = text.Replace("Ü", "U");
            text = text.Replace("Ş", "S");
            text = text.Replace("Ğ", "G");
            text = text.Replace("Ç", "C");
            return text;
        }
    }
}
