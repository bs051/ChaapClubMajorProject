using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChaapClubMajorProject.Models
{
    public class FoodExpo
    {
        [Key]
        public int ExpoID { get; set; }


        [Required]
        [StringLength(100)]
        public string ExpoName { get; set; }

        public virtual ICollection<ChaapClub> ExpoFood { get; set; }
    }
}
