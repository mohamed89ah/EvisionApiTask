using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnecalTaskApi.Models;

namespace TechnecalTaskApi.Repository
{
    public interface IProductRepositry
    {

        IEnumerable<Product> GetAllProduct();
        Product GetProductById(int ProductId);
        IEnumerable<Product> GetProductByName(string ProductName);
        string AddProduct(Product ProductEntity);
        string UpdateProduct(Product ProductEntity);
        string DeleteProduct(int ProductID);
    }
}
