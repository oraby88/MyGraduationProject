using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GraduationProjectModelV1.enums;


namespace GraduationProjectModelV1.Model
{
   public class Seet
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="please select type")]
        public SeetType SeetType { get; set; }
        [Required(ErrorMessage = "please enter number")]
        public int Number { get; set; }


        [Required(ErrorMessage = "please eenter your code ")]
        [Index(IsUnique = true)]
        [StringLength(100)]

        public string Code { get; set; }

        public SingleSeet SingeleSeet { get; set; }
        public MultiSeet MultiSeet { get; set; }


        public Admin Admin { get; set; }
        [ForeignKey("Admin")]
        public int Admin_Id { get; set; }

    }
}
