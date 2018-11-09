using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class Ac
    {

        public List<DAL.Model.DressDefinition> getAllDress()
        {

            DAL.Model.DressEntities db = new Model.DressEntities();
            var dress = db.DressDefinitions.ToList();
            return dress;
        }

        public List<DAL.Model.Category> getAllCategory()
        {

            DAL.Model.DressEntities db = new Model.DressEntities();
            var category = db.Categories.ToList();
            return category;
        }

        public Model.DressDefinition getDress(int id)
        {

            DAL.Model.DressEntities db = new Model.DressEntities();
            var dress = db.DressDefinitions.FirstOrDefault(x => x.Id == id);
            return dress;
        }

        public List<Model.Image> getImageBydressId(int id)
        {

            DAL.Model.DressEntities db = new Model.DressEntities();
            var dress = db.DressDefinitions.Include("DressImages").Include("DressImages.Image").Where(x=>x.Id==id).ToList();
            List<Model.Image> img = new List<Model.Image>();

            foreach (var item in dress)
            {
                foreach (var item2 in item.DressImages)
                {
                    img.Add(new Model.Image
                    {
                        Id = item2.Image.Id,
                        imageName=item2.Image.imageName
                        
                }
               );
                }
            }



            return img;
        }

        public Model.DressDefinition AddnewDress(string name,string details,int category)
        {
            DAL.Model.DressEntities db = new Model.DressEntities();
            DAL.Model.DressDefinition dress = new Model.DressDefinition();
            dress.Name = name;
            dress.Details = details;
            var dresstemp =db.DressDefinitions.Add(dress);
            db.SaveChanges();
            
            DAL.Model.DressCategory dc = new Model.DressCategory();
            dc.CategoryId = category;
            dc.DressId = dresstemp.Id;
            db.DressCategories.Add(dc);
            db.SaveChanges();

            return dress;

        }
        public List<Model.DressDefinition> getDressbyCategoryId(int id)
        {
            DAL.Model.DressEntities db = new Model.DressEntities();

            var dress = db.Categories.Include("DressCategories").Include("DressCategories.DressDefinition").Where(x => x.Id==id).ToList();
        
           
            List<Model.DressDefinition> dresstemp = new List<Model.DressDefinition>();
            foreach (var item in dress)
            {
                foreach (var item2 in item.DressCategories)
                {
                    dresstemp.Add(new Model.DressDefinition
                    {

                        Id = item2.DressDefinition.Id,
                        Name = item2.DressDefinition.Name

                    }
                     );
                }
             
            }

            return dresstemp;
            
        }

        public Model.DressDefinition getDressbyId(int id)
        {
            DAL.Model.DressEntities db = new Model.DressEntities();
            var dress = db.DressDefinitions.FirstOrDefault(x => x.Id == id);
            return dress;

        }

        public string getImagebyDressId(int id)
        {
            DAL.Model.DressEntities db = new Model.DressEntities();
            var image = db.DressDefinitions.Include("DressImages").Include("DressImages.Image").Where(x => x.Id == id).ToList();
            foreach (var item in image)
            {
                foreach (var item2 in item.DressImages)
                {
                    if(item2.Image.imageAlt=="Main")
                    {
                        var returnvalue = item2.Image.imageName;
                        return returnvalue;
                    }

                }
            }

            return null;
            
        }
        public bool Login(string name,string password)
        {
           
              if(name=="admin" && password=="12345")
            {
                return true;
            }
              else
            {
                return false;
            }
        }

    }
}
