using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechnecalTaskApi.Models;
using TechnecalTaskApi.Repository;
using TechnecalTaskApi.Services;
//using TechnecalTaskApi.Services;

namespace TechnecalTaskApi.Controllers
{
    public class ProductController : ApiController
    {
      //  private readonly IProductServices _productServices;
        private IProductRepositry _productRepositry;
        private IProductServices _productservices;

        public ProductController()
        {
            _productRepositry= new ProductRepositry(new ProductDataModel());
            _productservices = new ProductServices();
           // _productServices = new ProductServices(_productRepositry);
        }
        public ProductController(IProductRepositry productRepositry, IProductServices productservices)
        {
            _productRepositry = productRepositry;
            _productservices = productservices;

        }

        [HttpGet]

        public HttpResponseMessage Get()
        {

            return Request.CreateResponse(HttpStatusCode.OK, _productRepositry.GetAllProduct());
        }

        [HttpPost]
        public string AddProduct(Product prod)
        {


            return _productRepositry.AddProduct(prod);



        }
        [HttpPut]
        public string UpdateProduct(Product prod)
        {
            return _productRepositry.UpdateProduct(prod);
        }


        [HttpDelete]
        public string Delete(int id)
        {
            return _productRepositry.DeleteProduct(id);
        }

        [Route("api/Product/Savefile")]
        public string savePhoto()
        {
            return _productservices.SavePhoto();
        }

    }
}
