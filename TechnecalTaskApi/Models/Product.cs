using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnecalTaskApi.Models
{
    
    public class Product
    {
        [Key]
   
        public int P_Id { get; set; }
        public string p_Name { get; set; }
        public decimal P_Price { get; set; }
        public string P_Photo { get; set; }
        public DateTime P_LastUpdate { get; set; }
    }
}