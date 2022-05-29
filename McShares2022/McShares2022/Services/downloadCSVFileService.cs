//using McShares2022.Interfaces;
//using McShares2022.Models;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using System.Web;
//using System.Web.Mvc;
//using System;

//namespace McShares2022.Services
//{
//    public class downloadCSVFileService: IDownloadCSVFile
//    {
//        private readonly DBContext _context;
//        downloadCSVFileService(DBContext dBContext)
//        {
//            _context = dBContext;
//        }


//        Microsoft.AspNetCore.Mvc.FileResult IDownloadCSVFile.downloadCSVFile()
//        {
//            DataItem_Customer dataItem_Customer = new DataItem_Customer();

//            List<object> customers = (from customer in _context.dataItem_Customer.ToList().Take(10)
//                                      select new[] { customer.customer_id,
//                                                     customer.Contact_Name,
//                                                     customer.Customer_Type,
//                                                     customer.Num_Shares.ToString(),
//                                                     customer.Share_Price.ToString()
//                                }).ToList<object>();

//            //Insert the Column Names.
//            customers.Insert(0, new string[5] { "Customer ID", "Customer Name", "Customer Type", "Number of Shares", "Share Price" });

//            StringBuilder sb = new StringBuilder();
//            for (int i = 0; i < customers.Count; i++)
//            {
//                string[] customer = (string[])customers[i];
//                for (int j = 0; j < customer.Length; j++)
//                {
//                    //Append data with separator.
//                    sb.Append(customer[j] + ',');
//                }

//                //Append new line character.
//                sb.Append("\r\n");

//            }



//            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Grid.csv");
//        }

//        //private System.Web.Mvc.FileResult File(byte[] vs, string v1, string v2)
//        //{
//        //    throw new NotImplementedException();
//        //}
//    }
//}
