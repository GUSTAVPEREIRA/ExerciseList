using System;
namespace ExerciseList.DTO.Product
{
    public class ProductDTO
    {
        public ProductDTO(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }        
    }
}