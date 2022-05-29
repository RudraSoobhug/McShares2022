using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace McShares2022.Models
{
    public class DataItem_Customer
    {
        [Required]
        public string customer_id { get; set; }
        public string Customer_Type { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? Date_Of_Birth { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? Date_Incorp { get; set; }

        public string? REGISTRATION_NO { get; set; }

        public string Address_Line1 { get; set; }
        public string Address_Line2 { get; set; }
        public string Town_City { get; set; }
        public string Country { get; set; }
        public string Contact_Name { get; set; }
        public string? Contact_Number { get; set; }
        public int Num_Shares { get; set; }
        public decimal Share_Price { get; set; }

        [ForeignKey("DocumentData")]
        public int request_Document_Id { get; set; }
        public virtual RequestDocument requestDocument { get; set; }
    }
}
