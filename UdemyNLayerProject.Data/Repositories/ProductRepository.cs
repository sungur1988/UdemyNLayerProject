using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Entities;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayerProject.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x=>x.Id==productId);
        }
    }
}
