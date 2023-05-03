using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using webapi.Entity;

namespace webapi.DTO
{
    public class SymptomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SymptomDTO()
        {
            
        }

        public SymptomDTO(Symptom symptom)
        {
            Id = symptom.Id;
            Name = symptom.Name;
        }
    }
}
