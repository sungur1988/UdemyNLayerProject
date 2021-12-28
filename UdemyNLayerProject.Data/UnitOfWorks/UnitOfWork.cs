using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.UnitOfWorks;
using UdemyNLayerProject.Data.Repositories;

namespace UdemyNLayerProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appDbContext;
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IProductRepository productRepository { get {
                if (_productRepository==null)
                {
                    _productRepository = new ProductRepository(_appDbContext);
                }

                return _productRepository;
            
            } }/*=> _productRepository = _productRepository ?? new ProductRepository(_appDbContext);*/

        public ICategoryRepository categoryRepository => _categoryRepository = _categoryRepository ?? new CategoryRepository(_appDbContext);

        public void Commit()
        {
            _appDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
