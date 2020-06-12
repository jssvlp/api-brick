using api_brick.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace api_brick.Services
{
    public class CompanyDataService
    {

        public static CompanyData get()
        {
            using (StreamReader r = new StreamReader("companydata.json"))
            {
                string json = r.ReadToEnd();
                CompanyData data = Newtonsoft.Json.JsonConvert.DeserializeObject<CompanyData>(json);

                return data;
            }
        }

   
        public static bool  update(CompanyData data)
        {
            string output;
            string jsonString;


            output = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);

            try
            {
                File.WriteAllText("companydata.json", output);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
