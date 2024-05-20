using System.Dynamic;
using System.Transactions;

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
    //public Dictionary<Maps,string> MAP_NAMES { get;  set; }
    public Dictionary<string,string> MAP_IDS { get;  set; }
    public Dictionary<RootConditionTypes, string> ROOT_CONDITIONS { get; set; }
    public Dictionary<Sides, string> SIDE { get;  set; }
    //public Dictionary<Traders, string> TRADER_NAMES { get;  set; }
    public Dictionary<string, string> TRADER_IDS { get;  set; }

    public FinishEnums()
    {
        questsSetup();
        mapsSetup();
        tradersSetup();
        sidesSetup();
    }

    public void questsSetup()
    {
        ROOT_CONDITIONS = new Dictionary<RootConditionTypes, string>();
        ROOT_CONDITIONS[RootConditionTypes.Counter] = "CounterCreator"; 
        ROOT_CONDITIONS[RootConditionTypes.FindItem] = "FindItem"; 
        ROOT_CONDITIONS[RootConditionTypes.HandoverItem] = "HandoverItem"; 
        ROOT_CONDITIONS[RootConditionTypes.LeaveItem] = "LeaveItemAtLocation"; 
        ROOT_CONDITIONS[RootConditionTypes.WeaponAssembly] = "WeaponAssembly"; 
        ROOT_CONDITIONS[RootConditionTypes.PlaceBeacon] = "PlaceBeacon"; 
    }

    public void sidesSetup()
    {
        SIDE = new Dictionary<Sides, string>();
        SIDE[Sides.PMC] = "pmc";
        SIDE[Sides.BEAR] = "bear";
        SIDE[Sides.USEC] = "usec";
        SIDE[Sides.SCAV] = "savages";
    }
    public void mapsSetup()
    {
        //MAP_NAMES = new Dictionary<Maps, string>();
        //MAP_NAMES[Maps.any] = "any";
        //MAP_NAMES[Maps.Customs] = "bigmap";
        //MAP_NAMES[Maps.FactoryDay] = "factory4_day";
        //MAP_NAMES[Maps.FactoryNight] = "factory4_night";
        //MAP_NAMES[Maps.GroundZero] = "Sandbox";
        //MAP_NAMES[Maps.Interchange] = "Interchange";
        //MAP_NAMES[Maps.Labs] = "Laboratory";
        //MAP_NAMES[Maps.Lighthouse] = "Lighthouse";
        //MAP_NAMES[Maps.Reserve] = "RezervBase";
        //MAP_NAMES[Maps.Shoreline] = "Shoreline";
        //MAP_NAMES[Maps.Streets] = "TarkovStreets";
        //MAP_NAMES[Maps.Woods] = "Woods";
        
        MAP_IDS = new Dictionary<string, string>();
        MAP_IDS["any"] = "any";
        MAP_IDS["Customs"] = "56f40101d2720b2a4d8b45d6";
        MAP_IDS["FactoryDay"] = "55f2d3fd4bdc2d5f408b4567";
        MAP_IDS["FactoryNight"] = "59fc81d786f774390775787e";
        MAP_IDS["GroundZero"] = "653e6760052c01c1c805532f";
        MAP_IDS["Interchange"] = "5714dbc024597771384a510d";
        MAP_IDS["Labs"] = "5b0fc42d86f7744a585f9105";
        MAP_IDS["Lighthouse"] = "5704e4dad2720bb55b8b4567";
        MAP_IDS["Reserve"] = "5704e5fad2720bc05b8b4567";
        MAP_IDS["Shoreline"] = "5704e554d2720bac5b8b456e";
        MAP_IDS["Streets"] = "5714dc692459777137212e12";
        MAP_IDS["Woods"] = "5704e3c2d2720bac5b8b4567";
    }
    public void tradersSetup()
    {
        //TRADER_NAMES = new Dictionary<Traders, string>();
        //TRADER_NAMES[Traders.Fence] = "Fence";
        //TRADER_NAMES[Traders.Prapor] = "Prapor";
        //TRADER_NAMES[Traders.Therapist] = "Therapist";
        //TRADER_NAMES[Traders.Skier] = "Skier";
        //TRADER_NAMES[Traders.Peacekeeper] = "Peacekeeper";
        //TRADER_NAMES[Traders.Mechanic] = "Mechanic";
        //TRADER_NAMES[Traders.Ragman] = "Ragman";
        //TRADER_NAMES[Traders.Jager] = "Jager";
        
        TRADER_IDS = new Dictionary<string, string>();
        TRADER_IDS["Fence"] = "579dc571d53a0658a154fbec";
        TRADER_IDS["Prapor"] = "54cb50c76803fa8b248b4571";
        TRADER_IDS["Therapist"] = "54cb57776803fa99248b456e";
        TRADER_IDS["Skier"] = "58330581ace78e27b8b10cee";
        TRADER_IDS["Peacekeeper"] = "5935c25fb3acc3127c3d8cd9";
        TRADER_IDS["Mechanic"] = "5a7c2eca46aef81a7ca2145d";
        TRADER_IDS["Ragman"] = "5ac3b934156ae10c4430e83c";
        TRADER_IDS["Jager"] = "5c0647fdd443bc2504c2d371";
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

public class AFF_Counter : AFF
{
    public int completeInSeconds { get; set; }
    public dynamic counter { get; set; }
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