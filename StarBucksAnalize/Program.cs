using StarBucksLibrary;
using System.Text;
using System.Text.Json;

Console.ForegroundColor = ConsoleColor.Gray;

HttpClient client = new HttpClient();
HttpResponseMessage response;

response = await client.GetAsync($"https://product.starbucks.co.jp/api/category-product-list/beverage/index.json");
response.EnsureSuccessStatusCode();
if (response.StatusCode != System.Net.HttpStatusCode.OK)
{
    Console.WriteLine("ssttaarrbbuucckkssへの通信に失敗したので、検索システムを終了します");
    return;
}
string ssApiResponseBody = await response.Content.ReadAsStringAsync();


var productResponse = JsonSerializer.Deserialize<List<ProductModelRecord>?>(ssApiResponseBody);

string writeFileName = "./products.csv";
// todo読み込んだjsonの特殊文字列のshift-jis読み込み
EncodingProvider provider = System.Text.CodePagesEncodingProvider.Instance;
var encoding = provider.GetEncoding("shift-jis");
FileStream fs = null;
try
{

    fs = new FileStream(writeFileName, FileMode.OpenOrCreate);
    using (StreamWriter writer = new StreamWriter(fs, encoding))
    {
        writer.WriteLine("\"商品id\",\"価格\",\"発売日\",\"備考\"");
        Console.WriteLine($"商品データの登録を開始しました");
        foreach (var item in productResponse) {
            var csvLine = new List<String>();
            csvLine.Add($"\"{item.Id}\"");
            csvLine.Add($"\"{item.Price}\"");
            csvLine.Add($"\"{item.SalesDay}\"");
            csvLine.Add($"\"{item.ProductNote}\"");
            writer.WriteLine(String.Join(",", csvLine.ToArray()));
        }
        Console.WriteLine($"{productResponse.Count}件の商品データを登録完了しました");
    }
    if (fs != null)
        fs.Dispose();
}
finally
{
}
