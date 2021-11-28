using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clinic_management_system3.Models
{
    public class product_details_class
    {

        public int pro_id { get; set; }
        public string pro_name { get; set; }
        public Nullable<int> pro_price { get; set; }
        public string pro_desc { get; set; }
        public string pro_image { get; set; }
        public int cat_id { get; set; }
        public string cat_name { get; set; }
        public Nullable<int> cat_id_fk { get; set; }
    }
}