using McShares2022.Interfaces;
using McShares2022.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McShares2022.Controllers
{
    public class storingXMLDataController : Controller
    {
        private readonly IStoreXMLData _ISaveXMLData;

        public storingXMLDataController(IStoreXMLData iSaveXMLData)
        {
            _ISaveXMLData = iSaveXMLData;
        }

        [HttpPost]
        //[Authorize] uncomment for authentication
        [Route("uploadAndSave")]
        public IActionResult uploadAndSave([FromForm] UploadFile obj)
        {
            try
            {
                return _ISaveXMLData.save(obj) ? Ok("XML data successfully saved to sql server") : Ok("Data duplication: Cannot save data to sql server");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{e.Message}");
            }
        }
    }
}
