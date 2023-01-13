// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Data;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;

const string path =
    @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
HttpClient _client = new HttpClient();


static async Task<Stream> GetStreamData()
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
        yield return line.Replace("Korea", "Korea - ");
    }
    
}

static DateTime[] GetDates() => GetDataString().First().Split(',').Skip(4)
    .Select(l => DateTime.Parse(l, CultureInfo.InvariantCulture)).ToArray();



static IEnumerable<(string Country, string Province, string [] counts)> GetData()
{
    var dataLines = GetDataString().Skip(1).Select(l => l.Split(','));
    foreach (var line in dataLines)
    {
        var province = line[0].Trim();
        var country = line[1].Trim(' ', '"');
        var counts = line.Skip(4).ToArray();
        yield return (country, province, counts);
    }
}


var data = GetData().First(x => x.Country.Equals("Russia", StringComparison.OrdinalIgnoreCase));

Console.WriteLine(string.Join("\r\n", GetDates().Zip(data.counts, (date, count) => $"{date} - {count}")));

 
