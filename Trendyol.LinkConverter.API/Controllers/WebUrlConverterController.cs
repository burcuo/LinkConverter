using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trendyol.LinkConverter.Application;
using Trendyol.LinkConverter.Contracts;
using Trendyol.LinkConverter.Domain;

namespace Trendyol.LinkConverter.API.Controllers
{
    [Route("api/weburl")]
    [ApiController]
    public class WebUrlConverterController : ControllerBase, IURLConverterController
    {
        private readonly ILogger _logger;
        private IConverterHelper _helper;

        public WebUrlConverterController(ILogger<WebUrlConverterController> logger, IConverterHelper converterHelper)
        {
            _logger = logger;
            _helper = converterHelper;
        }

        [HttpGet]
        public DeeplinkDto GetDeeplink(WebUrlDto rDto)
        {
            return _helper.ConvertWebLinkToDeeplink(rDto);
        }
    }
}
