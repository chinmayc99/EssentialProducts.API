using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IProductRepository
    {
        Product GetProduct(int ProductId);

        List<Product> GetProducts(int noOfProducts);

        Task<Product> GetProductAsync(int ProductId);

        Task<List<Product>> GetProductsAsync(int noOfProducts);

        Task<Product> CreateProductAsync(Product product);

        Task<Product> UpdateProductAsync(Product product);

        Task<bool> DeleteProductAsync(int ProductId);

        Task<Product> GetProductByNameAsync(string name);

        Task<Product> GetProductByNameAsync(string name, int productId);

        Task<ProductImage> CreateProductImageAsync(ProductImage productImage);
        Task<Product> GetProductAndImagesAsync(int productId);
    }
}
