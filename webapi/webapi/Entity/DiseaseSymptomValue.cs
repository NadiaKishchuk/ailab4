using System.ComponentModel.DataAnnotations;

namespace webapi.Entity
{
    public class DiseaseSymptomValue
    {
        [Required]
        public int DiseaseId { get; set; }
        [Required]
        public int SymptomId { get; set; }
        [Required]
        public int Value { get; set; }

        public Disease Disease { get; set; }    
        public Symptom Symptom { get; set; }
    }
}
