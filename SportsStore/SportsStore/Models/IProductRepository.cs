using System.Linq;

namespace SportsStore.Models
{
    public interface IProductRepository
    {
        //IQueryable asslow a caller to obtain a sequence of objects
        IQueryable<Product> Products { get; }
    }
}