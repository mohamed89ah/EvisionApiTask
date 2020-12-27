using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TechnecalTaskApi.Models;

namespace TechnecalTaskApi.Repository
{
    public class ProductRepositry: IProductRepositry
    {
        private readonly ProductDataModel _productContext;

        public ProductRepositry(ProductDataModel productContext)
        {
            _productContext = productContext;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _productContext.Products.ToList();
        }
        public Product GetProductById(int ProductId)
        {
            return _productContext.Products.Find(ProductId);
        }
        public IEnumerable<Product> GetProductByName(string ProductName)
        {
            
            return _productContext.Products.Where(p=>p.p_Name.Contains( ProductName));
        }

        public  string AddProduct(Product ProductEntity)
        {

            try
            {
                if (ProductEntity != null)
                {
                   
                    string query = $"insert into Products (p_Name,P_Photo,P_Price,P_LastUpdate) " +
                        $"values('{ProductEntity.p_Name}', '{ProductEntity.P_Photo}', {ProductEntity.P_Price} , '{DateTime.Now}')";
                    DataTable products = new DataTable();
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductDataModel"].ConnectionString))
                    {
                        using (var cmd = new SqlCommand(query, con))
                        {
                            using (var da =new SqlDataAdapter(cmd))
                            {
                                cmd.CommandType = CommandType.Text;
                                da.Fill(products);
                            }
                        }
                    }

                    return "Added successfully ";
                }
                return "not Added";
            }
            catch (Exception ex)
            {

                return "Errore in Adding";
            }    
            
            
        }

        public string UpdateProduct(Product ProductEntity)
        {
            try
            {
                if (ProductEntity != null)
                {

                    string query = $"update Products set " +
                        $"p_Name = '{ProductEntity.p_Name}'," +
                        $"P_Photo='{ProductEntity.P_Photo}'," +
                        $"P_Price={ProductEntity.P_Price}," +
                        $"P_LastUpdate='{DateTime.Now}' " +
                        $"where P_Id = {ProductEntity.P_Id}";
                    DataTable products = new DataTable();
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductDataModel"].ConnectionString))
                    {
                        using (var cmd = new SqlCommand(query, con))
                        {
                            using (var da = new SqlDataAdapter(cmd))
                            {
                                cmd.CommandType = CommandType.Text;
                                da.Fill(products);
                            }
                        }
                    }

                    return "Updated successfully ";
                }
                return "not Updated";
            }
            catch (Exception ex)
            {

                return "Errore in Updating";
            }

        }
        public string DeleteProduct(int ProductID)
        {
            try
            {
                Product p = GetProductById(ProductID);
                if (p != null)
                {
                    string query = $"Delete Products where P_Id = {ProductID}";
                    DataTable products = new DataTable();
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductDataModel"].ConnectionString))
                    {
                        using (var cmd = new SqlCommand(query, con))
                        {
                            using (var da = new SqlDataAdapter(cmd))
                            {
                                cmd.CommandType = CommandType.Text;
                                da.Fill(products);
                            }
                        }
                    }

                    return "Deleted successfully ";
                }
                return "Product Not Exict ";
            }
            catch (Exception ex)
            {

                return "Errore in Delete";
            }
        }

    
   

    }
}