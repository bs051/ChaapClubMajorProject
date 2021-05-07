using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChaapClubMajorProject.Models
{
    public class OrderPlaced
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(200)]
        public string UserID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public float TotalAmount { get; set; }

        [Required]
        public int ClubID { get; set; }


        [ForeignKey("ClubID")]
        [InverseProperty("OrderPlaceds")]
        public virtual ChaapClub ChaapClub { get; set; }
    }
}
