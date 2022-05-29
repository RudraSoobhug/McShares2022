using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using McShares2022.Models;

namespace McShares2022.Interfaces
{
    public interface IStoreXMLData
    {
        public bool save(UploadFile xmlDoc);
    }
}
