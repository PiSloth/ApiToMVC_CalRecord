using System;
namespace POSMCVCalculator.Models

{
    public class CalogDataModel
    {
        public int id { get; set; }
        public int gold { get; set; }
        public int tax { get; set; }
        public string time { get; set; }
        public string date { get; set; }
    }

    public class CalogViewModel
    {
        public string date { get; set; }
        public int price { get; set; }
    }

    public class SplineAreaChartModel
    {
        public List<int> Data { get; set; }  
        public List<string> Categories { get; set; }
    }


}

