using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using webapi.Entity;

namespace webapi.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        public List<SymptomDTO> Symptoms { get; set; } = new List<SymptomDTO>();

        public UserDTO() { }
        public UserDTO(User user)
        {
            Id = user.Id;
            FullName = user.FullName;
            Login = user.Login;
            Password = user.Password;
            Role = user.Role;
            Symptoms = user.Symptoms.Select(s => new SymptomDTO(s)).ToList();
        }
    }
}
