using clinic_management_system3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinic_management_system3.Controllers
{
    public class adminController : Controller
    {
        clinic_management_system_2Entities db = new clinic_management_system_2Entities();
        // GET: admin
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult admin()
        {

            return View();
        }
        [HttpPost]


        //admin login code id password save in sql database
        //id:muhammad.aasad110@gmail.com , pasword:asad123
        public ActionResult admin(tbl_admin ad)
        {

            tbl_admin a = db.tbl_admin.Where(x => x.ad_email == ad.ad_email && x.ad_password == ad.ad_password).SingleOrDefault();
            if (a!=null)
            {
                Session["name"] = a.ad_name;
                Session["id"] = a.ad_id;
                return RedirectToAction("category");
            }
            else
            {
                ViewBag.error = "invalid email and password";
            }

            return View();
        }


        //admin dashboard admin can view all categories and servises here(start)
        public ActionResult category()
        {

            return View();
        }

        //admin dashboard admin can view all categories and servises here(end)




        //admin add categories form this code (start)

        public ActionResult add_category()
        {

            return View();
        }


        [HttpPost]

       
        public ActionResult add_category(tbl_cateogry ca, HttpPostedFileBase img)
        {


            if (Session["id"]!=null)
            {
                string path = upload_image(img);
                if (path.Equals("-1"))
                {

                    ViewBag.error = "image not be uploaded";

                }

                else
                {
                    if (ModelState.IsValid==true)
                    {
                        tbl_cateogry c = new tbl_cateogry();

                        c.cat_name = ca.cat_name;
                        c.cat_status = 1;
                        c.cat_image = path;
                        c.ad_id_fk = Convert.ToInt32(Session["id"].ToString());
                        db.tbl_cateogry.Add(c);
                        db.SaveChanges();
                        return RedirectToAction("category");
                    }
                    
                }



                
            }

            else
            {
                ViewBag.error2 = "without login you can not perform action";
            }
            return View();
        }

        //admin add categories form this code (end)

        //admin can view category which he added (start)

        public ActionResult view_department(int ? page)
        {
            int pagesize = 9, pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.tbl_cateogry.Where(x => x.cat_status == 1).OrderByDescending(x => x.cat_id).ToList();
            IPagedList<tbl_cateogry> cat = list.ToPagedList(pageindex, pagesize);


            return View(cat);
        }

        //admin can view category which he added (end)


        //admin can add products in selected category which he had added (start)

        public ActionResult add_products()
        {
            List<tbl_cateogry> li = db.tbl_cateogry.ToList();
            ViewBag.prod = new SelectList(li, "cat_id", "cat_name");

            return View();
        }

        [HttpPost]

        public ActionResult add_products(tbl_product pr,HttpPostedFileBase img )
        {
            List<tbl_cateogry> li = db.tbl_cateogry.ToList();
            ViewBag.prod = new SelectList(li, "cat_id", "cat_name");

            string path = upload_image(img);

            if (Session["id"]!=null)
            {
                if (path.Equals("-1"))
                {
                    ViewBag.error = "imgage not uploaded";
                }
                else
                {
                    if (ModelState.IsValid==true)
                    {
                       

                        tbl_product p = new tbl_product();
                        tbl_admin a = new tbl_admin();

                        p.pro_name = pr.pro_name;
                        p.pro_price = pr.pro_price;
                        p.pro_desc = pr.pro_desc;
                        p.pro_image = path;
                        p.ad_id_fk = Convert.ToInt32(Session["id"].ToString());
                        p.cat_id_fk = pr.cat_id_fk;

                        db.tbl_product.Add(p);
                        db.SaveChanges();
                        return RedirectToAction("category");
                    }
                    


                }
            }
            else
            {
                ViewBag.error2 = "without login you can not perform action";
            }

           

            return View();
        }

        //admin can add products in selected category which he had added (end)



        //admin can view products in his dashboard  (start)
        public ActionResult display_products(int? page,int ? id)
        {
            int pagesize = 9, pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.tbl_product.Where(x => x.cat_id_fk == id).OrderByDescending(x => x.pro_id).ToList();
            IPagedList<tbl_product> pro = list.ToPagedList(pageindex, pagesize);


            return View(pro);
        }


        //admin can view products in his dashboard  (end)



        //image uploading code(start)

        public string upload_image(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";

            int random = r.Next();

            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".png") || extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg"))
                {

                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/upload/" + random + Path.GetFileName(file.FileName);

                    }
                    catch (Exception ex)
                    {
                        path = "-1";

                        //throw;
                    }

                }
                else
                {
                    Response.Write("<script>alert('only jpeg ,jpg,png formate is allowed')</script>");

                }


            }
            else
            {
                Response.Write("<script>alert('please select file')</script>");
                path = "-1";

            }

            return path;
        }

        //image uploading code(end)




        [HttpPost]
       


        //education application it is static

        //public ActionResult edu_app()
        //{

        //    return View();
        //}


        public ActionResult education_application()
        {

            return View();
        }
        //end

        //admin can view user details (start)

        public ActionResult user_details()
        {

            List<tbl_user> li = db.tbl_user.ToList();
            List<tbl_user> us = li.Select(x => new tbl_user
            {
                u_name=x.u_name,
                u_contact=x.u_contact,
                u_email=x.u_email,
                u_password=x.u_password,
                
            }
            
            ).ToList();
             return View(us);
        }

        //admin can view user details (end)


        //admin can view user feedback (start)
        public ActionResult view_feedback()
        {
            

            List<tbl_feedback> lid = db.tbl_feedback.ToList();
            List<feedbackdetails> lvm = lid.Select(x => new feedbackdetails

            {
                name=x.name,
                email=x.email,
                contact_number=x.contact_number,
                feedback=x.feedback,
               
                sugestion =x.sugestion,
                

            }).ToList();


            return View(lvm);
        }

        //admin can view user feedback (end)

        //admin can view user contact  (start)

        public ActionResult user_contact_details()
        {
            List<tbl_contact> cl = db.tbl_contact.ToList();
            List<tbl_contact> con = cl.Select(x => new tbl_contact
            {
               first_name=x.first_name,
               last_name=x.last_name,
               email_id=x.email_id,
               sms=x.sms,
               



            }).ToList();



            return View(con);
        }

        //admin can view user contact  (end)


        //admin can view how much products are purchased by users  (start)
        public ActionResult bussiness()
        {

            List<tbl_order> o = db.tbl_order.ToList();

            List<bussiness_model> lvm = o.Select(x => new bussiness_model

            {
                buyers_name=x.buyers_name,
                ord_productname = x.ord_productname,
                ord_amount = x.ord_amount,
                ord_quantity = x.ord_quantity,
                order_date = x.order_date,
                ord_id = x.ord_id,
                



            }).ToList();



            return View(lvm);
        }


        //admin can view how much products are purchased by user?  (end)



    }
}
