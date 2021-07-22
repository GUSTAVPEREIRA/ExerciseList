using System.Collections.Generic;
using ExerciseList.DTO.Product;
using ExerciseList.Service.IService;

namespace ExerciseList.Exercise4.Controller
{
    public class ProductController
    {
        private readonly IProductService ProductService;

        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }

        public List<ProductDTO> GetProducts()
        {
            var productList = ProductService.GetList();

            return productList;
        }

        public ProductDTO GetProduct(int id)
        {
            var product = ProductService.FindById(id);

            return product;
        }
    }
}