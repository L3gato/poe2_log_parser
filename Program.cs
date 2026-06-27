using System.Text.RegularExpressions;
using cstest2;

StreamReader reader;

try {
    reader = File.OpenText("Client.txt");
} catch(Exception e) {
    Console.WriteLine("Exception: " + e.Message);
    return;
}
if (reader == null) return;

var pattern = @"^(?<AreaDate>\d{4}/\d{2}/\d{2}).*?Generating level (?<AreaLevel>\d+) area ""(?<AreaName>[^""]+)"" with seed (?<AreaSeed>\d+)";

Dictionary<double, LogEntry> map = new Dictionary<double, LogEntry>();

while (true) {
    string line;
    try {
        line = reader.ReadLine()!;
    } catch (IOException ex) {
        Console.WriteLine(ex.Message);
        break;
    }
    if (line == null) break;

    var match = Regex.Match(line, pattern);

    if (match.Success) {
        double seed = double.TryParse(match.Groups["AreaSeed"].Value, out var tpSeed) ? tpSeed : -1;

        var entry = new LogEntry {
            Date = DateTime.Parse(match.Groups["AreaDate"].Value),
            AreaName = match.Groups["AreaName"].Value,
            AreaLevel = int.TryParse(match.Groups["AreaLevel"].Value, out var tpLevel) ? tpLevel : -1,
            Seed = seed
        };

        map.TryAdd(seed, entry);
    }

}

var logic = new Logic(map);
Console.WriteLine($"{logic.getMapInfo()}\n\n{logic.getSimuInfo()}\n\n{logic.getAnomalyInfo()}\n\n{logic.getBossInfo()}\n\n{logic.getExpeditionInfo()}");
Console.ReadLine();