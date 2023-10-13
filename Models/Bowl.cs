using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ishu_Bowl.Models
{
    public class Bowl
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [Required]
        [StringLength(30)]
        public string Material { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public bool MicrowaveSafe { get; set; }

        [Range(1, 40)]
        public int Depth { get; set; }

        [Required]
        public RatingScale Rating { get; set; }
    }


    public enum RatingScale
    {
        [Display(Name = "Bad")]
        One = 1,

        [Display(Name = "Mild")]
        Two = 2,

        [Display(Name = "Okay")]
        Three = 3,

        [Display(Name = " Good")]
        Four = 4,

        [Display(Name = " Superb")]
        Five = 5

    }
}
