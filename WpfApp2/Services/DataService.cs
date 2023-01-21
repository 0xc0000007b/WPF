using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Models;

namespace WpfApp2.Services;

public class DataService
{
   private  const string path =
        @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
    
   private static async Task<Stream> GetStreamData()
   {
       var _client = new HttpClient();
       var resp =  _client.GetAsync(path, HttpCompletionOption.ResponseHeadersRead).Result;
       return await resp.Content.ReadAsStreamAsync();
   }
   
   static   IEnumerable<string> GetDataString()
   {
       using var stream_data =  GetStreamData().Result;
       using var reader = new StreamReader(stream_data);

       while (!reader.EndOfStream)
       {
           var line =  reader.ReadLine();
           if (string.IsNullOrWhiteSpace(line)) ;
           yield return line.Replace("Korea", "Korea - ").Replace("Bonaire,","Bonaire - ");
       }
    
   }
   
   static DateTime[] GetDates() => GetDataString().First().Split(',').Skip(4)
       .Select(l => DateTime.Parse(l, CultureInfo.InvariantCulture)).ToArray();



   static IEnumerable<(string Country, string Province,(double longitude, double latitude) Place, string [] counts)> GetCountriesData()
   {
       var dataLines = GetDataString().Skip(1).Select(l => l.Split(','));
       foreach (var line in dataLines)
       {
           var province = line[0].Trim();
           var country = line[1].Trim(' ', '"');
           var latitude = double.Parse(line[2]);
           var longitude = double.Parse(line[2]);
           var counts = line.Skip(4).ToArray();
           yield return (country, province, (longitude, latitude), counts);
       }
   }

   public IEnumerable<Country> GetData()
   {
       var dates = GetDates();
       var data = GetCountriesData().GroupBy(x => x.Country);
       foreach (var country in data)
       {
          
           var c = new Country
           {
                Name = country.Key,
                Province = country.Select(x => new PlaceInfo
                {
                    Name = x.Province,
                    Location = new Point(x.Place.latitude, x.Place.longitude),
                    Count = dates.Zip(x.counts, (date,count) => new ConfirmrdCounts{Date = date, Count = count})
                })
           };
           yield return c;
       }
       
   }
}