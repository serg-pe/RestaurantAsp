using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestaurantAsp.Data;
using RestaurantAsp.Models;

namespace RestaurantAsp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private const int DishesPerPage = 10;

        public HomeController(ApplicationDbContext dbContext)
        {
            this._context = dbContext;
        }
        
        [Route("home/"), Route("/")]
        public IActionResult Index()
        {
            return View();
        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
//        }

        [Route("menu/")]
        public IActionResult RenderMenu()
        {
            var dishes = _context.Dishes
                .Include(dish => dish.Composition)
                .ThenInclude(composition => composition.Ingredient)
                .ToList();

//            var count = dishes.Count();
//            var items = dishes.Skip((page - 1) * DishesPerPage)
//                .Take(DishesPerPage)
//                .ToList();
//            
//            var pagination = new PaginationViewModel(count, page, DishesPerPage);
//            var menuPage = new MenuViewModel
//            {
//                Dishes = items,
//                Pagination = pagination
//            };
            
            return View("Menu", dishes);
        }

        [HttpPost]
        [Route("menu/add/")]
        public IActionResult AddToSession([FromBody]OrderPositionJson orderPosition)
        {
            var order = HttpContext.Session.GetObjectFromJson<IDictionary<int, int>>("order");
            
            if (order == null) 
                order = new Dictionary<int, int>();

            if (order.Keys.Contains(orderPosition.Dish))
                order[orderPosition.Dish] += orderPosition.Portions;
            else
                order[orderPosition.Dish] = orderPosition.Portions;
            
            HttpContext.Session.SetObjectAsJson("order", order);

            return new JsonResult(HttpContext.Session.GetString("order"));
        }

        [Route("order/")]
        public IActionResult RenderOrder()
        {
            var positions = HttpContext.Session.GetObjectFromJson <IDictionary<int, int>>("order");
            var dishes = new Dictionary<Dish, int>();
            
            if (HttpContext.Session.Keys.Contains("order"))
                foreach (var (dishId, portions) in positions)
                {
                    var dish = _context.Dishes.Find(dishId);
                    dishes[dish] = portions;
                }
            
            return View(dishes);
        }

        [Route("order/delete/{id:int}")]
        public IActionResult DeletePosition(int id)
        {
            var order = HttpContext.Session.GetObjectFromJson<IDictionary<int, int>>("order");
            order.Remove(id);
            HttpContext.Session.SetObjectAsJson("order", order);
            return new JsonResult(new {});
        }

        [HttpPost]
        [Route("order/confirm/")]
        public IActionResult ConfirmOrder([FromBody]JObject jCustomerInfo)
        {
            var address = jCustomerInfo["address"];
            var phoneNumberStr = jCustomerInfo["phoneNumber"];
            
            var customerInfo = new CustomerInfo()
            {
                Address = address.ToString(),
                PhoneNumber = decimal.Parse(phoneNumberStr.ToString())
            };

            var order = new Order()
            {
                Date = DateTime.Now,
                Customer = customerInfo,
                IsActive = true
            };
            var orderPositions = new List<OrderPosition>();
            foreach (var (dishId, portions) in HttpContext.Session.GetObjectFromJson<IDictionary<int, int>>("order"))
            {
                var dish = _context.Dishes.Find(dishId);
                orderPositions.Add(new OrderPosition()
                {
                    Dish = dish,
                    Order = order,
                    Portions = portions
                });
            }
            order.OrderPositions = orderPositions;

            _context.Customers.Add(customerInfo);
            _context.Orders.Add(order);
            _context.SaveChanges();
                        
            return new JsonResult(new {message="Заказ успешно оформлен"});
        }
    }
}