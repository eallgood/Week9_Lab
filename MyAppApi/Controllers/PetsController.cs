using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Week4_Lab.Data;
using Week4_Lab.Data.Entities;

namespace Week9_Lab.Controllers
{
    [RoutePrefix("api/pets")]
    public class PetsController : ApiController
    {
        private AppDbContext _dbContext;

        public PetsController()
        {
            _dbContext = new AppDbContext();
        }

        [HttpGet]
        public IEnumerable<Pet> GetAllPets()
        {
            return _dbContext.Pets.ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetPet(int id)
        {
            var pet = _dbContext.Pets.FirstOrDefault((p) => p.Id == id);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }
    }
}