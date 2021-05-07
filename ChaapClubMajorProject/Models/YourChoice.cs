using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChaapClubMajorProject.Models
{
    // chaap club accoriding to your choice
    public class YourChoice
    {
        [Key]
        public int ChoiceID { get; set; }

        [Required]
        [StringLength(100)]
        public string ChoiceName { get; set; }

        public virtual ICollection<ChaapClub> ChoiceFood { get; set; }
    }
}
