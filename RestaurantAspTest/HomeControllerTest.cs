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
using RestaurantAspTest.Custom;
using Xunit;

namespace RestaurantAspTest
{
    public class HomeControllerTest
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
            var context = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
            var controller = new HomeController(context.Object);

            var result = controller.Index() as ViewResult;
            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.NotNull(viewResult);
        }
        
        [Fact]
        public void TestRenderMenu()
        {
            var dishes = new List<Dish>
            {
                new Dish {Id = 0, Denomination = "dish0"},
            }.AsQueryable();
            
            var context = CreateContext();
            context.Dishes.AddRange(dishes);

            var controller = new HomeController(context);
            context.SaveChanges();

            var result = controller.RenderMenu() as ViewResult;
            var viewResult = Assert.IsType<ViewResult>(result);
            
            Assert.NotNull(viewResult);
            Assert.Equal(context.Dishes.ToList(), (List<Dish>)viewResult.Model);
        }
        
        [Fact]
        public void TestAddToSession()
        {
            var context = CreateContext();
            
            var controller = new HomeController(context);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Session = new MockHttpSession();
            controller.ControllerContext.HttpContext.Session.SetObjectAsJson("order", new Dictionary<int, int>());
            
            var result = controller.AddToSession(new OrderPositionJson() {Dish = 2, Portions = 100}) as JsonResult;
            var jsonResult = Assert.IsType<JsonResult>(result);
            
            Assert.NotNull(jsonResult);
            Assert.IsType<JsonResult>(jsonResult);
        }

        [Fact]
        public void TestRenderOrder()
        {
            var context = CreateContext();
            context.Dishes.Add(new Dish() {Id = 2});

            var controller = new HomeController(context);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Session = new MockHttpSession();
            controller.ControllerContext.HttpContext.Session.SetObjectAsJson("order", new Dictionary<int, int>() {{2, 100}});

            var viewResult = Assert.IsType<ViewResult>(controller.RenderOrder());
            
            Assert.NotNull(viewResult);
            Assert.NotNull(viewResult.Model);
            Assert.IsType<Dictionary<Dish, int>>(viewResult.Model);
        }

        [Fact]
        public void TestDeletePosition()
        {
            var context = CreateContext();
            context.Dishes.Add(new Dish() {Id = 2});

            var controller = new HomeController(context);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Session = new MockHttpSession();
            controller.ControllerContext.HttpContext.Session.SetObjectAsJson("order", new Dictionary<int, int>() {{2, 100}});

            var jsonResult = controller.DeletePosition(2);
            
            Assert.NotNull(jsonResult);
            Assert.IsType<JsonResult>(jsonResult);
        }

        [Fact]
        public void TestConfirmOrder()
        {
            var customerInfo = new JObject() {{"address", "Улица"}, {"phoneNumber", "77777777777"}};

            var context = CreateContext();
            context.Dishes.Add(new Dish() {Id = 2});
            
            var controller = new HomeController(context);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Session = new MockHttpSession();
            controller.ControllerContext.HttpContext.Session.SetObjectAsJson("order", new Dictionary<int, int>() {{2, 100}});

            var jsonResult = controller.ConfirmOrder(customerInfo);
            
            Assert.NotNull(jsonResult);
            Assert.IsType<JsonResult>(jsonResult);
        }
        
    }
}