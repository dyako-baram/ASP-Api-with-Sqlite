using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;
using Api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController:ControllerBase
    {
        private readonly ISqliteRepository _sqlite;

        public PersonController(ISqliteRepository sqlite)
        {
            _sqlite = sqlite;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result=await _sqlite.GetAllPerson();
            if(result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var result=await _sqlite.GetPerson(id);
             if(result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody]PersonTable person)
        {
            
            if(ModelState.IsValid==false)
            {
                return BadRequest();
            }
            await _sqlite.SavePerson(person);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] PersonTable person)
        {
             if(person==null)
            {
                return BadRequest();
            }
            await _sqlite.UpdatePerosn(person);
            return Ok();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            await _sqlite.DeletePerson(id);
            return Ok();
        }
    }
}