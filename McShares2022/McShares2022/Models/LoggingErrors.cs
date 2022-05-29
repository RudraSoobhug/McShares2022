using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace McShares2022.Models
{
    public class LoggingErrors
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int errorID { get; set; }
        public DateTime errorTime { get; set; }
        public string description { get; set; }
    }
}
