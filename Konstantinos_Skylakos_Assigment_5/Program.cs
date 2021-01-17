using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Konstantinos_Skylakos_Assigment_5
{
	public class Program
	{
		public static List<Entry> entries = new List<Entry>();
		public static List<Roomtype> roomtypes = new List<Roomtype>();
        public static List<string> cities;
        public static List<string> filters = new List<string>();
        public static double minPrice = 0, maxPrice = 2000;


        public static void Main(string[] args)
        {
            LoadEntities();

            CreateCities();

            CreateFilters();

            CreateHostBuilder(args).Build().Run();
        }

        private static void LoadEntities()
		{
            string fileName = "wwwroot/data.json";
            string jsonString = File.ReadAllText(fileName);

            var models = JsonSerializer.Deserialize<List<Object>>(jsonString);
            foreach (var item in models)
            {
                string strItem = item.ToString();
                int sepIdx = strItem.IndexOf(":");
                string modelName = strItem.Substring(2, sepIdx - 3);

                jsonString = strItem.Substring(sepIdx + 1);
                jsonString = jsonString.Substring(0, jsonString.Length - 1);

                switch (modelName)
                {
                    case "roomtypes":
                        roomtypes = JsonSerializer.Deserialize<List<Roomtype>>(jsonString);
                        break;

                    case "entries":
                        entries = JsonSerializer.Deserialize<List<Entry>>(jsonString);
                        break;

                    default:
                        break;
                }
            }     
		}

        private static void CreateCities()
		{
            cities = (from s in entries select s.city).ToList();
            cities = cities.Distinct().ToList();
        }

        private static void CreateFilters()
		{
			foreach (var entry in entries)
			{
               
				foreach (var filter in entry.filters)
				{
                    filters.Add(filter.name);
				}
			}

            filters = filters.Distinct().ToList();
        }

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
