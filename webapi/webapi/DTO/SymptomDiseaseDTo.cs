using System.ComponentModel.DataAnnotations;

namespace webapi.DTO
{
    public class SymptomDiseaseDTO
    {
        public int DiseaseId { get; set; }
        public int SymptomId { get; set; }
        public int Value { get; set; }
    }
}
