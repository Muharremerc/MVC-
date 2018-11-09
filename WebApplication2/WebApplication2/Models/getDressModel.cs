using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class getDressModel
    {
        public DAL.Model.DressDefinition Dress { get; set; }
        public List<DAL.Model.Image> Image { get; set; }
    }
}