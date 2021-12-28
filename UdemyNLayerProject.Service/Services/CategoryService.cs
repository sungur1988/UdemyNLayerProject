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
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork,IRepository<Category> repository):base(unitOfWork,repository)
        {

        }
        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _unitOfWork.categoryRepository.GetWithProductsByIdAsync(categoryId);
        }
    }
}
