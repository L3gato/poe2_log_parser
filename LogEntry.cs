using System;

namespace cstest2;

public class LogEntry
{
    public DateTime Date { get; set; }
    public string AreaName { get; set; } = "";
    public int AreaLevel { get; set; }
    public double Seed { get; set; }

    public override string ToString()
    {
        return $"Date: {Date} Level {AreaLevel}: {AreaName} (seed {Seed})";
    }
}