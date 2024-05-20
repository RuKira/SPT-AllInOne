using System.Dynamic;
using System.Transactions;
using System.Windows.Documents;

namespace SPT_AllInOne;
public enum Traders
{
    Fence,
    Prapor,
    Therapist,
    Skier,
    Peacekeeper,
    Mechanic,
    Ragman,
    Jager
}

public enum Sides
{
    PMC,
    USEC,
    BEAR,
    SCAV
}

public enum RootConditionTypes
{
    Counter,
    FindItem,
    HandoverItem,
    LeaveItem,
    WeaponAssembly,
    PlaceBeacon
}

public enum Maps
{
    any,
    Customs,
    FactoryDay,
    FactoryNight,
    GroundZero,
    Interchange,
    Labs,
    Lighthouse,
    Reserve,
    Shoreline,
    Streets,
    Woods
}

public enum QuestStatus
{
    Unknown0 = 0,
    Unknown1 = 1,
    Started = 2,
    Unknown3 = 3,
    Completed = 4
}

public class FinishEnums
{
    public static Dictionary<Maps,string> MAP_NAMES { get; }
    public static Dictionary<RootConditionTypes, string> ROOT_CONDITIONS { get; }
    public static Dictionary<Sides, string> SIDE { get; }
    public static Dictionary<Traders, string> TRADER_NAMES { get; }
    public static Dictionary<Traders, string> TRADER_IDS { get; }

    public FinishEnums()
    {
        questsSetup();
        mapsSetup();
        tradersSetup();
        sidesSetup();
    }

    private void questsSetup()
    {
        ROOT_CONDITIONS[RootConditionTypes.Counter] = "CounterCreator"; 
        ROOT_CONDITIONS[RootConditionTypes.FindItem] = "FindItem"; 
        ROOT_CONDITIONS[RootConditionTypes.HandoverItem] = "HandoverItem"; 
        ROOT_CONDITIONS[RootConditionTypes.LeaveItem] = "LeaveItemAtLocation"; 
        ROOT_CONDITIONS[RootConditionTypes.WeaponAssembly] = "WeaponAssembly"; 
        ROOT_CONDITIONS[RootConditionTypes.PlaceBeacon] = "PlaceBeacon"; 
    }

    private void sidesSetup()
    {
        SIDE[Sides.PMC] = "pmc";
        SIDE[Sides.BEAR] = "bear";
        SIDE[Sides.USEC] = "usec";
        SIDE[Sides.SCAV] = "savages";
    }
    private void mapsSetup()
    {
        MAP_NAMES[Maps.any] = "any";
        MAP_NAMES[Maps.Customs] = "bigmap";
        MAP_NAMES[Maps.FactoryDay] = "factory4_day";
        MAP_NAMES[Maps.FactoryNight] = "factory4_night";
        MAP_NAMES[Maps.GroundZero] = "Sandbox";
        MAP_NAMES[Maps.Interchange] = "Interchange";
        MAP_NAMES[Maps.Labs] = "Laboratory";
        MAP_NAMES[Maps.Lighthouse] = "Lighthouse";
        MAP_NAMES[Maps.Reserve] = "RezervBase";
        MAP_NAMES[Maps.Shoreline] = "Shoreline";
        MAP_NAMES[Maps.Streets] = "TarkovStreets";
        MAP_NAMES[Maps.Woods] = "Woods";
    }
    private void tradersSetup()
    {
        TRADER_NAMES[Traders.Fence] = "Fence";
        TRADER_NAMES[Traders.Prapor] = "Prapor";
        TRADER_NAMES[Traders.Therapist] = "Therapist";
        TRADER_NAMES[Traders.Skier] = "Skier";
        TRADER_NAMES[Traders.Peacekeeper] = "Peacekeeper";
        TRADER_NAMES[Traders.Mechanic] = "Mechanic";
        TRADER_NAMES[Traders.Ragman] = "Ragman";
        TRADER_NAMES[Traders.Jager] = "Jager";
        
        TRADER_IDS[Traders.Fence] = "579dc571d53a0658a154fbec";
        TRADER_IDS[Traders.Prapor] = "54cb50c76803fa8b248b4571";
        TRADER_IDS[Traders.Therapist] = "54cb57776803fa99248b456e";
        TRADER_IDS[Traders.Skier] = "58330581ace78e27b8b10cee";
        TRADER_IDS[Traders.Peacekeeper] = "5935c25fb3acc3127c3d8cd9";
        TRADER_IDS[Traders.Mechanic] = "5a7c2eca46aef81a7ca2145d";
        TRADER_IDS[Traders.Ragman] = "5ac3b934156ae10c4430e83c";
        TRADER_IDS[Traders.Jager] = "5c0647fdd443bc2504c2d371";
    }
}

public class AFF
{
    public string id { get; set; }
    public string connditionType { get; set; }
    public int index { get; set; }
    public string globalQuestCounterId { get; set; }
    public bool dynamicLocale { get; set; }
    public string parentId { get; set; }
    public dynamic target { get; set; }
    public dynamic visibilityConditions { get; set; }

    public AFF()
    {
        
    }

    public AFF(dynamic input)
    {
        dynamicLocale = input["dynamicLocale"];
        globalQuestCounterId = input["globalQuestCounterId"];
        id = input["id"];
        index = (int) input["index"];
        parentId = input["parentId"];
        target = input["target"];
        visibilityConditions = input["visibilityConditions"];
    }
}

public class AFF_FindItem : AFF
{
    public bool countInRaid { get; set; }
    public int dogtagLevel { get; set; }
    public bool isEncoded { get; set; }
    public int maxDurability { get; set; }
    public int minDurability { get; set; }
    public bool onlyFoundInRaid { get; set; }
    public string value { get; set; }

    public AFF_FindItem(dynamic input)
    {
        dynamicLocale = input["dynamicLocale"];
        globalQuestCounterId = input["globalQuestCounterId"];
        id = input["id"];
        index = (int) input["index"];
        parentId = input["parentId"];
        target = input["target"];
        visibilityConditions = input["visibilityConditions"];

        countInRaid = input["countInRaid"];
        dogtagLevel = (int)input["dogtagLevel"];
        isEncoded = input["isEncoded"];

        maxDurability = Int32.Parse(input["maxDurability"].ToString());
        minDurability = Int32.Parse(input["minDurability"].ToString());
        onlyFoundInRaid = input["onlyFoundInRaid"];
        value = input["value"].ToString();
    }
}

public class AFF_DropItem : AFF
{
    public string zoneId { get; set; }
    public int plantTime { get; set; }
    public int dogtagLevel { get; set; }
    public bool isEncoded { get; set; }
    public int maxDurability { get; set; }
    public int minDurability { get; set; }
    public bool onlyFoundInRaid { get; set; }
    public string value { get; set; }

    public AFF_DropItem(dynamic input)
    {
        dynamicLocale = input["dynamicLocale"];
        globalQuestCounterId = input["globalQuestCounterId"];
        id = input["id"];
        index = (int) input["index"];
        parentId = input["parentId"];
        target = input["target"];
        visibilityConditions = input["visibilityConditions"];

        zoneId = input["zoneId"];
        plantTime = (int) input["plantTime"];
        dogtagLevel = (int) input["dogtagLevel"];
        isEncoded = input["isEncoded"];
        maxDurability = (int) input["maxDurability"];
        minDurability = (int) input["minDurability"];
        onlyFoundInRaid = input["onlyFoundInRaid"];
        value = input["value"].ToString();
    }
}

public class AFF_HandoverItem : AFF
{
    public int dogtagLevel { get; set; }
    public bool isEncoded { get; set; }
    public double maxDurability { get; set; }
    public double minDurability { get; set; }
    public bool onlyFoundInRaid { get; set; }
    public int value { get; set; }

    public AFF_HandoverItem(dynamic input)
    {
        dogtagLevel = Int32.Parse(input["dogtagLevel"].ToString());
        dynamicLocale = input["dynamicLocale"];
        globalQuestCounterId = input["globalQuestCounterId"];
        id = input["id"];
        index = (int) input["index"];
        try{ isEncoded = input["isEncoded"]; }catch{}
        maxDurability = input["maxDurability"];
        minDurability = input["minDurability"];
        onlyFoundInRaid = input["onlyFoundInRaid"];
        parentId = input["parentId"];
        target = input["target"];
        value = Int32.Parse(input["value"].ToString());
        visibilityConditions = input["visibilityConditions"];
    }
}

public class CounterConditions
{
    public string name { get; set; }
    public string compareMethod { get; set; }
    public int value { get; set; }

    public CounterConditions(string _name, dynamic input)
    {
        name = _name;
        // Console.WriteLine($"Weapon Assembly Constructor: {input}");
        compareMethod = input["compareMethod"];
        value = (int)input["value"];
    }
}

public class AFF_CounterConditions
{
    public string conditionType { get; set; }
    public string compareMethod { get; set; }
    public bool dynamicLocale { get; set; }
    public string id { get; set; }
    public bool resetOnSessionEnd { get; set; }
    public string target { get; set; }
    public int value { get; set; }

    public AFF_CounterConditions()
    {
        
    }

    public AFF_CounterConditions(dynamic input)
    {
        
    }
    
}

public class AFF_CounterConditions_Kills : AFF_CounterConditions
{
    public string[] bodyPart { get; set; }
    public Dictionary<string, int> daytime { get; set; }
    public List<CounterConditions> conditions { get; set; }
    public string[] enemyEquipmentExclusive { get; set; }
    public string[] enemyEquipmentInclusive { get; set; }
    public string[] enemyHealthEffects { get; set; }
    public string[] savageRole { get; set; }
    public string[] weapon { get; set; }
    public string[] weaponCaliber { get; set; }
    public string[] weaponModsExclusive { get; set; }
    public string[] weaponModsInclusive { get; set; }

    public AFF_CounterConditions_Kills(dynamic input)
    {
        foreach (var k in input.Keys)
        {
            switch (k)
            {
             case "bodyPart": bodyPart = input["bodyPart"]; break; 
             case "compareMethod": compareMethod = input["compareMethod"]; break; 
             case "conditinoType": conditionType = input["conditionType"]; break;
             case "daytime": daytime["from"] = input["daytime"]["from"];
                                daytime["to"] = input["daytime"]["to"]; break;
             case "dynamicLocale": dynamicLocale = input["dynamicLocale"]; break;
             case "enemyEquipmentExclusive": enemyEquipmentExclusive = input["enemyEquipmentExclusive"]; break;
             case "enemyEquipmentInclusive": enemyEquipmentInclusive = input["enemyEquipmentInclusive"]; break;
             case "enemyHealthEffects": enemyHealthEffects = input["enemyHealthEffects"]; break;
             case "savageRole": savageRole = input["savageRole"]; break;
             case "target": target = input["target"]; break;
             case "value": value = (int) input["value"]; break;
             case "weapon": weapon = input["weapon"]; break;
             case "weaponCaliber": weaponCaliber = input["weaponCaliber"]; break;
             case "weaponModsExclusive": weaponModsExclusive = input["weaponModsExclusive"]; break;
             case "weaponModsInclusive": weaponModsInclusive = input["weaponModsInclusive"]; break;
             default: conditions.Add(new CounterConditions(k,input[k])); break;
            }
        }

    }
}
public class AFF_Counter : AFF
{
    public int completeInSeconds { get; set; }
    public List<AFF_CounterConditions> counter { get; set; }
    public bool doNotResetIfCounterCompleted { get; set; }
    public bool oneSessionOnly { get; set; }
    public string type { get; set; }
    public string value { get; set; }

    public AFF_Counter(dynamic input)
    {
        try{ completeInSeconds = (int) input["completeInSeconds"]; }catch{}
        try{ counter = input["counter"]; }catch{}
        try{ doNotResetIfCounterCompleted = input["doNotResetIfCounterCompleted"]; }catch{}
        try{ dynamicLocale = input["dynamicLocale"]; }catch{}
        try{ globalQuestCounterId = input["globalQuestCounterId"]; }catch{}
        try{ id = input["id"]; }catch{}
        try{ index = (int)input["index"]; }catch{}
        try{ oneSessionOnly = input["oneSessionOnly"]; }catch{}
        try{ parentId = input["parentId"]; }catch{}
        try{ type = input["type"]; }catch{}
        try{ value = Int32.Parse(input["value"]); }catch{}
        try{ visibilityConditions = input["visibilityConditions"]; }catch{}

        foreach (dynamic c in input["counter"]["conditions"])
        {
            switch (c["conditionType"])
            {
                case "Kills": counter.Add(new AFF_CounterConditions_Kills(c)); break;
            }
        }
    }
}

public class AFF_Beacon : AFF
{
    public string zoneId { get; set; }

    public AFF_Beacon(dynamic input)
    {
        dynamicLocale = input["dynamicLocale"];
        globalQuestCounterId = input["globalQuestCounterId"];
        id = input["id"];
        index = (int) input["index"];
        parentId = input["parentId"];
        target = input["target"];
        visibilityConditions = input["visibilityConditions"];

        zoneId = input["zoneId"];
    }
}

public class AFF_Quest : AFF
{
    public int availableAfter { get; set; }
    public int dispersion { get; set; }
    public dynamic status { get; set; }
    
    public AFF_Quest(dynamic input)
    {
        availableAfter = (int) input["availableAfter"];
        dispersion = (int) input["dispersion"];
        dynamicLocale = input["dynamicLocale"];
        try{ globalQuestCounterId = input["globalQuestCounterId"]; }catch{}
        try{ id = input["id"]; }catch{}
        try{ index = (int)input["index"]; }catch{}
        try{ parentId = input["parentId"]; }catch{}
        status = input["status"];
        try{ visibilityConditions = input["visibilityConditions"]; }catch{}
    }
}


public class AFF_Skill : AFF
{
    public string compareMethod { get; set; }
    public int value { get; set; }
    
    public AFF_Skill(dynamic input)
    {
        compareMethod = input["compareMethod"];
        dynamicLocale = input["dynamicLocale"];
        globalQuestCounterId = input["globalQuestCounterId"];
        id = input["id"];
        index = (int) input["index"];
        parentId = input["parentId"];
        target = input["target"];
        value = (int)input["value"];
        visibilityConditions = input["visibilityConditions"];
        
    }
}

public class AFF_Loyalty : AFF
{
    public string compareMethod { get; set; }
    public int value { get; set; }
    
    public AFF_Loyalty(dynamic input)
    {
        compareMethod = input["compareMethod"];
        dynamicLocale = input["dynamicLocale"];
        globalQuestCounterId = input["globalQuestCounterId"];
        id = input["id"];
        index = (int) input["index"];
        parentId = input["parentId"];
        target = input["target"];
        value = (int)input["value"];
        visibilityConditions = input["visibilityConditions"];
        
    }
}

public class WeaponAssembly
{
    public string name { get; set; }
    public string compareMethod { get; set; }
    public int value { get; set; }

    public WeaponAssembly(string _name, dynamic input)
    {
        name = _name;
        // Console.WriteLine($"Weapon Assembly Constructor: {input}");
        compareMethod = input["compareMethod"];
        value = (int)input["value"];
    }
}

public class AFF_WeaponAssembly : AFF
{
    public List<WeaponAssembly> parts { get; set; }
    public List<String> hasItemFromCategory { get; set; } 
    public int value { get; set; }
    public AFF_WeaponAssembly(dynamic input)
    {
        parts = new List<WeaponAssembly>();
        hasItemFromCategory = new List<string>();
        foreach (dynamic part in input.Keys)
        {
            Console.WriteLine($"{part}:{input[part]}");
            switch (part)
            {
                case "dynamicLocale": dynamicLocale = input["dynamicLocale"]; break;
                case "globalQuestCounterId": globalQuestCounterId = input["globalQuestCounterId"]; break;
                case "id":  id = input["id"]; break;
                case "index": index = (int) input["index"]; break;
                case "parentId": parentId = input["parentId"]; break;
                case "target": target = input["target"]; break;
                case "visibilityConditions": visibilityConditions = input["visibilityConditions"]; break;
                case "hasItemFromCategory": foreach(var s in input[part]) hasItemFromCategory.Add(s); break;
                case "value": value = (int) input["value"]; break;
                case "conditionType": break;
                case "containsItems": break;
                default: parts.Add(new WeaponAssembly(part, input[part])); break;
            }
            
        }
        
        
        
        
    }
}