using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class HomeModel
    {

        public class HomeModelClass
        {
            public List<Dress> Dr { get; set; }
            public List<Category> Ct { get; set; }
        }
            




        public class Dress
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }

        }

        public class Category
        {

            public int Id { get; set; }
            public string Name { get; set; }
        }



    }
}