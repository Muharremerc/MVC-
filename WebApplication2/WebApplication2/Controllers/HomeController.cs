using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {


            DAL.Ac db = new DAL.Ac();
            var dress = db.getAllDress();
            var category = db.getAllCategory();
            WebApplication2.Models.HomeModel.HomeModelClass hmc = new Models.HomeModel.HomeModelClass();


            List<WebApplication2.Models.HomeModel.Dress> dressTemp = new List<Models.HomeModel.Dress>();
            foreach (var item in dress)
            {
                dressTemp.Add(new Models.HomeModel.Dress
                {
                    Id=item.Id,
                    Name=item.Name,
                    Image=db.getImagebyDressId(item.Id)

                    
                }                  
                    
             );
                
            }

            List<WebApplication2.Models.HomeModel.Category> categoryTemp = new List<Models.HomeModel.Category>();
            foreach (var item in category)
            {
                categoryTemp.Add(new Models.HomeModel.Category
                {
                    Id=item.Id,
                    Name=item.Name,
                   

                }
                
                );
            }

            hmc.Ct = categoryTemp;
            hmc.Dr = dressTemp;



            return View(hmc);

        }

        public ActionResult getDress(int id)
        {

            DAL.Ac db = new DAL.Ac();
            var dress = db.getDress(id);
            var image = db.getImageBydressId(id);
            WebApplication2.Models.getDressModel dressmodel = new Models.getDressModel();
            dressmodel.Dress = dress;
            dressmodel.Image = image;
            return View(dressmodel);
        }


        public JsonResult addnewDress(string name,string details,int category)
        {
            DAL.Ac db = new DAL.Ac();
            var dress = db.AddnewDress(name,details,category);
            return Json(dress);
        }


        public ActionResult getDressbyCategoryId(int id)
        {




         
            
            
            if(id==0)
            {

                DAL.Ac db = new DAL.Ac();
                var dress = db.getAllDress();


                List<WebApplication2.Models.HomeModel.Dress> dressTemp = new List<Models.HomeModel.Dress>();
                foreach (var item in dress)
                {
                    dressTemp.Add(new Models.HomeModel.Dress
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Image = db.getImagebyDressId(item.Id)


                    }

                 );

                }
                return PartialView("_getDressbyCategoryId", dressTemp);


            }
            else
            {
                DAL.Ac db = new DAL.Ac();
                var dress = db.getDressbyCategoryId(id);


                List<WebApplication2.Models.HomeModel.Dress> dressTemp = new List<Models.HomeModel.Dress>();
                foreach (var item in dress)
                {
                    dressTemp.Add(new Models.HomeModel.Dress
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Image = db.getImagebyDressId(item.Id)


                    }

                 );

                }
                
                return PartialView("_getDressbyCategoryId", dressTemp);
            }
            
        }


        public ActionResult addNew()
        {
            DAL.Ac DB = new DAL.Ac();
            var cat = DB.getAllCategory();
            return View(cat);
        }

        public ActionResult Image(int id)
        {
            DAL.Ac DB = new DAL.Ac();
            var dress = DB.getDressbyId(id);
            return View(dress);
        }





        public ActionResult Upload(HttpPostedFileBase image1, HttpPostedFileBase image2, HttpPostedFileBase image3,int Id,string name1, string name2, string name3)
        {

            List<WebApplication2.Models.FileImage> lfile = new List<Models.FileImage>();
            WebApplication2.Models.FileImage fi1 = new Models.FileImage();
            fi1.File = image1;
            fi1.Name = name1;
            
            lfile.Add(fi1); WebApplication2.Models.FileImage fi2 = new Models.FileImage();
            fi2.File = image2;
            fi2.Name = name2;
            lfile.Add(fi2);
            WebApplication2.Models.FileImage fi3 = new Models.FileImage();
            fi3.File = image3;
            fi3.Name = name3;
            lfile.Add(fi3);

            DAL.Model.DressEntities db = new DAL.Model.DressEntities();
            foreach (var item in lfile)
            {
                string path = Path.Combine(Server.MapPath("~/Image"),
                System.IO.Path.GetFileName(item.File.FileName));
                item.File.SaveAs(path);

                DAL.Model.Image img = new DAL.Model.Image();
                string[] words = item.File.FileName.Split('\\');
                var count = words.Count();
                img.imageName = words[count - 1];
                img.imageAlt = item.Name;
                var imageid=db.Images.Add(img);
                db.SaveChanges();
                DAL.Model.DressImage di = new DAL.Model.DressImage();
                di.DressId = Id;
                di.ImageId = imageid.Id;
                db.DressImages.Add(di);
                db.SaveChanges();
                img = null;
                path = null;
                words = null;
                count = 0;
                imageid = null;
                di = null;


            }
            

            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {

            return View();

        }


        public JsonResult LoginC(string name,string password)
        {

            DAL.Ac DB = new DAL.Ac();
            var log = DB.Login(name,password);
            Session["Login"] = log.ToString();
            return Json(log);

        }
    }
}