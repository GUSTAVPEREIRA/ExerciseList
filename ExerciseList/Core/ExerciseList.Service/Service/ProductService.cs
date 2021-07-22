using System.Collections.Generic;
using System.Linq;
using ExerciseList.DTO.Product;
using ExerciseList.Service.IService;

namespace ExerciseList.Service.Service
{
    public class ProductService : IProductService
    {
        private List<ProductDTO> productList;

        public ProductService()
        {
            InitializeProducts();
        }


        public List<ProductDTO> GetList()
        {
            return productList;
        }

        /// <summary>
        /// Find one Product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductDTO FindById(int id)
        {
            var product = productList.Where(w => w.Id == id).FirstOrDefault();

            return product;
        }

        /// <summary>
        /// Repository Simulator
        /// </summary>
        private void InitializeProducts()
        {
            productList = new List<ProductDTO>();
            productList.Add(new ProductDTO(1, "Extensão Vga Com Ferrite 1,5 Metros", 21.15m));
            productList.Add(new ProductDTO(2, "Cabo Carregador Celular Turbo Samsung J7 J6 Prime Blindado", 28.90m));
            productList.Add(new ProductDTO(3, "GARRAFA TERM. 500ML LUMINA INOX", 59.90m));
            productList.Add(new ProductDTO(4, "Monitor Gamer Nitro Acer 23,8 VG240Y FHD", 1419.00m));
            productList.Add(new ProductDTO(5, "Fone de Ouvido, Sennheiser, HD300", 474.28m));
        }
    }
}