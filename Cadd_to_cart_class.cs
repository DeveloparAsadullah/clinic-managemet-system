using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clinic_management_system3.Models
{
    public class Cadd_to_cart_class
    {
        public int pro_id { get; set; }
        public string pro_name { get; set; }
        public Nullable<int> pro_price { get; set; }
        public string pro_desc { get; set; }
        public string pro_image { get; set; }
        public Nullable<double> ord_amount { get; set; }
        public Nullable<int> ord_quantity { get; set; }
        public string ord_productname { get; set; }

        public Nullable<double> total_bill { get; set; }


    }
}