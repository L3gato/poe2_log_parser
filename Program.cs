using System.Text.RegularExpressions;
using poe2_log_parser;

internal class Program
{
    private static readonly DateTime lastLeagueStartDate = new DateTime(2026, 5, 29);

    private static void Main(string[] args)
    {
        using var stream = new FileStream(
            "Client.txt",
            FileMode.Open,
            FileAccess.Read,
            FileShare.ReadWrite
        );

        using var reader = new StreamReader(stream);

        var pattern = @"^(?<AreaDate>\d{4}/\d{2}/\d{2}).*?Generating level (?<AreaLevel>\d+) area ""(?<AreaName>[^""]+)"" with seed (?<AreaSeed>\d+)";

        Dictionary<double, LogEntry> map = new Dictionary<double, LogEntry>();

        while (true)
        {
            string line;
            try
            {
                line = reader.ReadLine()!;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                break;
            }
            if (line == null) break;

            var match = Regex.Match(line, pattern);

            if (match.Success)
            {
                double seed = double.TryParse(match.Groups["AreaSeed"].Value, out var tpSeed) ? tpSeed : -1;
                DateTime date = DateTime.Parse(match.Groups["AreaDate"].Value);

                if (date < lastLeagueStartDate) 
                    continue;

                var entry = new LogEntry
                {
                    Date = date,
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
    }
}