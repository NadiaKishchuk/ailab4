using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapi.DTO;

namespace webapi.Entity
{
    public class Symptom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Disease> Diseases { get; set; } = new List<Disease>();
        public List<User> Users { get; set; } = new List<User>();

        public Symptom() { }    
        public Symptom (SymptomDTO  symptomDTO) { 
            Id = symptomDTO.Id;
            Name = symptomDTO.Name;
        }
    }
}
