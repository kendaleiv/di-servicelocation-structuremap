using Core;
using System.Web.Http;

namespace Web.Controllers
{
    public class ServiceIdController : ApiController
    {
        private readonly IService _service;

        public ServiceIdController(IService service)
        {
            _service = service;
        }

        public string Get()
        {
            return "ServiceId: " + _service.Id;
        }
    }
}
