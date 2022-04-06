using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;

namespace Pizzas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Pizza> GetAll()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Pizza
            {
                Descripcion = "Con salsa de tomate y queso",
                Id = 1,
                Importe = 300,
                LibreGluten = false,
                Nombre = "Muzza Individual"
            })
            .ToArray();
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int Id){
            Pizza Pizza1 = BD.ConsultaPizza(Id);
            if(Pizza1 == null){return NotFound();}
            return Ok(Pizza1);
}
       
        [HttpPost]
        public IActionResult Create(Pizza pizza){
            BD.Create(pizza);
            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza){
            BD.Update(pizza);
            return Ok();
        }
       
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id){
            BD.Delete(id);
            return Ok();
        }
    }
}
