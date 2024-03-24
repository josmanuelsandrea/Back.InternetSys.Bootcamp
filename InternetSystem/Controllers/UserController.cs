using Microsoft.AspNetCore.Mvc;
using InternetSystem.Repository;
using InternetSystem.DBModels;
using InternetSystem.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternetSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<User>
        [HttpGet]
        public List<User> Get()
        {
            var UserR = new UserRepository();
            return UserR.GetUsers();
        }

        // GET api/<User>/5
        [HttpGet("{id}")]
        public GenericResponse<User> Get(int id)
        {
            var genericResponse = new GenericResponse<User>();
            var UserR = new UserRepository();
            var userFound = UserR.GetUser(id);
            if (userFound != null)
            {
                genericResponse.statusCode = 200;
                genericResponse.data = userFound;
            }
            return genericResponse;
        }

        // POST api/<User>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<User>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<User>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
