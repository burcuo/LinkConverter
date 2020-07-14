using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trendyol.LinkConverter.Application.Helpers
{
    /*
     * Generates short link
     */

    public class ShortLinkHelper
    {
        private static readonly string charsToUse = "abcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly int sLinkMaxLength = 10;
        
        public static string GenerateShortLink()
        {
            string safeLink = string.Empty;
            char[] randominizedArr = charsToUse.ToCharArray().ToList().OrderBy(x => new Random().Next()).ToArray();
            string randomStr = new string(randominizedArr);

            safeLink = randomStr.Substring(new Random().Next(0, charsToUse.Length), new Random().Next(3, sLinkMaxLength));
            return safeLink;
        }
    }
}
