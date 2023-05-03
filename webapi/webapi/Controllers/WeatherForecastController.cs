using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data;
using webapi.DTO;
using webapi.Entity;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [EnableCors]
    public class Lab4Controller : ControllerBase
    {

        public ClinicDbContext Context { get; set; }

        public Lab4Controller(ClinicDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetUsers() {
            return Context.Users.Select(u=>new UserDTO(u)).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<SymptomDTO>> GetSymptoms()
        {
            return Context.Symptoms.Select(s => new SymptomDTO(s)).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<DiseaseDTO>> GetDiseases()
        {

            var diseases =  Context.Set<Disease>().AsQueryable().AsNoTracking().ToList();
            var diseasesDto = new List<DiseaseDTO>();
            foreach(Disease d in diseases)
            {
                var curDis = new DiseaseDTO() { Id = d.Id, Description = d.Description, Name = d.Name};
                curDis.SymptomDiseasesValue = Context.Set<DiseaseSymptomValue>().Where(ds => ds.DiseaseId == d.Id)
                    .Select(ds => new SymptomDiseaseDTO() { DiseaseId = ds.DiseaseId,
                        SymptomId = ds.SymptomId, Value = ds.Value});
                diseasesDto.Add(curDis);
            }
            return Ok(diseasesDto);
        }

        [HttpPost]
        public ActionResult<User> Login([FromBody]LoginDTO loginPassword)
        {
            var user = Context.Users
                .FirstOrDefault(u => u.Password == loginPassword.Password
                    && u.Login == loginPassword.Login);
            if (user != null)
            {
                return Ok(user);
            }

            return BadRequest("no such user");
        }

        [HttpPost]
        public ActionResult<User> Auth([FromBody] UserDTO newUser)
        {
            var user = Context.Users
                .FirstOrDefault(u => u.Password == newUser.Password
                    && u.Login == newUser.Login);
            if (user != null)
            {
                return BadRequest("User with such password or login already exist");
            }
            try
            {
                user = new User() {
                    FullName = newUser.FullName,
                    Login = newUser.Login, Password = newUser.Password, Role = newUser.Role };
                Context.Users.Add(user);
                Context.SaveChanges();
                return Ok(user);
            }
            catch
            {
                return  BadRequest("Error while adding");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Disease>> GetDisease()
        {
            return Context.Diseases.ToList();
        }

        [HttpDelete]
        public ActionResult<Disease> DeleteDisease(int idDisease)
        {
            try
            {
                var deleted = Context.Diseases.FirstOrDefault(d => d.Id == idDisease);
                if (deleted == null)
                {
                    return BadRequest("no disease with such id");
                }
                Context.Diseases.Remove(deleted);
                Context.SaveChanges();
                return deleted;
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult<Symptom> DeleteSymptoms(int idSymptom)
        {
            try
            {
                var deleted = Context.Symptoms.FirstOrDefault(d => d.Id == idSymptom);
                if (deleted == null)
                {
                    return BadRequest("no disease with such id");
                }
                Context.Symptoms.Remove(deleted);
                Context.SaveChanges();
                return deleted;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Symptom> AddSymptoms(SymptomDTO symptom)
        {
            try
            {
                var newSymp = new Symptom() { Name = symptom.Name };
                Context.Symptoms.Add(newSymp);
                Context.SaveChanges();
                return newSymp;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Disease> AddDisease(DiseaseDTO disease)
        {
            try
            {
                var newDisease = new Disease() { Name = disease.Name };
                Context.Diseases.Add(newDisease);
                Context.SaveChanges();
                return newDisease;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> UpdateDiseaseSymptomValues(IEnumerable<SymptomDiseaseDTO> symptomDiseases)
        {
            try
            {
                Context.Set<DiseaseSymptomValue>().RemoveRange(Context.Set<DiseaseSymptomValue>());

                var savingDeleteding = Context.SaveChangesAsync();

                List<DiseaseSymptomValue> newValues = symptomDiseases
                    .Select(x => new DiseaseSymptomValue() { DiseaseId = x.DiseaseId, SymptomId = x.SymptomId, Value = x.Value }).ToList();

                savingDeleteding.Wait();
                Context.Set<DiseaseSymptomValue>().AddRange(newValues);
                await Context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}