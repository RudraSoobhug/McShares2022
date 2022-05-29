using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace McShares2022.Models
{
    public class RequestDocument
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int request_Document_Id { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Doc_Date { get; set; }
        public string Doc_Ref { get; set; }
    }
}
