using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ComplaintsAPI.Model
{
    public class ComplaintsModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TicketID { get; set; } = String.Empty;
        [BsonElement]
        public string TicketUsername { get; set; } = string.Empty;
        [RegularExpression("^(Valor1|Valor2|Valor3)$", ErrorMessage = "The value of Type only accepts 'Valor1', 'Valor2' ou 'Valor3'.")]
        [BsonElement]
        public string Type { get; set;} = string.Empty;
        [BsonElement]
        public string Description { get; set; } = string.Empty;
        [Range(1, 3, ErrorMessage = "The value of level must be between 1 and 3.")]
        [BsonElement]
        public string Level { get; set; } = string.Empty;
        [BsonElement]
        public string? Resolution { get; set; }
        [BsonElement]
        public bool IsAnswered;
    }
}
