using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.DTO
{
    public class DiseaseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<SymptomDiseaseDTO> SymptomDiseasesValue { get; set; }
    }
}
