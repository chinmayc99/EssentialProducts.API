using Core;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Product> CreateProductAsync(Product product)
        {
            return _productRepository.CreateProductAsync(product);
            
        }

        public async Task<ProductImage> CreateProductImageAsync(byte[] fileBytes, int productId, string imageName, string mimeType)
        {
            ProductImage productImage = new ProductImage()
            {
                ProductId = productId,
                Image = fileBytes,
                Mime = mimeType,
                ImageName = imageName,
                IsActive = true
            };
            return await _productRepository.CreateProductImageAsync(productImage);
        }

        public Task<bool> DeleteProductAsync(int ProductId)
        {
            return _productRepository.DeleteProductAsync(ProductId);
        }

        public Product GetProduct(int ProductId)
        {
            return _productRepository.GetProduct(ProductId);
        }

        public Task<Product> GetProductAndImagesAsync(int productId)
        {
            return _productRepository.GetProductAndImagesAsync(productId);
        }

        public Task<Product> GetProductAsync(int ProductId)
        {
            return _productRepository.GetProductAsync(ProductId);
        }

        public List<Product> GetProducts(int noOfProducts = 100)
        {
            return _productRepository.GetProducts(noOfProducts);
        }

        public Task<List<Product>> GetProductsAsync(int noOfProducts = 100) 
        {
            return _productRepository.GetProductsAsync(noOfProducts);
        }

        public async Task<bool> IsProductExistAsync(string name, int productId)
        {
            var product = await _productRepository.GetProductByNameAsync(name);
            return !(product != null && product.Id != productId) ;

           
        }

        public async Task<bool> IsProductNameExistAsync(string name)
        {
            var product  =  await  _productRepository.GetProductByNameAsync(name);
            return product != null;
        }
            
        public Task<Product> UpdateProductAsync(Product product)
        {
            return _productRepository.UpdateProductAsync(product);
        }
    }
}
