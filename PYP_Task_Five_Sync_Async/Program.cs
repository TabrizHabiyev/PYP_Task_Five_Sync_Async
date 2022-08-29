using System.Diagnostics;


// Url list
List<string> urls = new List<string>(){
    "http://www.cnn.com",
    "http://www.bbc.com",
    "http://www.bleacherreport.com",
    "http://www.espn.com",
    "http://www.foxsports.com",

};


#region  Async
var tasks = new List<Task>();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(new String('-', 50) + "ASYNC" + new String('-', 50));
Console.ResetColor();

foreach (var url in urls)
{
    tasks.Add(Task.Run(() =>
    {
        var client = new HttpClient();
        var result = client.GetStringAsync(url).Result;
        var length = result.Length;
        Console.WriteLine($"{url} - {length}");
    }));
}
Stopwatch sw = Stopwatch.StartNew();
Task.WaitAll(tasks.ToArray());
sw.Stop();
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"Second - > {sw.ElapsedMilliseconds}");
Console.ResetColor();
sw.Restart();
#endregion


Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(new String('-', 50)+"SYNC"+new String('-',50));
Console.ResetColor();

#region Sync
Stopwatch swSync = Stopwatch.StartNew();
foreach (var url in urls)
{
    var client = new HttpClient();
    var result = client.GetStringAsync(url).Result;
    var length = result.Length;
    Console.WriteLine($"{url} - {length}");
}
swSync.Stop();
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"Second - > {swSync.ElapsedMilliseconds}");
Console.ResetColor();
#endregion