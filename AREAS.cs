using System;

namespace poe2_log_parser;

public readonly struct AREAS
{
    public const string MAP = "Map";
    public const string SIMULACRUM = "Delirium_Act1Town";
    public const string INCURSION = "IncursionTemple";



    public const string ANOMALY_JADE = "MapUberBoss_JadeCitadel";
    public const string ANOMALY_SACRED = "MapCavernCity";
    public const string ANOMALY_VAULT = "MapVaalVault";
    public const string ANOMALY_MANSION = "MapDerelictMansion";



    public const string BOSS_MATRIARCH = "MapMothersoul_Female";
    public const string BOSS_PATRIARCH = "MapMothersoul_Male";
    public const string BOSS_JAMANRA = "MapUberBoss_CopperCitadel";
    public const string BOSS_DORYANI = "MapUberBoss_StoneCitadel";
    public const string BOSS_GEONOR = "MapUberBoss_IronCitadel";
    public const string BOSS_ARBITER_ASH = "MapUberBoss_Monolith";
    public const string BOSS_ARBITER_DIVINE = "MapUberBoss_Divinity";
    public const string BOSS_RAVEN = "MapUberBoss_Delirium";
    public const string BOSS_BODACH = "MapUberBoss_Ritual";
    public const string BOSS_RITAUAL = "RitualLeagueBoss"; //The King in the Mists
    public const string BOSS_HIVE = "ChayulaLeague_TowerBoss"; //tul and esh
    public const string BOSS_XESHT = "BreachDomain_01";
    public const string BOSS_ZAROKH = "SANCTUM_4"; //Zarokh, the Temporal
    public const string BOSS_TRIALMASTER = "G3_10";



    public const string ABYSS_KULEMAK = "Abyss_Pinnacle";
    public const string ABYSS_BOSS = "Abyss_Boss";
    public const string ABYSS_DEPTHS = "Abyss_Depths";



    public const string EXPEDITION_BOSS_ABERRATION = "MapUberBoss_FallenStar";
    public const string EXPEDITION_BOSS_MEDVED = "ExpeditionSubArea_MedvedBoss";
    public const string EXPEDITION_BOSS_VORANA = "ExpeditionSubArea_VoranaBoss";
    public const string EXPEDITION_BOSS_UHTRED = "ExpeditionSubArea_UhtredBoss";
    public const string EXPEDITION_BOSS_OLROTH = "ExpeditionSubArea_OlrothBoss";
    public const string EXPEDITION_LOGBOOK = "ExpeditionLogBook";

    public static string getReadableName(String name)
    {
        switch (name)
        {
            case ANOMALY_JADE:
                return "Jade";
            case ANOMALY_MANSION:
                return "Mansion";
            case ANOMALY_SACRED:
                return "Sacred";
            case ANOMALY_VAULT:
                return "Vault";
            case BOSS_MATRIARCH:
                return "Matr";
            case BOSS_PATRIARCH:
                return "Patr";
            case BOSS_JAMANRA:
                return "Citadel(Act2)";
            case BOSS_DORYANI:
                return "Citadel(Act3)";
            case BOSS_GEONOR:
                return "Citadel(Act1)";
            case BOSS_ARBITER_ASH:
                return "Arbiter(ash)";
            case BOSS_ARBITER_DIVINE:
                return "Arbiter(div)";
            case BOSS_RAVEN:
                return "Raven";
            case BOSS_BODACH:
                return "Bodach";
            case BOSS_RITAUAL:
                return "King(Ritual)";
            case BOSS_HIVE:
                return "Hive(Tul&Esh)";
            case BOSS_XESHT:
                return "Xesht";
            case BOSS_ZAROKH:
                return "Zarokh?";
            case BOSS_TRIALMASTER:
                return "Trialmaster?";
            case EXPEDITION_BOSS_ABERRATION:
                return "Aberration";
            case EXPEDITION_BOSS_MEDVED:
                return "Medved";
            case EXPEDITION_BOSS_VORANA:
                return "Vorana";
            case EXPEDITION_BOSS_UHTRED:
                return "Uhtred";
            case EXPEDITION_BOSS_OLROTH:
                return "Olroth";
            case EXPEDITION_LOGBOOK:
                return "ExpMap";
            case INCURSION:
                return "Incursion";
            case ABYSS_KULEMAK:
                return "Kulemak";
            case ABYSS_BOSS:
                return "Abyss Boss";
            case ABYSS_DEPTHS:
                return "Abyss Depth";
            default:
                return "unk";
        }
    }

}