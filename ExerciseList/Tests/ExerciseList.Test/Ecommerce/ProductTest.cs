using System.Linq;
using ExerciseList.Service.Service;
using Xunit;

namespace ExerciseList.Test.Ecommerce
{
    public class ProductTest
    {
        public ProductService productService;

        [Fact]
        public void MustContainListFiveCharacters()
        {
            //Given
            productService = new ProductService();

            //When
            var productList = productService.GetList();

            //Then
            Assert.Equal(5, productList.Count());
        }

        [Theory]
        [InlineData(1, "Extensão Vga Com Ferrite 1,5 Metros", 21.15)]
        [InlineData(2,"Cabo Carregador Celular Turbo Samsung J7 J6 Prime Blindado", 28.90)]
        [InlineData(3,"GARRAFA TERM. 500ML LUMINA INOX", 59.90)]
        [InlineData(4,"Monitor Gamer Nitro Acer 23,8 VG240Y FHD", 1419.00)]
        [InlineData(5,"Fone de Ouvido, Sennheiser, HD300", 474.28)]

        public void GetProductByIdCorrectly(int id, string name, decimal value)
        {
            //Given
            productService = new ProductService();

            //When
            var product = productService.FindById(id);

            //Then
            Assert.Equal(name, product.Name);
            Assert.Equal(value, product.Price);
        }
    }
}