using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trendyol.LinkConverter.EntityFramework.Interfaces;
using Trendyol.LinkConverter.EntityFramework.Models;

namespace Trendyol.LinkConverter.EntityFramework.Repositories
{
    public class ShortLinkRepository : IShortLinkRepositorty
    {
        private readonly AppDbContext _context;

        public ShortLinkRepository(AppDbContext context)
        {
            _context = context;
        }

        public ShortLinkEntity GetLinks(string shortlink)
        {
            ShortLinkEntity shortLinkEntity = _context.ShortLinks.FirstOrDefault(x => x.ShortLink == shortlink && x.IsActive);

            return shortLinkEntity;
        }

        public ShortLinkEntity GetByDeeplink(string deeplink)
        {
            return _context.ShortLinks.FirstOrDefault(x => x.Deeplink == deeplink && x.IsActive);
        }

        public ShortLinkEntity GetByWebUrl(string webUrl)
        {
            return _context.ShortLinks.FirstOrDefault(x => x.WebUrl == webUrl && x.IsActive);
        }

        public ShortLinkEntity Insert(string deeplink, string weblink, string shortlink)
        {   
            ShortLinkEntity shortLinkEntity = new ShortLinkEntity()
            {
                ShortLink = shortlink,
                WebUrl = weblink,
                Deeplink = deeplink,
                CreationDate = DateTime.Now,
                IsActive = true
            };

            _context.ShortLinks.Add(shortLinkEntity);
            _context.SaveChanges();

            return shortLinkEntity;
        }
    }
}
