using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trendyol.LinkConverter.Application;
using Trendyol.LinkConverter.Contracts;
using Trendyol.LinkConverter.Domain;

namespace Trendyol.LinkConverter.API.Controllers
{
    [Route("api/deeplink")]
    [ApiController]
    public class DeeplinkConverterController : ControllerBase, IDeeplinkConverterController
    {
        private readonly ILogger _logger;
        private IConverterHelper _helper;

        public DeeplinkConverterController(ILogger<DeeplinkConverterController> logger, IConverterHelper converterHelper)
        {
            _logger = logger;
            _helper = converterHelper;
        }

        [HttpGet]
        public WebUrlDto GetWebUrl([FromBody] DeeplinkDto rDto)
        {
            return _helper.ConvertDeeplinkToWebLink(rDto);
        }
    }
}
