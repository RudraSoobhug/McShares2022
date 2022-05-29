using McShares2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McShares2022.Interfaces
{
    public interface IValidateXMLFile
    {
        public bool ValidateXmlFile(UploadFile obj);
    }
}
