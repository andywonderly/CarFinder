using CarFinder.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarFinder.Controllers
{
    [RoutePrefix("api/Cars")]
    public class CarsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("Years")]
        public async Task<List<string>> GetYears()
        {
            return await db.Years();
        }

        [Route("ModelYears")]
        public async Task<List<string>> GetModelYears(string model_name, string model_year)
        {
            return await db.ModelYears(model_name, model_year);
        }

        [Route("EngineCylinders")]
        public async Task<List<string>> GetEngineCylinders()
        {
            return await db.EngineCylinders();
        }

        /// <summary>
        /// Get a list of engine sizes
        /// </summary>
        /// <returns></returns>
        [Route("EngineSizes")]
        public async Task<List<string>> GetEngineSizes()
        {
            return await db.EngineSizes();
        }

        [Route("HorsepowerOver300")]
        public async Task<List<string>> GetHorsepowerOver300()
        {
            return await db.HorsepowerOver300();
        }

        [Route("YearMakes")]
        public async Task<List<string>> GetMakes(string model_year)
        {
            return await db.YearMakes(model_year);
        }

        [Route("YearMakeModels")]
        public async Task<List<string>> GetModels(string model_year, string make)
        {
            return await db.YearMakeModels(model_year, make);
        }

        [Route("YearMakeModelTrims")]
        public async Task<List<string>> GetTrims(string model_year, string make, string model_name)
        {
            return await db.YearMakeModelTrims(model_year, make, model_name);
        }

        [Route("WeightUnder2000Kg")]
        public async Task<List<string>> GetWeightUnder2000Kg()
        {
            return await db.WeightUnder2000Kg();
        }

        [Route("WeightUnder2000KgHorsepowerOver300")]
        public async Task<List<string>> GetWeightUnder2000Kg_HorsepowerOver300()
        {
            return await db.WeightUnder2000Kg_HorsepowerOver300();
        }

        [Route("YearMakeModels")]
        public async Task<List<string>> GetYearMakeModels(string model_year, string make, string model_name)
        {
            return await db.YearMakeModels(model_year, make, model_name);
        }

        [Route("YearMakeModelTrims")]
        public async Task<Cars> GetYearMakeModelTrims(string model_year, string make, string model_name, string model_trim)
        {
            return await db.GetCar(model_year, model_name, make, model_trim);
        }

        [Route("YearMakes")]
        public async Task<List<Cars>> GetYearMakes(string model_year, string make)
        {
            return await db.YearMakes(model_year, make);
        }

        

        [Route("GetCarData")]
        public async Task<IHttpActionResult> GetCarData(string model_year = "", string make = "", string model_name = "", string model_trim = "")
        {
            HttpResponseMessage response;
            var content = "";
            var singleCar = await db.GetCar(model_year, make, model_name, model_trim);
            var car = new carViewModel
            {
                Car = singleCar,
                //Car = db.GetCars(year, make, model, trim),
                Recalls = content,
                Images = ""

            };


            //Get recall Data

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.nhtsa.gov/");
                try
                {
                    response = await client.GetAsync("webapi/api/Recalls/vehicle/modelyear/" + model_year + "/make/"
                        + make + "/model/" + model_name + "?format=json");
                    content = await response.Content.ReadAsStringAsync();

                }
                catch (Exception e)
                {
                    return InternalServerError(e);
                }
            }

            car.Recalls = content;


            //////////////////////////////   My Bing Search   //////////////////////////////////////////////////////////

            string query = model_year + " " + make + " " + model_name + " " + model_trim;

            string rootUri = "https://api.datamarket.azure.com/Bing/Search";

            var bingContainer = new Bing.BingSearchContainer(new Uri(rootUri));

            var accountKey = ConfigurationManager.AppSettings["BingAPIKey"]; ;

            bingContainer.Credentials = new NetworkCredential(accountKey, accountKey);


            var imageQuery = bingContainer.Image(query, null, null, null, null, null, null);

            var imageResults = imageQuery.Execute().ToList();


            car.Images = imageResults.First().MediaUrl;

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////

            return Ok(car);

        }
    }
}
