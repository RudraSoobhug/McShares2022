using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McShares2022.Interfaces
{
    public interface ILoggingError
    {
        public void loggingError(DateTime dt, string description);
    }
}
