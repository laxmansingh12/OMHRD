using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SBMS.Models;
using SBMS.BAL;
using System.Collections.Generic;
using System;
using System.Data;

namespace SBMSservices.Services
{
    public class DTtoObj
    {
        AdminBL _AdminBL;
        public DTtoObj()
        {
            _AdminBL = new AdminBL();
        }
        public CompanyModel GetCompanyProfile() {
            return _AdminBL.GetCompanyProfile().AsEnumerable()
                .Select(row => new CompanyModel() {
                    Id = row["Id"] == DBNull.Value ? 0 : Convert.ToInt32(row["Id"]),
                    Name = row["Name"] == DBNull.Value ? string.Empty : Convert.ToString(row["Name"]),
                   Code  = row["CompanyCode"] == DBNull.Value ? string.Empty : Convert.ToString(row["CompanyCode"]),
                    Logo = (byte[])row["Logo"],
                    RegistrationNo = row["RegistrationNo"] == DBNull.Value ? string.Empty : Convert.ToString(row["RegistrationNo"]),
                    Website = row["Website"] == DBNull.Value ? string.Empty : Convert.ToString(row["Website"]),
                    Fax = row["Fax"] == DBNull.Value ? string.Empty : Convert.ToString(row["Fax"]),
                    PAN = row["PAN"] == DBNull.Value ? string.Empty : Convert.ToString(row["PAN"]),
                    GSTN = row["GSTN"] == DBNull.Value ? string.Empty : Convert.ToString(row["GSTN"]),
                    Email = row["Email"] == DBNull.Value ? string.Empty : Convert.ToString(row["Email"]),
                    Address = row["Address"] == DBNull.Value ? string.Empty : Convert.ToString(row["Address"]),
                    City = row["City"] == DBNull.Value ? string.Empty : Convert.ToString(row["City"]),
                    StateId = row["StateId"] == DBNull.Value ? 0 : Convert.ToInt32(row["StateId"]),
                    IsLogoChanaged = Convert.ToBoolean(row["StateId"]),
                    State = row["State"] == DBNull.Value ? string.Empty : Convert.ToString(row["State"]),
                    Zip = row["Zip"] == DBNull.Value ? string.Empty : Convert.ToString(row["Zip"]),
                    Description1 = row["Description1"] == DBNull.Value ? string.Empty : Convert.ToString(row["Description1"]),
                    Description2 = row["Description2"] == DBNull.Value ? string.Empty : Convert.ToString(row["Description2"]),
                    ContactNum = row["ContactNo"] == DBNull.Value ? string.Empty : Convert.ToString(row["ContactNo"]),
                    AlternateContactNo = row["AlternateContactNo"] == DBNull.Value ? string.Empty : Convert.ToString(row["AlternateContactNo"]),
                    TermsConditions = row["TermsConditions"] == DBNull.Value ? string.Empty : Convert.ToString(row["TermsConditions"])
                    // Code = row["Code"] == DBNull.Value ? string.Empty : Convert.ToString(row["Code"]),
                   
                }).FirstOrDefault();
        }
    }
}