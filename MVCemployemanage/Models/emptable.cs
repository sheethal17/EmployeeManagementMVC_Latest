namespace MVCemployemanage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("emptable")]
    public partial class emptable
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Column("first name")]
        [StringLength(50)]
        public string first_name { get; set; }


        [Required(ErrorMessage = "This field is required!")]
        [StringLength(50)]
        public string lastname { get; set; }


        [Required(ErrorMessage = "This field is required!")]
        [StringLength(50)]
        [EmailAddress()]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }


        [Required(ErrorMessage = "This field is required!")]
        [Column(TypeName = "date")]
        public DateTime? dob { get; set; }


        [Required(ErrorMessage = "This field is required!")]
        [StringLength(50)]
        public string gender { get; set; }



        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(50)]
        public string password { get; set; }


        [Required(ErrorMessage = "conform password is required!")]
        [DataType(DataType.Password)]
        [Compare("password")]
        [StringLength(50)]
        public string conformpassword { get; set; }



    }
}
