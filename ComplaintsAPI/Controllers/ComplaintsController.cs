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
        public ActionResult<string> Set([FromBody] ComplaintsModel complaints) {
            return _complaintsService.Set(complaints);
        }
        [HttpPost("get")]
        public ActionResult<List<ComplaintsModel>> Get()
        {
            return _complaintsService.Get();
        }
        [HttpPost("getwithid")]
        public ActionResult<ComplaintsModel> Getwithid([FromBody] string TicketID)
        {
            return _complaintsService.GetSpecific(TicketID);
        }
        [HttpPost("update")]
        public ActionResult<ComplaintsModel> Update([FromBody] ComplaintsModel complaints)
        {
            return _complaintsService.Update(complaints);
        }
        [HttpPost("delete")]
        public ActionResult<string> Delete([FromBody] string TicketID)
        {
            return _complaintsService.Delete(TicketID);
        }
        //TODO finish the others controllers...
    }
}
