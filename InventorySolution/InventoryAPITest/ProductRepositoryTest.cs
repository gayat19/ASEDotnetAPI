using InventoryAPI.Contexts;
using InventoryAPI.Interfaces;
using InventoryAPI.Models;
using InventoryAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPITest
{
    public class Tests
    {
        InventoryContext _context;
        [SetUp]
        public void Setup()
        {
            var option = new DbContextOptionsBuilder<InventoryContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;
            _context = new InventoryContext(option);
        }


        [TestCase(101, "Test Product1", 100, 20,true)]
        [TestCase(102, "Test Product2", 200, 10, false)]
        public void ProductAddSuccessTest(int id,string name,decimal price,int quantity,bool status)
        {
            //Arrange
            IRepository<int,Product> productRepo = new ProductRepository(_context);
            Product product = new Product
            {
                Id = id,
                Title = name,
                Price = price,
                StockInHand = quantity,
                IsAvailable = status,
                ProductImage = "https://www.bing.com/ck/a?!&&p=309691a6dc4674c53b191a562f5928f340dcc2aefa20dedee5ceeb8dead99887JmltdHM9MTc2MjgxOTIwMA&ptn=3&ver=2&hsh=4&fclid=0cde72d5-8a05-6f13-0b2f-649d8b7a6e0a&u=a1L2ltYWdlcy9zZWFyY2g_cT1wcm9kdWN0K2ltYWdlJmlkPUQ4QTg0NzNBMDNGMTA4NTc2RDkxOEY0MTk3N0Y3OEI0ODRDNzlDMzEmRk9STT1JUUZSQkE"
            };
            //Action
            var result = productRepo.Add(product);
            //Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void ProductGetProductByIdExceptionTest()
        {
            //Arrange
            IRepository<int, Product> productRepo = new ProductRepository(_context);
      
            //Action & Assert
            Assert.Throws<Exception>(() => productRepo.GetById(100));
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
    }
}