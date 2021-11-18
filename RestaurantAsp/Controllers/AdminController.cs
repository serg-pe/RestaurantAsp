using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestaurantAsp.Data;
using RestaurantAsp.Models;
using RestaurantAsp.Views.Admin.Data;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAsp.Controllers
{
    [Route("admin/")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [Route("")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("ingredients/")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult RenderIngredients()
        {
            var ingredients = _context.Ingredients.ToList();
            return View(ingredients);
        }

        [Route("ingredients/create/")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult CreateIngredient()
        {
            return View("Ingredient", null);
        }

        [Route("ingredients/change/{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult ChangeIngredient(int id)
        {
            var ingredient = _context.Ingredients.Find(id);
            return View("Ingredient", ingredient);
        }

        [HttpPost]
        [Route("ingredients/save/")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult SaveIngredient([FromBody]Ingredient ingredient)
        {
            if (ingredient.Id != 0)
            {
                var targetIngredient = _context.Ingredients.Find(ingredient.Id);
                targetIngredient.Denomination = ingredient.Denomination;
                _context.SaveChanges();
            
                return new JsonResult(new {message="Объект изменён"});
            }
            
            var isExists = _context.Ingredients.Any(i => i.Denomination.Equals(ingredient.Denomination));
            
            if (isExists)
                return new JsonResult(new {message="Объект уже создан"});

            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
            
            return new JsonResult(new {message="Объект успешно добавлен"});    
        }
        
        [Route("ingredients/delete/{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult DeleteIngredient(int id)
        {
            var ingredient = _context.Ingredients.Find(id);
            _context.Ingredients.Remove(ingredient);
            _context.SaveChanges();
            return new JsonResult(new {message = "Объект успешно удалён"});
        }

        [Route("dishes/")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult RenderDishes()
        {
            var dishesCompositions = new Dictionary<Dish, IList<Ingredient>>();
            var dishes = _context.Dishes.ToList();
            
            foreach (var dish in dishes)
            {
                var dishesIngredients = _context.Compositions.Select(o => o).Where(o => o.DishId == dish.Id);
                var ingredients = new List<Ingredient>();
                foreach (var dishIngredient in dishesIngredients)
                    ingredients.Add(_context.Ingredients.Single(o => o.Id == dishIngredient.IngredientId));
                
                dishesCompositions.Add(dish, ingredients);
            }
            
            return View(dishesCompositions);
        }
        
        [Route("dishes/create/")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult CreateDish()
        {
            var dish = new Dish()
            {
                Composition = new List<DishIngredient>(),
                Denomination = "",
                Id = 0,
                Price = new decimal(0.00),
                Quantity = 1,
                Unit = UnitsNames.GetUnitName(Units.Kg)
            };
            
            var dishData = new DishData
            {
                Ingredients = _context.Ingredients.ToList(), 
                Dish = dish
            };
            
            return View("Dish", dishData);
        }

        [Route("dishes/change/{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult ChangeDish(int id)
        {
            var dish = _context.Dishes
                .Include(d => d.Composition)
                .ThenInclude(di => di.Ingredient)
                .First(d => d.Id == id);
            
            var dishData = new DishData
            {
                Ingredients = _context.Ingredients.ToList(), 
                Dish = dish
            };

            return View("Dish", dishData);
        }

        [HttpPost]
        [Route("dishes/save/")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult SaveDish([FromBody]JObject jDish)
        {
            var dish = new Dish();
            
            var dishDict = jDish.ToObject<IDictionary<string, object>>();

            dish.Id = (int) jDish["id"];
            dish.Denomination = dishDict["denomination"].ToString();
            dish.Price = decimal.Parse(dishDict["price"].ToString());
            dish.Unit = dishDict["unit"].ToString();
            dish.Quantity = decimal.Parse(dishDict["quantity"].ToString());
            dish.Composition = new List<DishIngredient>();
            var composition = JsonConvert.DeserializeObject<int[]>(dishDict["composition"].ToString());
            foreach (var id in composition)
            {
                var ingredient = _context.Ingredients.Find(id);
                var dishIngredient = new DishIngredient {Dish = dish, Ingredient = ingredient};
                dish.Composition.Add(dishIngredient);
            }

            if (dish.Id != 0)
            {
                var targetDish = _context.Dishes
                    .Include(d => d.Composition)
                    .ThenInclude(di => di.Ingredient)
                    .First(d => d.Id == dish.Id);
                targetDish.Composition.Clear();
                targetDish.Denomination = dish.Denomination;
                targetDish.Unit = dish.Unit;
                targetDish.Composition = dish.Composition;
                targetDish.Price = dish.Price;
                targetDish.Quantity = dish.Quantity;

                _context.SaveChanges();
                return new JsonResult(new {message="Объект изменён"}); 
            }
            
            var isCreated = _context.Dishes.Any(d => d.Denomination.Equals(dish.Denomination));
            if (isCreated) 
                return new JsonResult(new {message="Объект уже создан"});

            _context.Dishes.Add(dish);
            _context.SaveChanges();
                
            return new JsonResult(new {message = "Объект успешно добавлен"});
        }

        [Route("dishes/delete/{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult DeleteDish(int id)
        {
            var dish = _context.Dishes.Find(id);
            _context.Dishes.Remove(dish);
            _context.SaveChanges();
            return new JsonResult(new {message = "Объект успешно удалён"});
        }

        [Route("orders/")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult RenderOrders()
        {
            var orders = _context.Orders
                .Include(order => order.Customer)
                .Include(order => order.OrderPositions)
                .ThenInclude(position => position.Dish)
                .OrderByDescending(o => o.IsActive)
                .ToList();

            return View(orders);
        }

        [Route("orders/done/{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult SetOrderDone(int id)
        {
            _context.Orders.Find(id).IsActive = false;
            _context.SaveChanges();
            
            return new JsonResult(new {message = "Выполнено"});
        }
    }
}
