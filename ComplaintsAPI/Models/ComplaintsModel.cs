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
        public string Channel { get; set; } = string.Empty;
        [BsonElement]
        [RegularExpression("^(Produto com defeito|Produto não chegou |Valor3)$", ErrorMessage = "The value of Type only accepts 'Valor1', 'Valor2' ou 'Valor3'.")]
        public Enum Type { get; set; }
        [BsonElement]
        [RegularExpression("^(Pendente|Encaminhado|Finalizado)$", ErrorMessage = "The value of Type only accepts 'Valor1', 'Valor2' ou 'Valor3'.")]
        public string Description { get; set; } = string.Empty;
        [Range(1, 3, ErrorMessage = "The value of level must be between 1 and 3.")]
        [BsonElement]
        public Enum Level { get; set; }
        [BsonElement]

        public string? Resolution { get; set; }

       public List<string> Photos { get; set; }= new List<string>();
    }
}
