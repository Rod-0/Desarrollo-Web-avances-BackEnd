using Microsoft.AspNetCore.Mvc;
using Infraestructure.Models;
using LearningCenter.API.Input;
using LearningCenter.API.Response;
using AutoMapper;
using LearningCenter.Domain.Interfaces;
using LearningCenter.Infraestructure.Interfaces;
using LearningCenter.Infraestructure.Models;
using LearningCenter.Infraestructure;
using LearningCenter.Domain;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize("admin")]
        [HttpGet(Name = "GetTutorials")]
        public async Task<List<TutorialResponse>> Get()
        {
            var result= await _tutorialInfraestructura.GetAll();
            var list= _mapper.Map<List<Tutorial>, List<TutorialResponse>>(result);
            return list;
        }

        [HttpGet("GetByName")]
        public async Task<List<TutorialResponse>> Get(string name)
        {
            var result = await _tutorialInfraestructura.GetByName(name);
            var list = _mapper.Map<List<Tutorial>, List<TutorialResponse>>(result);
            return list;


        }

        // GET api/<Tutorial>/5
        [HttpGet("{id}",Name ="Get")]
        public async Task<TutorialResponse> Get(int id)
        {
            var tutorialFound = await _tutorialInfraestructura.GetbyId(id);
            var result = _mapper.Map<Tutorial, TutorialResponse>(tutorialFound);

            return result;
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
        public async Task Put(int id, [FromBody] TutorialInput input)
        {
            if (ModelState.IsValid)
            {
                var tutorial = _mapper.Map<TutorialInput, Tutorial>(input);


                await _tutorialDomain.Update(id,tutorial);

            }
            else
            {

                StatusCode(400);
            }
        }

        // DELETE api/<Tutorial>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _tutorialDomain.Delete(id);
        }
    }
}
