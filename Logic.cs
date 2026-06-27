using System;
using System.Collections.Immutable;

namespace cstest2;

public class Logic {

    private readonly Dictionary<double, LogEntry> _dict;

    public Logic(Dictionary<double, LogEntry> dict) {
        _dict = dict;
    }

    public String getMapInfo() {
        return $"WAYSTONES\n{getBaseLvlCountString(getLog(AREAS.MAP))}";
    }

    public String getSimuInfo() {
        return $"SIMULACRUM\n{getBaseLvlCountString(getLog(AREAS.SIMULACRUM))}";
    }

    public String getAnomalyInfo() {
        var list = getAnomalies();

        var output = $"Total: {list.Count}\nBy Name: {string.Join(" ", 
            list.GroupBy(e => e.AreaName)
                .Select(g => $"[{AREAS.getReadableName(g.Key)} -> {g.ToList().Count()}]")
        )}";

        return $"ANOMALIES\n{output}";
    }

    public String getBossInfo() {
        var list = getBosses();

        var output = $"Total: {list.Count}\nBy Name: {string.Join(" ", 
            list.GroupBy(e => e.AreaName)
                .Select(g => $"[{AREAS.getReadableName(g.Key)} -> {g.ToList().Count()}]")
        )}";

        return $"BOSSES\n{output}";
    }

    public String getExpeditionInfo() {
        var list = getExpedition();

        var output = $"Total: {list.Count}\nBy Name: {string.Join(" ", 
            list.Select(e => {
                    if (e.AreaName.StartsWith(AREAS.EXPEDITION_LOGBOOK)) {
                        e.AreaName = AREAS.EXPEDITION_LOGBOOK;
                    }
                    return e;
                })
                .GroupBy(e => e.AreaName)
                .Select(g => $"[{AREAS.getReadableName(g.Key)} -> {g.ToList().Count()}]")
        )}";

        return $"EXPEDITION\n{output}";
    }

    private List<LogEntry> getExpedition() {
        return _dict.Values
            .Where(filterExpedition)
            .ToList();
    }

   private bool filterExpedition(LogEntry entry) {
        switch (entry.AreaName) {
            case AREAS.EXPEDITION_BOSS_ABERRATION:
            case AREAS.EXPEDITION_BOSS_MEDVED:
            case AREAS.EXPEDITION_BOSS_OLROTH:
            case AREAS.EXPEDITION_BOSS_UHTRED:
            case AREAS.EXPEDITION_BOSS_VORANA:
            case AREAS.EXPEDITION_LOGBOOK:
                return true;
            default:
                return false;
        }
    }

    private List<LogEntry> getBosses() {
        return _dict.Values
            .Where(filterBosses)
            .ToList();
    }

    private bool filterBosses(LogEntry entry) {
        switch (entry.AreaName) {
            case AREAS.BOSS_ARBITER_ASH:
            case AREAS.BOSS_ARBITER_DIVINE:
            case AREAS.BOSS_BODACH:
            case AREAS.BOSS_DORYANI:
            case AREAS.BOSS_GEONOR:
            case AREAS.BOSS_HIVE:
            case AREAS.BOSS_JAMANRA:
            case AREAS.BOSS_MATRIARCH:
            case AREAS.BOSS_PATRIARCH:
            case AREAS.BOSS_RAVEN:
            case AREAS.BOSS_RITAUAL:
            case AREAS.BOSS_TRIALMASTER:
            case AREAS.BOSS_XESHT:
            case AREAS.BOSS_ZAROKH:
                return true;
            default:
                return false;
        }
    }

    private List<LogEntry> getAnomalies() {
        return _dict.Values
            .Where(filterAnomalies)
            .ToList();
    }

    private bool filterAnomalies(LogEntry entry) {
        switch (entry.AreaName) {
            case AREAS.ANOMALY_JADE:
            case AREAS.ANOMALY_MANSION:
            case AREAS.ANOMALY_SACRED:
            case AREAS.ANOMALY_VAULT:
                return true;
            default:
                return false;
        }
    }

    private List<LogEntry> getLog(string type) {
        return _dict.Values
            .Where(entry => entry.AreaName.StartsWith(type))
            .ToList();
    }

    private string getBaseLvlCountString(List<LogEntry> list) {
        return $"Total: {list.Count}\nBy level: {string.Join(" ", 
            list.OrderBy(e => e.AreaLevel)
                .GroupBy(e => e.AreaLevel)
                .Select(g => $"[lvl {g.Key} -> {g.ToList().Count()}]")
        )}";
    }

    public String getUniqueNames() {
        return string.Join("\n", _dict.Values
            .Where(e => !e.AreaName.StartsWith(AREAS.SIMULACRUM))
            .Select(e => e.AreaName)
            .Distinct()
            .ToList()
            );
    }
}
