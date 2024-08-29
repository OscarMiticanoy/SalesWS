using AutoMapper;
using Microsoft.Extensions.Hosting;
using SalesWS.Contexts;

namespace SalesWS.Services
{
    public class ProductService
    {
        private static readonly List<Product> Productos = new();


        public Task<List<Product>> GetAllProducts()
        {
            return Task.FromResult(Productos);
        }

        public Task<Product?> GetPost(int id)
        {
            return Task.FromResult(Productos.FirstOrDefault(x => x.Productid == id));
        }

        public Task CreatePost(Product product)
        {
            Productos.Add(product);
            return Task.CompletedTask;
        }

    }
}
