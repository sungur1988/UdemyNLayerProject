using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Entities;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWorks;

namespace UdemyNLayerProject.Service.Services
{
    public class ProductService : GenericService<Product>, IProductService
    {

        public ProductService(IUnitOfWork unitOfWork,IRepository<Product> repository) : base(unitOfWork,repository)
        {
            
        }
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _unitOfWork.productRepository.GetWithCategoryByIdAsync(productId);
        }
    }
}
