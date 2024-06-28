using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReponsitoryMVC.Models;

namespace ReponsitoryMVC.Repository
{
    public class ProductRepository<T> : IProductRepository<T> where T : class
    {
        private DbSet<T> _products;
        private DataContext _dataContext;
        private readonly ILogger<T> _logger;
        public ProductRepository(DataContext dataContext, ILogger<T> logger)
        {
            _dataContext = dataContext;
            _products = _dataContext.Set<T>();
            _logger = logger;
        }
        public void Delete(int id)
        {
            var p = _products.Find(id);
            _products.Remove(p);
        }
        public IEnumerable<T> GetAll()
        {
            return _products.ToList();
        }
        public T GetById(int id)
        {
            return _products.Find(id);
        }
        public void Insert(T prduct)
        {
            _products.Add(prduct);
        }
        public void Save()
        {
            _dataContext.SaveChanges();
            _logger.LogInformation("Saved changes to the database at {Time}", DateTime.UtcNow);
        }
        public void Update(T prduct)
        {
            _products.Attach(prduct);
            _dataContext.Entry(prduct).State = EntityState.Modified;
        }
        public IEnumerable<Product> ArrangebyName()
        {
            var query = from p in _dataContext.Products
                        orderby p.Name
                        select p;
            return query.ToList();
        }
        public IEnumerable<Product> Arrange()
        {
            var query = _dataContext.Products
                                    .Where(p => p.Status == 1)
                                    .OrderByDescending(p => p.Price)
                                    .ToList();

            return query;
        }
        /*public List<Product> GetProducts()
        {
            return _dataContext.Products.ToList();
        }*/
    }
}
