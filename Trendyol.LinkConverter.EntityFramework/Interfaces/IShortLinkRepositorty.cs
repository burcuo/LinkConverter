using System;
using System.Collections.Generic;
using System.Text;
using Trendyol.LinkConverter.EntityFramework.Models;

namespace Trendyol.LinkConverter.EntityFramework.Interfaces
{
    public interface IShortLinkRepositorty
    {
        public ShortLinkEntity GetLinks(string shortlink);
        public ShortLinkEntity Insert(string deeplink, string weblink, string shortlink);

        public ShortLinkEntity GetByDeeplink(string deeplink);
        public ShortLinkEntity GetByWebUrl(string webUrl);
    }
}
