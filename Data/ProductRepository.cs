using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly EssentialProductDbContext _dbContext;

        public ProductRepository(EssentialProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _dbContext.Product.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<ProductImage> CreateProductImageAsync(ProductImage productImage)
        {
            var product = await GetProductAsync(Convert.ToInt32(productImage.ProductId));
            product.ProductImages = new List<ProductImage>() { productImage };

            await _dbContext.SaveChangesAsync();
            return productImage;
        }

        public async Task<bool> DeleteProductAsync(int ProductId)

        {
            var ProductToRemove = await _dbContext.Product.FindAsync(ProductId);
            _dbContext.Product.Remove(ProductToRemove);
            return await _dbContext.SaveChangesAsync() > 0 ;
            
        }

        public Product GetProduct(int ProductId)
        {
            var product = _dbContext.Product.Find(ProductId);
            return product;
        }

        public Task<Product> GetProductAndImagesAsync(int productId)
        {
            return _dbContext.Product.AsNoTracking().Include(i => i.ProductImages).FirstOrDefaultAsync(f => f.Id == productId);
        }

        public Task<Product> GetProductAsync(int ProductId)
        {
            return _dbContext.Product.FindAsync(ProductId).AsTask();
            
        }

        public  Task<Product> GetProductByNameAsync(string name)
        {
            return  _dbContext.Product.FirstOrDefaultAsync(f => f.Name.ToLower() == name.ToLower());
        }

        public Task<Product> GetProductByNameAsync(string name, int productId)
        {
            return _dbContext.Product.AsNoTracking().FirstOrDefaultAsync(f => f.Name.ToLower() == name.ToLower() && f.Id != productId);

        }

        public List<Product> GetProducts(int noOfProducts)
        {
            var products = _dbContext.Product.OrderByDescending(x => x.CreatedDate).Take(noOfProducts).ToList();
            return products;
        }

        public Task<List<Product>> GetProductsAsync(int noOfProducts)
        {
            var products = _dbContext.Product.AsNoTracking().OrderByDescending(x => x.CreatedDate).Take(noOfProducts).ToListAsync();
            return products;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            _dbContext.Product.Update(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }
    }
}
