using La_Mia_Pizzeria_1.DataBase;
using La_Mia_Pizzeria_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace La_Mia_Pizzeria_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
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

            }

        }
    }
}
