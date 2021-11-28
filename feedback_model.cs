using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinic_management_system3.Models
{
    public class feedback_model
    {
        //public int feed_id { get; set; }
        [Required(ErrorMessage = "enter feedback")]
        public string feedback { get; set; }
        [Required(ErrorMessage = "enter name")]
        public string name { get; set; }
        [Required(ErrorMessage = "enter registered user email")]
        public string email { get; set; }
        [Required(ErrorMessage = "enter contact number")]
        public string contact_number { get; set; }
        
        [Required(ErrorMessage = "select gendar")]
        public Nullable<int> gen_id_fk { get; set; }
        [Required(ErrorMessage = "select country")]
        public Nullable<int> cnt_id_fk { get; set; }
        [Required(ErrorMessage = "enter suggestion")]
        public string sugestion { get; set; }
        
        public string gendar { get; set; }
    
        public string cnt_name { get; set; }

        public Nullable<int> u_id_fk { get; set; }
       



    }
}