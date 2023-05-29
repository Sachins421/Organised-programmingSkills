using Microsoft.AspNetCore.Mvc;
using OnlinePizzaAPI.Models;
using OnlinePizzaAPI.Services;

namespace OnlinePizzaAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PizzaController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaServices.Get(id);

            if (pizza == null)
                return NotFound();

            return Ok(pizza);
        }

        [HttpPost]
        public ActionResult<Pizza> Create([FromBody] Pizza pizza)
        {
            PizzaServices.add(pizza);

            return Ok();
        }
        [HttpDelete]
        public ActionResult<Pizza> Remove(int id)
        {
            PizzaServices.Delete(id);

            return Ok();
        }

        [HttpPut]
        public ActionResult<Pizza> update(Pizza pizza)
        {
            PizzaServices.Update(pizza);

            return Ok();

        }

    }
}
