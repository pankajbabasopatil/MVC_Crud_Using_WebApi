using System.ComponentModel.DataAnnotations;

namespace CRUDAppUsingWebAPI.Models
{
    public class Expances
    {
        public int id { get; set; }
        [Required]
        public string expenseDate { get; set; }
        [Required]
        public string dayOfWeek { get; set; }
        [Required]
        public float spentAmount { get; set; }
        [Required]
        public float totalAmount { get; set; }
    }
}

