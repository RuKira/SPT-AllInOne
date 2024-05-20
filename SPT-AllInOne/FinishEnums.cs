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
        ROOT_CONDITIONS = new Dictionary<RootConditionTypes, string>
        {
            [RootConditionTypes.Counter] = "CounterCreator",
            [RootConditionTypes.FindItem] = "FindItem",
            [RootConditionTypes.HandoverItem] = "HandoverItem",
            [RootConditionTypes.LeaveItem] = "LeaveItemAtLocation",
            [RootConditionTypes.WeaponAssembly] = "WeaponAssembly",
            [RootConditionTypes.PlaceBeacon] = "PlaceBeacon"
        };
    }

    public void sidesSetup()
    {
        SIDE = new Dictionary<Sides, string>
        {
            [Sides.PMC] = "pmc",
            [Sides.BEAR] = "bear",
            [Sides.USEC] = "usec",
            [Sides.SCAV] = "savages"
        };
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
        
        //MAP_IDS = new Dictionary<string, string>
        //{
        //    ["any"] = "any",
        //    ["Customs"] = "56f40101d2720b2a4d8b45d6",
        //    ["FactoryDay"] = "55f2d3fd4bdc2d5f408b4567",
        //    ["FactoryNight"] = "59fc81d786f774390775787e",
        //    ["GroundZero"] = "653e6760052c01c1c805532f",
        //    ["Interchange"] = "5714dbc024597771384a510d",
        //    ["Labs"] = "5b0fc42d86f7744a585f9105",
        //    ["Lighthouse"] = "5704e4dad2720bb55b8b4567",
        //    ["Reserve"] = "5704e5fad2720bc05b8b4567",
        //    ["Shoreline"] = "5704e554d2720bac5b8b456e",
        //    ["Streets"] = "5714dc692459777137212e12",
        //    ["Woods"] = "5704e3c2d2720bac5b8b4567"
        //};

        MAP_IDS = new Dictionary<string, string>
        {
            ["any"] = "any",
            ["56f40101d2720b2a4d8b45d6"] = "Customs",
            ["55f2d3fd4bdc2d5f408b4567"] = "FactoryDay",
            ["59fc81d786f774390775787e"] = "FactoryNight",
            ["653e6760052c01c1c805532f"] = "GroundZero",
            ["5714dbc024597771384a510d"] = "Interchange",
            ["5b0fc42d86f7744a585f9105"] = "Labs",
            ["5704e4dad2720bb55b8b4567"] = "Lighthouse",
            ["5704e5fad2720bc05b8b4567"] = "Reserve",
            ["5704e554d2720bac5b8b456e"] = "Shoreline",
            ["5714dc692459777137212e12"] = "Streets",
            ["5704e3c2d2720bac5b8b4567"] = "Woods"
        };
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
        
        //TRADER_IDS = new Dictionary<string, string>
        //{
        //    ["Fence"] = "579dc571d53a0658a154fbec",
        //    ["Prapor"] = "54cb50c76803fa8b248b4571",
        //    ["Therapist"] = "54cb57776803fa99248b456e",
        //    ["Skier"] = "58330581ace78e27b8b10cee",
        //    ["Peacekeeper"] = "5935c25fb3acc3127c3d8cd9",
        //    ["Mechanic"] = "5a7c2eca46aef81a7ca2145d",
        //    ["Ragman"] = "5ac3b934156ae10c4430e83c",
        //    ["Jager"] = "5c0647fdd443bc2504c2d371"
        //};

        TRADER_IDS = new Dictionary<string, string>
        {
            ["579dc571d53a0658a154fbec"] = "Fence",
            ["54cb50c76803fa8b248b4571"] = "Prapor",
            ["54cb57776803fa99248b456e"] = "Therapist",
            ["58330581ace78e27b8b10cee"] = "Skier",
            ["5935c25fb3acc3127c3d8cd9"] = "Peacekeeper",
            ["5a7c2eca46aef81a7ca2145d"] = "Mechanic",
            ["5ac3b934156ae10c4430e83c"] = "Ragman",
            ["5c0647fdd443bc2504c2d371"] = "Jager"
        };
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

        countInRaid = input["countInRaid"];                                                                         // TODO: Somewhere in this code is causing error's
        dogtagLevel = (int)input["dogtagLevel"];                                                                    // TODO: Somewhere in this code is causing error's
        isEncoded = input["isEncoded"];                                                                             // TODO: Somewhere in this code is causing error's

        maxDurability = Int32.Parse(input["maxDurability"].ToString());                                             // TODO: Somewhere in this code is causing error's
        minDurability = Int32.Parse(input["minDurability"].ToString());                                             // TODO: Somewhere in this code is causing error's
        onlyFoundInRaid = input["onlyFoundInRaid"];                                                                 // TODO: Somewhere in this code is causing error's
        value = input["value"].ToString();                                                                          // TODO: Somewhere in this code is causing error's
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

        zoneId = input["zoneId"];                                                                                   // TODO: Somewhere in this code is causing error's
        plantTime = (int) input["plantTime"];                                                                       // TODO: Somewhere in this code is causing error's
        dogtagLevel = (int) input["dogtagLevel"];                                                                   // TODO: Somewhere in this code is causing error's
        isEncoded = input["isEncoded"];                                                                             // TODO: Somewhere in this code is causing error's
        maxDurability = (int) input["maxDurability"];                                                               // TODO: Somewhere in this code is causing error's
        minDurability = (int) input["minDurability"];                                                               // TODO: Somewhere in this code is causing error's
        onlyFoundInRaid = input["onlyFoundInRaid"];                                                                 // TODO: Somewhere in this code is causing error's
        value = input["value"].ToString();                                                                          // TODO: Somewhere in this code is causing error's
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

public class AFF_CounterConditions                                                                                  // TODO: Somewhere in this code is causing error's
{                                                                                                                   // TODO: Somewhere in this code is causing error's
    public string conditionType { get; set; }                                                                       // TODO: Somewhere in this code is causing error's
    public string compareMethod { get; set; }                                                                       // TODO: Somewhere in this code is causing error's
    public bool dynamicLocale { get; set; }                                                                         // TODO: Somewhere in this code is causing error's
    public string id { get; set; }                                                                                  // TODO: Somewhere in this code is causing error's
    public bool resetOnSessionEnd { get; set; }                                                                     // TODO: Somewhere in this code is causing error's
    public string target { get; set; }                                                                              // TODO: Somewhere in this code is causing error's
    public int value { get; set; }                                                                                  // TODO: Somewhere in this code is causing error's
                                                                                                                    // TODO: Somewhere in this code is causing error's
    public AFF_CounterConditions()                                                                                  // TODO: Somewhere in this code is causing error's
    {                                                                                                               // TODO: Somewhere in this code is causing error's
                                                                                                                    // TODO: Somewhere in this code is causing error's
    }                                                                                                               // TODO: Somewhere in this code is causing error's
                                                                                                                    // TODO: Somewhere in this code is causing error's
    public AFF_CounterConditions(dynamic input)                                                                     // TODO: Somewhere in this code is causing error's
    {                                                                                                               // TODO: Somewhere in this code is causing error's
                                                                                                                    // TODO: Somewhere in this code is causing error's
    }                                                                                                               // TODO: Somewhere in this code is causing error's
                                                                                                                    // TODO: Somewhere in this code is causing error's
}                                                                                                                   // TODO: Somewhere in this code is causing error's

public class AFF_CounterConditions_Kills : AFF_CounterConditions                                                    // TODO: Somewhere in this code is causing error's
{                                                                                                                   // TODO: Somewhere in this code is causing error's
    public string[] bodyPart { get; set; }                                                                          // TODO: Somewhere in this code is causing error's
    public Dictionary<string, int> daytime { get; set; }                                                            // TODO: Somewhere in this code is causing error's
    public List<CounterConditions> conditions { get; set; }                                                         // TODO: Somewhere in this code is causing error's
    public string[] enemyEquipmentExclusive { get; set; }                                                           // TODO: Somewhere in this code is causing error's
    public string[] enemyEquipmentInclusive { get; set; }                                                           // TODO: Somewhere in this code is causing error's
    public string[] enemyHealthEffects { get; set; }                                                                // TODO: Somewhere in this code is causing error's
    public string[] savageRole { get; set; }                                                                        // TODO: Somewhere in this code is causing error's
    public string[] weapon { get; set; }                                                                            // TODO: Somewhere in this code is causing error's
    public string[] weaponCaliber { get; set; }                                                                     // TODO: Somewhere in this code is causing error's
    public string[] weaponModsExclusive { get; set; }                                                               // TODO: Somewhere in this code is causing error's
    public string[] weaponModsInclusive { get; set; }                                                               // TODO: Somewhere in this code is causing error's
                                                                                                                    // TODO: Somewhere in this code is causing error's
    public AFF_CounterConditions_Kills(dynamic input)                                                               // TODO: Somewhere in this code is causing error's
    {                                                                                                               // TODO: Somewhere in this code is causing error's
        foreach (var k in input.Keys)                                                                       // TODO: Somewhere in this code is causing error's
        {                                                                                                           // TODO: Somewhere in this code is causing error's
            switch (k)                                                                                              // TODO: Somewhere in this code is causing error's
            {                                                                                                       // TODO: Somewhere in this code is causing error's
             case "bodyPart": bodyPart = input["bodyPart"]; break;                                                  // TODO: Somewhere in this code is causing error's
             case "compareMethod": compareMethod = input["compareMethod"]; break;                                   // TODO: Somewhere in this code is causing error's
             case "conditinoType": conditionType = input["conditionType"]; break;                                   // TODO: Somewhere in this code is causing error's
             case "daytime": daytime["from"] = input["daytime"]["from"];                                            // TODO: Somewhere in this code is causing error's
                                daytime["to"] = input["daytime"]["to"]; break;                                      // TODO: Somewhere in this code is causing error's
             case "dynamicLocale": dynamicLocale = input["dynamicLocale"]; break;                                   // TODO: Somewhere in this code is causing error's
             case "enemyEquipmentExclusive": enemyEquipmentExclusive = input["enemyEquipmentExclusive"]; break;     // TODO: Somewhere in this code is causing error's
             case "enemyEquipmentInclusive": enemyEquipmentInclusive = input["enemyEquipmentInclusive"]; break;     // TODO: Somewhere in this code is causing error's
             case "enemyHealthEffects": enemyHealthEffects = input["enemyHealthEffects"]; break;                    // TODO: Somewhere in this code is causing error's
             case "savageRole": savageRole = input["savageRole"]; break;                                            // TODO: Somewhere in this code is causing error's
             case "target": target = input["target"]; break;                                                        // TODO: Somewhere in this code is causing error's
             case "value": value = (int) input["value"]; break;                                                     // TODO: Somewhere in this code is causing error's
             case "weapon": weapon = input["weapon"]; break;                                                        // TODO: Somewhere in this code is causing error's
             case "weaponCaliber": weaponCaliber = input["weaponCaliber"]; break;                                   // TODO: Somewhere in this code is causing error's
             case "weaponModsExclusive": weaponModsExclusive = input["weaponModsExclusive"]; break;                 // TODO: Somewhere in this code is causing error's
             case "weaponModsInclusive": weaponModsInclusive = input["weaponModsInclusive"]; break;                 // TODO: Somewhere in this code is causing error's
             default: conditions.Add(new CounterConditions(k,input[k])); break;                                 // TODO: Somewhere in this code is causing error's
            }                                                                                                       // TODO: Somewhere in this code is causing error's
        }                                                                                                           // TODO: Somewhere in this code is causing error's
                                                                                                                    // TODO: Somewhere in this code is causing error's
    }                                                                                                               // TODO: Somewhere in this code is causing error's
}                                                                                                                   // TODO: Somewhere in this code is causing error's
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

        foreach (dynamic c in input["counter"]["conditions"])                                                       // TODO: Somewhere in this code is causing error's
        {                                                                                                           // TODO: Somewhere in this code is causing error's
            switch (c["conditionType"])                                                                             // TODO: Somewhere in this code is causing error's
            {                                                                                                       // TODO: Somewhere in this code is causing error's
                case "Kills": counter.Add(new AFF_CounterConditions_Kills(c)); break;                               // TODO: Somewhere in this code is causing error's
            }                                                                                                       // TODO: Somewhere in this code is causing error's
        }                                                                                                           // TODO: Somewhere in this code is causing error's
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