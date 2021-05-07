using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChaapClubMajorProject.Models
{
    public class ChaapClub
    {
        [Key]
        public int ClubID { get; set; }

        [Required]
        [StringLength(200)]
        public string FoodName { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [StringLength(20)]
        public string Extension { get; set; }

        [Required]
        public float Price { get; set; }


        [Required]
        public int ChoiceID { get; set; }

        [Required]
        public int ExpoID { get; set; }

        [ForeignKey("ChoiceID")]
        [InverseProperty("ChoiceFood")]
        public virtual YourChoice YourChoice { get; set; }

        [ForeignKey("ExpoID")]
        [InverseProperty("ExpoFood")]
        public virtual FoodExpo ExpoFood { get; set; }

        public virtual ICollection<OrderPlaced> OrderPlaceds { get; set; }

        [NotMapped]
        public SingleFileUpload File { get; set; }

    }

    public class SingleFileUpload
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
