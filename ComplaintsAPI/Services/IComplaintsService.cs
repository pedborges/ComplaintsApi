using ComplaintsAPI.Model;
using Microsoft.AspNetCore.Mvc;
namespace ComplaintsAPI.Services
{
    public interface IComplaintsService
    {
        ActionResult<List<ComplaintsModel>> Get();
        ActionResult<ComplaintsModel> GetSpecific(string TicketId);
        ActionResult<string> Set(ComplaintsModel complaint);
        ActionResult<ComplaintsModel> Update(ComplaintsModel complaint);
        ActionResult<string> Delete(string idTicketId);
    }
}
