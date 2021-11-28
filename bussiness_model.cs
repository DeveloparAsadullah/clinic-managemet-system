using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clinic_management_system3.Models
{
    public class bussiness_model
    {
        public int ord_id { get; set; }
        public string ord_productname { get; set; }
        public Nullable<int> ord_quantity { get; set; }
        public Nullable<double> total_bill { get; set; }
       
        public Nullable<double> ord_amount { get; set; }
        public Nullable<System.DateTime> order_date { get; set; }

        public string buyers_name { get; set; }


    }
}