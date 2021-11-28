using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clinic_management_system3.Models
{
    public class view_model_medicane
    {
        public string med_code { get; set; }
        public string med_name { get; set; }
        public string med_type { get; set; }
        public Nullable<double> med_price { get; set; }
        public Nullable<int> med_status { get; set; }

    }
}