using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clinic_management_system3.Models
{
    public class order_now_class
    {
        public int sci_id { get; set; }
        public string sci_name { get; set; }
        public string sci_image { get; set; }
        public Nullable<double> sci_price { get; set; }
        public string sci_desc { get; set; }
        public int med_id { get; set; }
        public string med_code { get; set; }
        public string med_name { get; set; }
        public string med_type { get; set; }
        public Nullable<double> med_price { get; set; }

        public int ord_id { get; set; }
        public string ord_productname { get; set; }
        public Nullable<double> ord_amount { get; set; }
        public Nullable<int> ord_quantity { get; set; }
        public Nullable<System.DateTime> order_date { get; set; }

        public Nullable<int> ad_id_fk { get; set; }
        public Nullable<int> sci_id_fk { get; set; }
        public Nullable<int> med_id_fk { get; set; }
        public Nullable<int> edu_id_fk { get; set; }
        public Nullable<int> bu_id_fk { get; set; }
        public Nullable<int> u_id_fk { get; set; }

        public Nullable<double> total_bill { get; set; }
    }
}