using McShares2022.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace McShares2022.Interfaces
{
    public class SaveXMLDataService : IStoreXMLData
    {
        private readonly DBContext _context;
        private readonly ILoggingError _ilogError;
        private readonly IValidateXMLFile _iValidate;
        public SaveXMLDataService(DBContext dBContext, ILoggingError ilogError, IValidateXMLFile iValidate)
        {
            _context = dBContext;
            _ilogError = ilogError;
            _iValidate = iValidate;
        }

        public bool save(UploadFile obj)
        //public void save(XmlDocument xmlDoc)
        {
            Boolean isNotValid = _iValidate.ValidateXmlFile(obj);

            if (!isNotValid)
            {
                //Loads the xml file
                XDocument xmlDoc = XDocument.Load(obj.files.OpenReadStream());
                var xmlDocument = xmlDoc.ToXmlDocument();

                RequestDocument requestDocument = new RequestDocument();

                requestDocument.Doc_Ref = xmlDocument.GetElementsByTagName("Doc_Ref")[0].InnerText;
                requestDocument.Doc_Date = Convert.ToDateTime(xmlDocument.GetElementsByTagName("Doc_Date")[0].InnerText);

                //check if refDoc exists
                var isRefDocExist = checkIfEXistDocRef(requestDocument.Doc_Ref);

                if (!isRefDocExist)
                {
                    _context.requestDocument.Add(requestDocument);

                    for (int i = 0; i < xmlDocument.GetElementsByTagName("DataItem_Customer").Count; i++)
                    {
                        DataItem_Customer dataItem_Customer = new DataItem_Customer();

                        dataItem_Customer.customer_id = xmlDocument.GetElementsByTagName("DataItem_Customer")[i].ChildNodes[0].InnerXml;
                        dataItem_Customer.Customer_Type = xmlDocument.GetElementsByTagName("DataItem_Customer")[i].ChildNodes[1].InnerXml;

                        if (xmlDocument.GetElementsByTagName("DataItem_Customer")[i].ChildNodes[2].InnerXml != "")
                        {
                            dataItem_Customer.Date_Of_Birth = Convert.ToDateTime(xmlDocument.GetElementsByTagName("DataItem_Customer")[i].ChildNodes[2].InnerXml);
                        }

                        if (xmlDocument.GetElementsByTagName("DataItem_Customer")[i].ChildNodes[3].InnerXml != "")
                        {
                            dataItem_Customer.Date_Incorp = Convert.ToDateTime(xmlDocument.GetElementsByTagName("DataItem_Customer")[i].ChildNodes[3].InnerXml);
                        }

                        if (xmlDocument.GetElementsByTagName("DataItem_Customer")[i].ChildNodes[4].InnerXml != "")
                        {
                            dataItem_Customer.REGISTRATION_NO = xmlDocument.GetElementsByTagName("DataItem_Customer")[i].ChildNodes[4].InnerXml;
                        }

                        //Mailing_Address
                        dataItem_Customer.Address_Line1 = xmlDocument.GetElementsByTagName("DataItem_Customer")[i].ChildNodes[5].ChildNodes[0].InnerText;
                        dataItem_Customer.Address_Line2 = xmlDocument.GetElementsByTagName("DataItem_Customer")[i].ChildNodes[5].ChildNodes[1].InnerText;
                        dataItem_Customer.Town_City = xmlDocument.GetElementsByTagName("DataItem_Customer")[i].ChildNodes[5].ChildNodes[2].InnerText;
                        dataItem_Customer.Country = xmlDocument.GetElementsByTagName("DataItem_Customer")[i].ChildNodes[5].ChildNodes[3].InnerText;

                        //Contact_Details
                        dataItem_Customer.Contact_Name = xmlDocument.GetElementsByTagName("DataItem_Customer")[i].ChildNodes[6].ChildNodes[0].InnerText;

                        if (xmlDocument.GetElementsByTagName("DataItem_Customer")[i].ChildNodes[6].ChildNodes[1].InnerText != "")
                        {
                            dataItem_Customer.Contact_Number = xmlDocument.GetElementsByTagName("DataItem_Customer")[i].ChildNodes[6].ChildNodes[1].InnerText;
                        }

                        //Shares_Details
                        dataItem_Customer.Num_Shares = Int32.Parse(xmlDocument.GetElementsByTagName("DataItem_Customer")[i].ChildNodes[7].ChildNodes[0].InnerText);
                        dataItem_Customer.Share_Price = Decimal.Parse(xmlDocument.GetElementsByTagName("DataItem_Customer")[i].ChildNodes[7].ChildNodes[1].InnerText);

                        dataItem_Customer.request_Document_Id = requestDocument.request_Document_Id;

                        _context.dataItem_Customer.Add(dataItem_Customer);
                        _context.SaveChanges();

                    }
                    return true;
                }

                try
                {
                    _ilogError.loggingError(DateTime.Now, "Data duplication: Data already Exist!");
                }
                catch (Exception)
                {

                    throw;
                }
                return false;
            }

            
            else
            {
                //XML file not valid
                _ilogError.loggingError(DateTime.Now, "XML file Validation failed!");
                return false;
              
            }

            bool checkIfEXistDocRef(string docRef)
            {
                var isExist = _context.requestDocument.Where(df => df.Doc_Ref == docRef).ToList();
                return isExist.Any() ? true : false;
            }
        }
    }
}

    public static class DocumentExtensions
    {
        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }
    }


