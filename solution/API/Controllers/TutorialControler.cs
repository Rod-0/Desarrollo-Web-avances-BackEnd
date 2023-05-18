using Microsoft.AspNetCore.Mvc;
using Infraestructure;
using Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860



namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialControler : ControllerBase
    {
        private ITutorialDomain _tutorialDomain;

        public TutorialControler(ITutorialDomain tutorialDomain)
        {
            _tutorialDomain = tutorialDomain;
        }    

        // GET: api/<Tutorial>
        [HttpGet(Name = "GetTutorials")]
        public IEnumerable<string> Get()
        {
            return _tutorialDomain.GetAll();

            
        }

        // GET api/<Tutorial>/5
        [HttpGet("{id}",Name ="Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Tutorial>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Tutorial>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Tutorial>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
