using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McShares2022.Models
{
    public class UploadFile
    {
        public IFormFile files { get; set; }
    }
}
