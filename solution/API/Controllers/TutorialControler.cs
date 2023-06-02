using Microsoft.AspNetCore.Mvc;
using Infraestructure;
using Domain;
using Infraestructure.Models;
using LearningCenter.API.Input;
using LearningCenter.API.Response;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860



namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialControler : ControllerBase
    {
        //inyeccion
        private ITutorialDomain _tutorialDomain;
        private ITutorialInfraestructure _tutorialInfraestructura;
        private IMapper _mapper;

        public TutorialControler(ITutorialDomain tutorialDomain, ITutorialInfraestructure tutorialInfraestructura, IMapper mapper)
        {
            _tutorialDomain = tutorialDomain;
            _tutorialInfraestructura = tutorialInfraestructura;
            _mapper = mapper;
        }    

        // LECTURA ES DIRECTO ENTRE EL API Y LA INFRAESTRUCTURA


        // GET: api/<Tutorial>
        [HttpGet(Name = "GetTutorials")]
        public async Task<List<TutorialResponse>> Get()
        {
            var result= await _tutorialInfraestructura.GetAll();
            var list= _mapper.Map<List<Tutorial>, List<TutorialResponse>>(result);
            return list;
        }

        [HttpGet("GetByName")]
        public List<Tutorial> Get(string name)
        {
            return _tutorialInfraestructura.GetByName(name);


        }

        // GET api/<Tutorial>/5
        [HttpGet("{id}",Name ="Get")]
        public Tutorial Get(int id)
        {
           return _tutorialInfraestructura.GetbyId(id);   
        }

        // POST api/<Tutorial>
        [HttpPost]
        public async Task PostAsync([FromBody] TutorialInput input)
        {

            if(ModelState.IsValid) {

                //temporal
                /*Tutorial tutorial = new Tutorial()
                {
                    Name = input.Name,
                    Description = input.Description
                };*/
                
                var tutorial = _mapper.Map<TutorialInput, Tutorial>(input);
               
                await _tutorialDomain.CreateAsync(tutorial);
            }
            else
            {
                StatusCode(400);
            }
        }

        // PUT api/<Tutorial>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TutorialInput input)
        {
            if (ModelState.IsValid)
            {
                Tutorial tutorial = new Tutorial()
                {
                    Name = input.Name,
                    Description = input.Description
                };
                _tutorialDomain.Update(id, tutorial);
            }
            else
            {
                StatusCode(400);
            }
        }

        // DELETE api/<Tutorial>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tutorialDomain.Delete(id);
        }
    }
}
