using System.Dynamic;
using System.Transactions;
using System.Windows.Documents;

namespace SPT_AllInOne;
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
    public Dictionary<string,string> MAP_NAMES { get;  set; }
    public Dictionary<string,string> MAP_IDS { get;  set; }
    public List<string> ROOT_CONDITIONS { get; set; }
    public List<string> SIDE { get;  set; }
    public Dictionary<string, string> TRADER_NAMES { get;  set; }
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
        ROOT_CONDITIONS = new List<string>
        {
            "CounterCreator",
            "FindItem",
            "HandoverItem",
            "LeaveItemAtLocation",
            "WeaponAssembly",
            "PlaceBeacon"
        };
    }

    public void sidesSetup()
    {
        SIDE = new List<string>
        {
            "pmc",
            "bear",
            "usec",
            "savages"
        };
    }
    public void mapsSetup()
    {
        MAP_NAMES = new Dictionary<string, string>
        {
            ["any"] = "any",
            ["Customs"] = "56f40101d2720b2a4d8b45d6",
            ["FactoryDay"] = "55f2d3fd4bdc2d5f408b4567",
            ["FactoryNight"] = "59fc81d786f774390775787e",
            ["GroundZero"] = "653e6760052c01c1c805532f",
            ["Interchange"] = "5714dbc024597771384a510d",
            ["Labs"] = "5b0fc42d86f7744a585f9105",
            ["Lighthouse"] = "5704e4dad2720bb55b8b4567",
            ["Reserve"] = "5704e5fad2720bc05b8b4567",
            ["Shoreline"] = "5704e554d2720bac5b8b456e",
            ["Streets"] = "5714dc692459777137212e12",
            ["Woods"] = "5704e3c2d2720bac5b8b4567"
        };

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
        TRADER_NAMES = new Dictionary<string, string>
        {
            ["Fence"] = "579dc571d53a0658a154fbec",
            ["Prapor"] = "54cb50c76803fa8b248b4571",
            ["Therapist"] = "54cb57776803fa99248b456e",
            ["Skier"] = "58330581ace78e27b8b10cee",
            ["Peacekeeper"] = "5935c25fb3acc3127c3d8cd9",
            ["Mechanic"] = "5a7c2eca46aef81a7ca2145d",
            ["Ragman"] = "5ac3b934156ae10c4430e83c",
            ["Jager"] = "5c0647fdd443bc2504c2d371"
        };

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
        // Console.WriteLine($"Weapon Assembly Constructor: {name} | {input}");
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
    public List<string> bodyPart { get; set; }
    public Dictionary<string, int> daytime { get; set; }
    public List<CounterConditions> conditions { get; set; }
    public List<string> enemyEquipmentExclusive { get; set; }
    public List<string> enemyEquipmentInclusive { get; set; }
    public List<string> enemyHealthEffects { get; set; }
    public List<string> savageRole { get; set; }
    public List<string> weapon { get; set; }
    public List<string> weaponCaliber { get; set; }
    public List<string> weaponModsExclusive { get; set; }
    public List<string> weaponModsInclusive { get; set; }

    public AFF_CounterConditions_Kills(dynamic input)
    {
        bodyPart = new List<string>();
        daytime = new Dictionary<string, int>();
        conditions = new List<CounterConditions>();
        foreach (var k in input.Keys)
        {
            switch (k)
            {
             case "bodyPart": foreach(var b in input["bodyPart"]) bodyPart.Add(b); break;
             case "compareMethod": compareMethod = input["compareMethod"]; break;
             case "conditionType": conditionType = input["conditionType"]; break;
             case "daytime": daytime["from"] = (int)input["daytime"]["from"];
                                daytime["to"] = (int)input["daytime"]["to"]; break;
             case "dynamicLocale": dynamicLocale = input["dynamicLocale"]; break;
             case "enemyEquipmentExclusive": enemyEquipmentExclusive = getStringList(input["enemyEquipmentExclusive"]); break;
             case "enemyEquipmentInclusive": enemyEquipmentInclusive = getStringList(input["enemyEquipmentInclusive"]); break;
             case "enemyHealthEffects": enemyHealthEffects = getStringList(input["enemyHealthEffects"]); break;
             case "id": id = input["id"]; break;
             case "resetOnSessionEnd": resetOnSessionEnd = input["resetOnSessionEnd"]; break;
             case "savageRole": savageRole = getStringList(input["savageRole"]); break;
             case "target": target = input["target"]; break;
             case "value": value = Int32.Parse(input["value"].ToString()); break;
             case "weapon": weapon = getStringList(input["weapon"]); break;
             case "weaponCaliber": weaponCaliber = getStringList(input["weaponCaliber"]); break;
             case "weaponModsExclusive": weaponModsExclusive = getStringList(input["weaponModsExclusive"]); break;
             case "weaponModsInclusive": weaponModsInclusive = getStringList(input["weaponModsInclusive"]); break;
             default: conditions.Add(new CounterConditions(k,input[k])); break;
            }
        }

    }

    protected List<string> getStringList(List<dynamic> input)
    {
        List<string> temp = new List<string>();
        if (input.Count < 1)
            return temp;
        
        foreach(var i in input)
            temp.Add(i.ToString());

        return temp;

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

        counter = new List<AFF_CounterConditions>();

        foreach (dynamic c in input["counter"]["conditions"])
        {
            switch (c["conditionType"])
            {
                case "Kills": counter.Add(new AFF_CounterConditions_Kills(c)); break;
                case "Location": break;
                case "ExitStatus": break;
                case "VisitPlace": break;
                case "Equipment": break;
                case "Shots": break;
                case "HealthEffect": break;
                case "InZone": break;
                case "LaunchFlare": break;
                case "ExitName": break;
                case "HealthBuff": break;
                default: throw new Exception($"Unknown condition type!! {c["conditionType"]}");
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
            // Console.WriteLine($"{part}:{input[part]}");
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