using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Moq;
using MockQueryable.Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestaurantAsp;
using RestaurantAsp.Controllers;
using RestaurantAsp.Data;
using RestaurantAsp.Models;
using RestaurantAsp.Views.Admin.Data;
using RestaurantAspTest.Custom;
using Xunit;

namespace RestaurantAspTest
{
    public class AdminControllerTest
    {

        private ApplicationDbContext CreateContext()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "RestaurantAspTest")
                .Options;
            
            var context = new ApplicationDbContext(dbOptions);
            
            return context;
            
        } 
        
        [Fact]
        public void TestIndex()
        {
            var context = CreateContext();
            var controller = new AdminController(context);

            var result = controller.Index() as ViewResult;
            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.NotNull(viewResult);
        }
        
        [Fact]
        public void TestRenderIngredients()
        {
            var context = CreateContext();
            context.Ingredients.Add(new Ingredient() {Id = 0});

            var controller = new AdminController(context);

            var result = controller.RenderIngredients() as ViewResult;
            var viewResult = Assert.IsType<ViewResult>(result);
            
            Assert.NotNull(viewResult);
            Assert.Equal(context.Ingredients.ToList(), (List<Ingredient>)viewResult.Model);
        }
        
        [Fact]
        public void TestCreateIngredient()
        {
            var context = CreateContext();

            var controller = new AdminController(context);

            var result = controller.CreateIngredient() as ViewResult;
            var viewResult = Assert.IsType<ViewResult>(result);
            
            Assert.NotNull(viewResult); 
            Assert.Null(viewResult.Model);
        }
        
        [Fact]
        public void TestChangeIngredient()
        {
            var context = CreateContext();
            context.Ingredients.Add(new Ingredient() {Id = 2});

            var controller = new AdminController(context);

            var result = controller.ChangeIngredient(2) as ViewResult;
            var viewResult = Assert.IsType<ViewResult>(result);
            
            Assert.NotNull(viewResult); 
            Assert.NotNull(viewResult.Model);
            Assert.IsType<Ingredient>(viewResult.Model);
        }
        
        [Fact]
        public void TestSaveIngredientChanged()
        {
            var context = CreateContext();
            context.Ingredients.Add(new Ingredient() {Id = 2, Denomination = "Ингредиент"});

            var controller = new AdminController(context);

            var ingredient = context.Ingredients.Find(2);
            ingredient.Denomination = "";
            var result = controller.SaveIngredient(ingredient) as JsonResult;
            var viewResult = Assert.IsType<JsonResult>(result);
            
            Assert.NotNull(viewResult); 
        }
        
        [Fact]
        public void TestSaveIngredientNew()
        {
            var context = CreateContext();

            var controller = new AdminController(context);

            var result = controller.SaveIngredient(new Ingredient() {Id = 0}) as JsonResult;
            var viewResult = Assert.IsType<JsonResult>(result);
            
            Assert.NotNull(viewResult); 
        }
        
        [Fact]
        public void TestSaveIngredientCreated()
        {
            var ingredient = new Ingredient() {Id = 2, Denomination = "Ингредиент"};
            
            var context = CreateContext();
            context.Ingredients.Add(ingredient);

            var controller = new AdminController(context);

            ingredient.Id = 0;
            var result = controller.SaveIngredient(ingredient) as JsonResult;
            var viewResult = Assert.IsType<JsonResult>(result);
            
            Assert.NotNull(viewResult); 
        }
        
        [Fact]
        public void TestDeleteIngredient()
        {
            var context = CreateContext();
            context.Ingredients.Add(new Ingredient() {Id = 2});

            var controller = new AdminController(context);

            var result = controller.DeleteIngredient(2) as JsonResult;
            var viewResult = Assert.IsType<JsonResult>(result);
            
            Assert.NotNull(viewResult); 
        }
        
        
        
        
        
        
        
        [Fact]
        public void TestRenderDishes()
        {
            var context = CreateContext();
            context.Dishes.Add(new Dish() {Id = 0});

            var controller = new AdminController(context);

            var result = controller.RenderDishes() as ViewResult;
            var viewResult = Assert.IsType<ViewResult>(result);
            
            Assert.NotNull(viewResult);
            Assert.NotNull(viewResult.Model);
        }
        
        [Fact]
        public void TestCreateDish()
        {
            var context = CreateContext();

            var controller = new AdminController(context);

            var result = controller.CreateDish() as ViewResult;
            var viewResult = Assert.IsType<ViewResult>(result);
            
            Assert.NotNull(viewResult); 
            Assert.NotNull(viewResult.Model);
            Assert.IsType<DishData>(viewResult.Model);
        }
        
        [Fact]
        public void TestChangeDish()
        {
            var ingredient = new Ingredient() {Id = 0};
            var dishIngredient = new DishIngredient() {Id = 0, Ingredient = ingredient};
            var dish = new Dish() {Id = 2, Denomination = "Блюдо", Composition = new List<DishIngredient>{dishIngredient}};
            dishIngredient.Dish = dish;
            
            var context = CreateContext();
            context.Ingredients.Add(ingredient);
            context.Compositions.Add(dishIngredient);
            context.Dishes.Add(dish);
            context.SaveChanges();

            var controller = new AdminController(context);

            var result = controller.ChangeDish(dish.Id) as ViewResult;
            var viewResult = Assert.IsType<ViewResult>(result);
            
            Assert.NotNull(viewResult); 
            Assert.NotNull(viewResult.Model);
            Assert.IsType<DishData>(viewResult.Model);
        }
        
        [Fact]
        public void TestSaveDishChanged()
        {
            var ingredient = new Ingredient() {Id = 0};
            var dishIngredient = new DishIngredient() {Id = 0, Ingredient = ingredient};
            var dish = new Dish()
            {
                Id = 2, 
                Denomination = "Блюдо", 
                Composition = new List<DishIngredient>{dishIngredient},
                Unit = Units.Gr.GetUnitName()
            };
            dishIngredient.Dish = dish;
            
            var context = CreateContext();
            context.Ingredients.Add(ingredient);
            context.Compositions.Add(dishIngredient);
            context.Dishes.Add(dish);
            context.SaveChanges();
            
            var controller = new AdminController(context);

            dish.Denomination = "";
            var jDish = new JObject
            {
                {"id", dish.Id},
                {"denomination", dish.Denomination},
                {"price", dish.Price},
                {"unit", dish.Unit},
                {"quantity", dish.Quantity},
                {"composition", $"[{dishIngredient.Id}]"},
            };
            var result = controller.SaveDish(jDish) as JsonResult;
            var viewResult = Assert.IsType<JsonResult>(result);
            
            Assert.NotNull(viewResult); 
        }
        
        [Fact]
        public void TestSaveDishNew()
        {
            var ingredient = new Ingredient() {Id = 0};
            var dishIngredient = new DishIngredient() {Id = 0, Ingredient = ingredient};
            var dish = new Dish()
            {
                Id = 0, 
                Denomination = "Блюдо", 
                Composition = new List<DishIngredient>{dishIngredient},
                Unit = Units.Gr.GetUnitName()
            };
            dishIngredient.Dish = dish;
            
            var context = CreateContext();
            context.Ingredients.Add(ingredient);
            context.Compositions.Add(dishIngredient);
            context.SaveChanges();

            var controller = new AdminController(context);

            var jDish = new JObject
            {
                {"id", dish.Id},
                {"denomination", dish.Denomination},
                {"price", dish.Price},
                {"unit", dish.Unit},
                {"quantity", dish.Quantity},
                {"composition", $"[{dishIngredient.Id}]"},
            };
            
            var result = controller.SaveDish(jDish) as JsonResult;
            var viewResult = Assert.IsType<JsonResult>(result);
            
            Assert.NotNull(viewResult); 
        }
        
        [Fact]
        public void TestSaveDishCreated()
        {
            var ingredient = new Ingredient() {Id = 0};
            var dishIngredient = new DishIngredient() {Id = 0, Ingredient = ingredient};
            var dish = new Dish()
            {
                Id = 2, 
                Denomination = "Блюдо", 
                Composition = new List<DishIngredient>{dishIngredient},
                Unit = Units.Gr.GetUnitName()
            };
            dishIngredient.Dish = dish;
            
            var context = CreateContext();
            context.Ingredients.Add(ingredient);
            context.Compositions.Add(dishIngredient);
            context.SaveChanges();

            var controller = new AdminController(context);

            var jDish = new JObject
            {
                {"id", 0},
                {"denomination", dish.Denomination},
                {"price", dish.Price},
                {"unit", dish.Unit},
                {"quantity", dish.Quantity},
                {"composition", $"[{dishIngredient.Id}]"},
            };
            
            var result = controller.SaveDish(jDish) as JsonResult;
            var viewResult = Assert.IsType<JsonResult>(result);
            
            Assert.NotNull(viewResult); 
        }
        
        [Fact]
        public void TestDeleteDish()
        {
            var ingredient = new Ingredient() {Id = 0};
            var dishIngredient = new DishIngredient() {Id = 0, Ingredient = ingredient};
            var dish = new Dish()
            {
                Id = 2, 
                Denomination = "Блюдо", 
                Composition = new List<DishIngredient>{dishIngredient},
                Unit = Units.Gr.GetUnitName()
            };
            dishIngredient.Dish = dish;
            
            var context = CreateContext();
            context.Ingredients.Add(ingredient);
            context.Compositions.Add(dishIngredient);
            context.SaveChanges();

            var controller = new AdminController(context);

            var result = controller.DeleteDish(2) as JsonResult;
            var viewResult = Assert.IsType<JsonResult>(result);
            
            Assert.NotNull(viewResult); 
        }

        [Fact]
        public void TestRenderOrders()
        {
            var customer = new CustomerInfo
            {
                Id = 0
            };
            var dish = new Dish
            {
                Id = 0
            };
            var orderPosition = new OrderPosition
            {
                Id = 0,
                Dish = dish,
            };
            var orders = new List<Order>
            {
                new Order
                {
                    Id = 0,
                    Customer = customer,
                    IsActive = true,
                    OrderPositions = new List<OrderPosition>
                    {
                        orderPosition
                    }
                }
            };
            orderPosition.Order = orders[0];
            
            var context = CreateContext();
            context.Dishes.Add(dish);
            context.Customers.Add(customer);
            context.OrdersPositions.Add(orderPosition);
            context.Orders.Add(orders[0]);
            context.SaveChanges();
            
            var controller = new AdminController(context);
            
            var result = controller.RenderOrders() as ViewResult;
            var viewResult = Assert.IsType<ViewResult>(result);
            
            Assert.NotNull(viewResult);
            Assert.NotNull(viewResult.Model);
            Assert.IsType<List<Order>>(viewResult.Model);
        }
        
        [Fact]
        public void TestSetOrderDone()
        {
            var customer = new CustomerInfo
            {
                Id = 0
            };
            var dish = new Dish
            {
                Id = 0
            };
            var orderPosition = new OrderPosition
            {
                Id = 0,
                Dish = dish,
            };
            var orders = new List<Order>
            {
                new Order
                {
                    Id = 2,
                    Customer = customer,
                    IsActive = true,
                    OrderPositions = new List<OrderPosition>
                    {
                        orderPosition
                    }
                }
            };
            orderPosition.Order = orders[0];
            
            var context = CreateContext();
            context.Dishes.Add(dish);
            context.Customers.Add(customer);
            context.OrdersPositions.Add(orderPosition);
            context.Orders.Add(orders[0]);
            context.SaveChanges();
            
            var controller = new AdminController(context);
            
            var result = controller.SetOrderDone(2) as JsonResult;
            var jsonResult = Assert.IsType<JsonResult>(result);
            
            Assert.NotNull(jsonResult);
            Assert.False(context.Orders.Find(2).IsActive);
        }
        
    }
}