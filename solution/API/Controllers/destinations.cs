using Microsoft.AspNetCore.Mvc;
using Infraestructure.Models;
using LearningCenter.API.Input;

using AutoMapper;
using LearningCenter.Domain.Interfaces;
using LearningCenter.Infraestructure.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860



namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class destinations : ControllerBase
    {
        //inyeccion
        private IDestinationDomain _destinationDomain;
 
        private IMapper _mapper;

        public destinations(IDestinationDomain destinationDomain, IMapper mapper)
        {
            _destinationDomain = destinationDomain;
            _mapper = mapper;
        }    

        // LECTURA ES DIRECTO ENTRE EL API Y LA INFRAESTRUCTURA


   


        // POST api/<Tutorial>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DestinationInput input)
        {

            if(ModelState.IsValid) {

         
                
                var destination = _mapper.Map<DestinationInput, Destination>(input);
               
                var result= await _destinationDomain.CreateAsync(destination);

                return result ? StatusCode(201) : StatusCode(500);
            }
            else
            {
                return StatusCode(400);
            }
        }

     
    }
}
