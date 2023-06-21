using ComplaintsAPI.Model;
using ComplaintsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ComplaintsAPI.Controllers
{
    [ApiController]
    [Route("Complaints")]
    public class ComplaintsController:ControllerBase
    {
        private readonly IComplaintsService _complaintsService;
        public ComplaintsController(IComplaintsService complaints) {
            _complaintsService= complaints;

        }
        [HttpPost("set")]
        public ActionResult<string> set([FromBody] ComplaintsModel complaints) {
            return _complaintsService.Set(complaints);
        }
        //TODO finish the others controllers...
    }
}
