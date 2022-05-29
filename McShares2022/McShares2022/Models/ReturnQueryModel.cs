using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McShares2022.Models
{
    public class ReturnQueryModel
    {
        public string customer_id { get; set; }
        public string CustomerName { get; set; } 
        public DateTime? Date_Of_Birth { get; set; }
        public DateTime? Date_Incorp { get; set; }
        public string Customer_Type { get; set; }
        public int Num_Shares { get; set; }
        public decimal Share_Price { get; set; }
        public decimal Balance { get; set; }
    }
}
