using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trendyol.LinkConverter.Application;
using Trendyol.LinkConverter.Domain;

namespace Trendyol.LinkConverter.API.Controllers
{
    [Route("api/shortlink")]
    [ApiController]
    public class ShortLinkController : ControllerBase
    {
        private readonly ILogger _logger;
        private IShortLinkConverter _converter;

        public ShortLinkController(ILogger<ShortLinkController> logger, IShortLinkConverter converter)
        {
            _logger = logger;
            _converter = converter;
        }

        [HttpGet]        
        public LinkDto Get([FromBody]ShortLinkDto shortlink)
        {
            return _converter.GetLinks(shortlink);
        }

        [HttpGet]
        [Route("[action]")]
        public ShortLinkDto GetByDeepLink([FromBody] DeeplinkDto deeplinkDto)
        {
            return _converter.GetShortLink(deeplinkDto);
        }

        [HttpGet]
        [Route("[action]")]
        public ShortLinkDto GetByWebUrl([FromBody] WebUrlDto webUrlDto)
        {
            return _converter.GetShortLink(webUrlDto);
        }
    }
}
