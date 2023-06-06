using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlinePizzaAPI.Models;
using OnlinePizzaAPI.Services;

namespace OnlinePizzaAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PizzaController : Controller
    {
        private readonly PizzaServices _services;

        public PizzaController(PizzaServices services)
        {
            _services = services;
        }


        [HttpGet]
        public async Task<List<Pizza>> Get()
        {
            var pizza = await _services.GetallAsync();

            //if (pizza == null)
            //    return NotFound().;

            return pizza;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Pizza>>> GetAsync(int id)
        {
            var pizza = await _services.GetAsync(id);

            if (pizza == null)
                return NotFound();

            return Ok(pizza);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Pizza pizza)
        {
           await _services.CreateAsync(pizza);

            return Ok();
        }


        [HttpDelete]
        public async Task<ActionResult<Pizza>> RemoveAsync(int id)
        {
            var book = await _services.GetAsync(id);  
            
            if (book == null)
                return NotFound();

            await _services.RemoveAsync(id);

            return Ok();
        }

        [HttpPut("id")]
        public async Task<ActionResult<Pizza>> updateAysnc(int id, Pizza pizza)
        {
            var book = await _services.GetAsync(id);

            if (book == null)
                return NotFound();

            pizza.Key = book.Key;
            pizza._id = book._id;

            await _services.UpdateAsync(id, pizza);

            return NoContent();

        }

    }
}
