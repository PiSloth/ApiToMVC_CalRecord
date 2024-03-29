using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POSMCVCalculator.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POSMCVCalculator.Controllers
{
    public class CalculatorLogController : Controller
    {

        public async Task<IActionResult> Index()
        {

            SplineAreaChartModel model = new SplineAreaChartModel();

            var json = GetData();
            var ViewData = await json;

            var Data2 = ViewData.Select(x => x.price).ToList();
            var Categories2 = ViewData.Select(x => x.date).ToList();


            //Example Data
            //var Data = new List<int> { 31, 40, 28, 51, 42, 109, 100 };
            //var Categories = new List<string> { "2018-09-19T00:00:00.000Z", "2018-09-19T01:30:00.000Z", "2018-09-19T02:30:00.000Z", "2018-09-19T03:30:00.000Z", "2018-09-19T04:30:00.000Z", "2018-09-19T05:30:00.000Z", "2018-09-19T06:30:00.000Z" };

            
            model.Data = Data2;
            model.Categories = Categories2;

            return View(model);

        }
        private async Task<List<CalogViewModel>> GetData()
        {
            HttpClient client = new HttpClient();
            // Intance of models 
            //List<CalogDataModel> ApiData = new List<CalogDataModel>();
            //List<CalogViewModel> ViewData = new List<CalogViewModel>();

            var response = await client.GetAsync("http://192.168.31.240:5050/api/calculatorapi");
                string json = await response.Content.ReadAsStringAsync();
            List<CalogDataModel> ApiData = JsonConvert.DeserializeObject<List<CalogDataModel>>(json)!;

            List<CalogViewModel> ViewData = ApiData.Select(log => new CalogViewModel
            {
                date = log.date,
                price = log.gold,
            }).ToList() ;

            return ViewData;
        }

    }
}

