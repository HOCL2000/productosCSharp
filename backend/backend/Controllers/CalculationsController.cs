using backend.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        //// GET: api/<CalculationsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<CalculationsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<CalculationsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CalculationsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CalculationsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpPost("suma")]
        public IActionResult Suma([FromBody] CalculationsDTO request)
        {
            double result = request.Num1 + request.Num2;
            return Ok(result);
        }

        [HttpPost("substract")]
        public IActionResult Substract([FromBody] CalculationsDTO request)
        {
            double result = request.Num1 + request.Num2;
            return Ok(result);
        }

        [HttpPost("multiply")]
        public IActionResult Multiply([FromBody] CalculationsDTO request)
        {
            double result = request.Num1 * request.Num2;
            return Ok(result);
        }



        [HttpPost]
        public IActionResult Division([FromBody] CalculationsDTO request)
        {
            if(request.Num2 == 0) {
                return BadRequest("No se puede dividir entre 0");
            }

            double result = request.Num1 / request.Num2;
            return Ok(result);
        }
    }
}
