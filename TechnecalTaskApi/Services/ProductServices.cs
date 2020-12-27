using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using TechnecalTaskApi.Models;
using TechnecalTaskApi.Repository;

namespace TechnecalTaskApi.Services
{
    public class ProductServices : IProductServices
    {
        public string SavePhoto()
        {
            try
            {
                var Postedfile = HttpContext.Current.Request.Files[0];
                string FileName = Postedfile.FileName;
                var Physiacalpath = HttpContext.Current.Server.MapPath("~/Photos/"+FileName);
                Postedfile.SaveAs(Physiacalpath);
                return FileName;
            }
            catch (Exception ex)
            {
                return "No Photo";
                //throw;
            }
        }
    }
}