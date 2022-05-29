using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McShares2022.Interfaces
{
    public interface IDownloadCSVFile
    {
        public FileResult downloadCSVFile();

    }
}
