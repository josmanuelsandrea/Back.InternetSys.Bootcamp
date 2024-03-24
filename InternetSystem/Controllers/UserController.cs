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
        private readonly UserRepository UserR;
        private readonly InternetsysContext _db;

        public UserController()
        {
            _db = new InternetsysContext();
            UserR = new UserRepository(_db);
        }

        // GET: api/<User>
        [HttpGet]
        public List<User> Get()
        {
            return UserR.GetUsers();
        }

        // GET api/<User>/5
        [HttpGet("{id}")]
        public GenericResponse<User> Get(int id)
        {
            // When we use generic responses, we have default response messages, status code and data, everytime we need to use
            // generic responses WE NEED to setup the responses before sending it to the view in case there is not error.
            // please check the GenericResponse code to check out the default values.
            var genericResponse = new GenericResponse<User>();
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
        public void Post([FromBody] )
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
