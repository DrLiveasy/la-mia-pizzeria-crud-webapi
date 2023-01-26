using La_Mia_Pizzeria_1.DataBase;
using La_Mia_Pizzeria_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace La_Mia_Pizzeria_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? search)
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> pizzas = new List<Pizza>();

                if (search is null || search == "")
                {
                    pizzas = db.Pizzas.Include(pizza => pizza.Ingredientis).Include(pizza => pizza.Categoria).ToList<Pizza>();
                }
                else
                {
                    search = search.ToLower();

                    pizzas = db.Pizzas.Where(pizza => pizza.Nome.ToLower().Contains(search))
                        .Include(pizza => pizza.Ingredientis)
                        .Include(pizza => pizza.Categoria).ToList<Pizza>();
                }

                return Ok(pizzas);

            }


        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizzas = db.Pizzas.Where(pizza => pizza.Id == id).Include(pizza => pizza.Ingredientis).Include(pizza => pizza.Categoria).FirstOrDefault();

                if (pizzas is null)
                {
                    return NotFound("La pizza con questo id non è stato trovata!");
                }

                return Ok(pizzas);
            }
        }

        public IActionResult Dettaglio(int id)
        {


            using (PizzaContext db = new PizzaContext())

            {
                Pizza pizzas = db.Pizzas.Where(pizza => pizza.Id == id).Include(pizza => pizza.Ingredientis).Include(pizza => pizza.Categoria).FirstOrDefault();



                if (pizzas != null)
                {
                    return Ok(pizzas);
                }

                return NotFound("La pizza con l'id cercato non esiste!");

            }



        }
    }
}

