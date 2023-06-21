using ComplaintsAPI.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
namespace ComplaintsAPI.Services
{
    public class ComplaintsService : IComplaintsService
    {
        private readonly IMongoCollection<ComplaintsModel> _complaints;
        public ComplaintsService(IComplaintsDataBaseSettings dataBaseSettings, IMongoClient mongoClient) 
        {
            var database =mongoClient.GetDatabase(dataBaseSettings.DatabaseName);
            _complaints= database.GetCollection<ComplaintsModel>(dataBaseSettings.CollectionName);
            
        }

        public ActionResult<List<ComplaintsModel>> Get()
        {
           var complaintsList= _complaints.FindSync(complaint =>true).ToList();
            return new OkObjectResult(complaintsList);
        }
        public ActionResult<ComplaintsModel> GetSpecific(string ticketId)
        {
            var complaint = _complaints.FindSync(complaint => complaint.TicketID== ticketId).FirstOrDefault();
            return new OkObjectResult(complaint);
        }
        public ActionResult<string> Set(ComplaintsModel complaint)
        {
            try { 
                _complaints.InsertOne(complaint);
                return new OkObjectResult("Succesful Insertion.");
            }
            catch {
                return new UnprocessableEntityObjectResult("Something went wrong! The data is not valid");
            }
        }
        public ActionResult<ComplaintsModel> Update(ComplaintsModel complaint)
        {
            try
            {
                _complaints.ReplaceOne(Complaint => Complaint.TicketID == complaint.TicketID, complaint);
                return new OkObjectResult("Succesful Update.");
            }
            catch
            {
                return new UnprocessableEntityObjectResult("Something went wrong! The data is not valid");
            }
        }
        public ActionResult<string> Delete(string ticketId)
        {
            _complaints.DeleteOne(complaint => complaint.TicketID == ticketId);
            return new OkObjectResult("Succesful Deletion.");
        }
    }
}
