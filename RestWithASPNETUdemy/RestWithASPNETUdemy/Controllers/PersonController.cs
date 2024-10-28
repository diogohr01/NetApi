using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;

namespace RestWithASPNETUdemyModel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonService __personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            __personService = personService;    
        }

        [HttpGet]
        public IActionResult Get()
        {
          
            return Ok(__personService.FindAll());
        }


        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = __personService.FindByID(id) ;
            if(person == null){
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            
            if(person == null){
                return BadRequest();
            }
            return Ok(__personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            
            if(person == null){
                return BadRequest();
            }
            return Ok(__personService.Update(person));
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
             __personService.Delete(id) ;

            return NoContent();
        }
    }
}