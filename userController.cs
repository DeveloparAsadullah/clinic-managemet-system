using clinic_management_system3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace clinic_management_system3.Controllers
{
    public class userController : Controller
    {
        clinic_management_system_2Entities db = new clinic_management_system_2Entities();
        // GET: user


        //user dashboard code all categories can be seen here by user(start)
        public ActionResult Index(int? page)
        {


            if (TempData["cart"] != null)
            {

                double x = 0;

                List<Cadd_to_cart_class> li2 = TempData["cart"] as List<Cadd_to_cart_class>;

                foreach (var item in li2)
                {

                    x += Convert.ToInt32(item.total_bill);


                }

                TempData["total"] = x;


            }
            TempData.Keep();




            int pagesize = 9, pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.tbl_cateogry.Where(x => x.cat_status == 1).OrderByDescending(x => x.cat_id).ToList();
            IPagedList<tbl_cateogry> cat = list.ToPagedList(pageindex, pagesize);


            return View(cat);
        }

        //user dashboard code all categories can be seen here by user(end)


        //about us page for user it is static
        public ActionResult aboutus()
        {

            return View();
        }


        //user can register here code(start)
        public ActionResult signup()
        {

            return View();
        }

        [HttpPost]

        public ActionResult signup(tbl_user us)
        {
            if (ModelState.IsValid == true)
            {
                tbl_user u = new tbl_user();
                u.u_name = us.u_name;
                u.u_email = us.u_email;
                u.u_password = us.u_password;
                u.u_contact = us.u_contact;
                //u.ad_id_fk = us.ad_id_fk;
                db.tbl_user.Add(u);
                db.SaveChanges();
                return RedirectToAction("login");
            }


            return View();
        }

        //user can register here code(end)


        //user login code(start)
        public ActionResult login()
        {

            return View();
        }

        [HttpPost]

        public ActionResult login(tbl_user us)
        {

            tbl_user u = db.tbl_user.Where(x => x.u_password == us.u_password && x.u_email == us.u_email).SingleOrDefault();
            if (u != null)
            {
               
                Session["u_name"] = u.u_name;
                Session["u_id"] = u.u_id;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "invalid email id and password";
            }


            return View();
        }

        //user login code(end)




        //user giving feedback code(start)
        public ActionResult feedback()
        {
            List<tbl_gendar> li = db.tbl_gendar.ToList();
            ViewBag.gen = new SelectList(li, "gen_id", "gendar");

            List<tbl_country> lic = db.tbl_country.ToList();
            ViewBag.cnt = new SelectList(lic, "cnt_id", "cnt_name");

            return View();
        }

        [HttpPost]

        public ActionResult feedback(feedback_model fm)
        {
            if (ModelState.IsValid == true)
            {
                List<tbl_gendar> li = db.tbl_gendar.ToList();
                ViewBag.gen = new SelectList(li, "gen_id", "gendar");

                List<tbl_country> lic = db.tbl_country.ToList();
                ViewBag.cnt = new SelectList(lic, "cnt_id", "cnt_name");


                tbl_feedback f = new tbl_feedback();
                f.name = fm.name;
                f.u_id_fk = Convert.ToInt32(Session["u_id"]);
                f.email = fm.email;
                f.contact_number = fm.contact_number;
                f.feedback = fm.feedback;
                f.sugestion = fm.sugestion;
                f.gen_id_fk = fm.gen_id_fk;
                f.cnt_id_fk = fm.cnt_id_fk;

                db.tbl_feedback.Add(f);
                db.SaveChanges();
                return RedirectToAction("feedback");

            }

            return View();
        }

        //user giving feedback code(end)


        //user contact us code(start)
        public ActionResult contactus()
        {

            return View();
        }

        [HttpPost]

        public ActionResult contactus(tbl_contact cn)
        {
            if (ModelState.IsValid == true)
            {
                tbl_contact c = new tbl_contact();
                c.first_name = cn.first_name;
                c.last_name = cn.last_name;
                c.email_id = cn.email_id;
                c.sms = cn.sms;
                db.tbl_contact.Add(c);
                db.SaveChanges();
                return RedirectToAction("contactus");
            }


            return View();
        }

        //user contact us code(end)






        //user can view categories here code(start)
        public ActionResult display_pro_foruser(int? page, int? id)
        {
            int pagesize = 9, pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.tbl_product.Where(x => x.cat_id_fk == id).OrderByDescending(x => x.pro_id).ToList();
            IPagedList<tbl_product> pro = list.ToPagedList(pageindex, pagesize);


            return View(pro);
        }


        //search products code (start)
        [HttpPost]
        public ActionResult display_pro_foruser(int ? page,int ? id , string search )
        {
            int pagesize = 9, pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.tbl_product.Where(x => x.pro_name.Contains(search)).OrderByDescending(x => x.pro_id).ToList();
            IPagedList<tbl_product> pros = list.ToPagedList(pageindex, pagesize); 



            return View(pros);
        }

        //search products code (end)



        //user can view categories here code(end)

        //user can view details of products in selective categories here code(start)

        public ActionResult details_of_pro(int? id)
        {
            tbl_product p = db.tbl_product.Where(x => x.pro_id == id).SingleOrDefault();
            product_details_class pr = new product_details_class();
            pr.pro_id = p.pro_id;
            pr.pro_name = p.pro_name;
            pr.pro_price = p.pro_price;
            pr.pro_image = p.pro_image;
            pr.pro_desc = p.pro_desc;

            tbl_cateogry c = db.tbl_cateogry.Where(x => x.cat_id == p.cat_id_fk).SingleOrDefault();
            pr.cat_name = c.cat_name;



            return View(pr);
        }
        //user can view details of products in selective categories here code(end)



        //add to cart code start
        public ActionResult add_to_cart(int? id)
        {

            tbl_product p = db.tbl_product.Where(x => x.pro_id == id).SingleOrDefault();


            return View(p);
        }

        List<Cadd_to_cart_class> li = new List<Cadd_to_cart_class>();
        [HttpPost]


        public ActionResult add_to_cart(int? id, string qty)
        {
            List<Cadd_to_cart_class> li = new List<Cadd_to_cart_class>();

            tbl_product p = db.tbl_product.Where(x => x.pro_id == id).SingleOrDefault();
            Cadd_to_cart_class ac = new Cadd_to_cart_class();
            ac.pro_id = p.pro_id;
            ac.ord_productname = p.pro_name;
            ac.pro_price = p.pro_price;
            ac.pro_desc = p.pro_desc;
            ac.ord_quantity = Convert.ToInt32(qty);
            ac.total_bill = ac.pro_price * ac.ord_quantity;

            if (TempData["cart"] == null)
            {
                li.Add(ac);
                TempData["cart"] = li;

            }
            else
            {
                List<Cadd_to_cart_class> li2 = TempData["cart"] as List<Cadd_to_cart_class>;
                li2.Add(ac);
            }
            TempData.Keep();
            return RedirectToAction("Index");



            return View();
        }


        //add to cart code (end)


        //checkout and shop[ now code (start)
        public ActionResult checkout()
        {
            List<Cadd_to_cart_class> li2 = TempData["cart"] as List<Cadd_to_cart_class>;
            TempData.Keep();

           

            return View();
        }

        [HttpPost]
        public ActionResult checkout(tbl_order o)
        {
            List<Cadd_to_cart_class> li2 = TempData["cart"] as List<Cadd_to_cart_class>;



            tbl_invoice iv = new tbl_invoice();
            iv.u_id_fk = Convert.ToInt32(Session["u_id"].ToString());
            iv.inv_date = System.DateTime.Now;
            iv.total_bill = (double)TempData["total"];
            db.tbl_invoice.Add(iv);
            db.SaveChanges();

            foreach (var item in li2)
            {
                tbl_order od = new tbl_order();
                od.buyers_name = Session["u_name"].ToString();
                od.pr_id_fk = item.pro_id;
                od.ord_productname = item.ord_productname;
                od.order_date = System.DateTime.Now;
                od.ord_quantity = item.ord_quantity;
                od.ord_amount = item.pro_price;
                db.tbl_order.Add(od);
                db.SaveChanges();

                return RedirectToAction("Index");
            }


            TempData.Keep();
            return View("");

        }

        //checkout and shop[ now code (end)


        //logout code (start)
        public ActionResult logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("login");
        }


        //end
        



    }


}