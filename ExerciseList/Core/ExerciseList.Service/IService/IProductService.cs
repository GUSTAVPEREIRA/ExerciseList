using System.Collections.Generic;
using ExerciseList.DTO.Product;

namespace ExerciseList.Service.IService
{
    public interface IProductService
    {
        List<ProductDTO> GetList();

        ProductDTO FindById(int id);
    }
}