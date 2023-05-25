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
    public class Food
    {
        public int Id { get; set; }
        [StringLength(70)]
        [Required(ErrorMessage = "please enter drink Name")]
        public string Name { get; set; }
        [Column(TypeName = "money")]
        [Required(ErrorMessage = "please enter the buyment cost")]
        public decimal Buy { get; set; }
        [Column(TypeName = "money")]
        [Required(ErrorMessage = "please enter the salies ")]
        public decimal Sale { get; set; }
        [Column(TypeName = "money")]
        [Required(ErrorMessage = "please enter the profit ")]
        public decimal Profit { get; set; }
        [Required(ErrorMessage = "please enter amount")]
        public int Amonut { get; set; }


        [Required(ErrorMessage = "please eenter your code ")]
        [Index(IsUnique = true)]
        [StringLength(100)]

        public string Code { get; set; }

        [Required]
        public TypeOfFoodAndDrink Type { get; set; }

        [ForeignKey("Admin")]
        public int Admin_Id { get; set; }
        public Admin Admin { get; set; }

    }
}
