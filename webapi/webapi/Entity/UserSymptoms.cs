using System.ComponentModel.DataAnnotations;

namespace webapi.Entity
{
    public class UserSymptoms
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int SymptomId { get; set; }

        public User User { get; set; }
        public Symptom Symptom { get; set; }
    }
}
