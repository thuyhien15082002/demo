using ReponsitoryMVC.Models;

namespace ReponsitoryMVC.Repository
{
    public interface IProductRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T product);
        void Update(T product);
        void Delete(int id);
        void Save();
        IEnumerable<Product> Arrange();
        IEnumerable<Product> ArrangebyName();
        //List<Product> GetProducts();


    }
}
