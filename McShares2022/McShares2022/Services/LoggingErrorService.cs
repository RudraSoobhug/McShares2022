using McShares2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using McShares2022.Interfaces;

namespace McShares2022.Services
{
    public class LoggingErrorService: ILoggingError
    {
        private readonly DBContext _context;
        public LoggingErrorService(DBContext dBContext)
        {
            _context = dBContext;
        }

        public void loggingError(DateTime dt, string description)
        {
            try
            {
                LoggingErrors log = new LoggingErrors();
                log.errorTime = dt;
                log.description = description;
                _context.logErrors.Add(log);
                _context.SaveChanges();
            }
            //
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }  
    }
}
