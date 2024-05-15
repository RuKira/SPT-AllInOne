using System.Printing;

namespace SPT_AllInOne;

public class Quest
{
    public string questName { get; set; }
    public string _id { get; set; }
    public string acceptPlayerMessage { get; set; }
    public bool canShowNotificationsInGame { get; set; }
    public string changeQuestMessageText { get; set; }
    public string completePlayerMessage { get; set; }
    
    public List<AFF> Affs { get; set; }
    //available for start
    //fail

    public string declinePlayerMessage { get; set; }
    public string description { get; set; }
    public string failMessageText { get; set; }
    public string image { get; set; }
    public bool instantComplete { get; set; }
    public bool isKey { get; set; }
    public string location { get; set; }
    public string name { get; set; }
    public string note { get; set; }
    public bool restartable { get; set; }
    
    /*Rewards*/
    //failed
    //started
    //success
    public bool secretQuest { get; set; }
    public string side { get; set; }
    public string startedMessageText { get; set; }
    public string successMessageText { get; set; }
    public string traderId { get; set; }
    public string type { get; set; }
    
    public Quest()
    {
        acceptPlayerMessage = $"{_id} acceptPlayerMessage";
        changeQuestMessageText = $"{_id} changeQuestMessageText";
        completePlayerMessage = $"{_id} completePlayerMessage";
        declinePlayerMessage = $"{_id} declinePlayerMessage";
        description = $"{_id} description";
        failMessageText = $"{_id} failMessageText";
        name = $"{_id} name";
        note = $"{_id} note";
        startedMessageText = $"{_id} startedMessageText";
        successMessageText = $"{_id} successMessageText";
    }

    public Quest(dynamic input)
    {
        Affs = new List<AFF>();
        questName = input["QuestName"];
        _id = input["_id"];
        acceptPlayerMessage = $"{_id} acceptPlayerMessage";
        canShowNotificationsInGame = input["canShowNotificationsInGame"];
        changeQuestMessageText = $"{_id} changeQuestMessageText";
        completePlayerMessage = $"{_id} completePlayerMessage";
        //conditions
        foreach (dynamic aff in input["conditions"]["AvailableForFinish"])
        {
            // Console.WriteLine($"{questName}: conditionType: {aff["conditionType"]}");
            switch (aff["conditionType"])
            {
                case "CounterCreator": Affs.Add(new AFF_Counter(aff)); break;
                case "FindItem": Affs.Add(new AFF_FindItem(aff)); break;
                case "PlaceBeacon": Affs.Add(new AFF_Beacon(aff)); break;
                case "LeaveItemAtLocation": Affs.Add(new AFF_DropItem(aff)); break;
                case "HandoverItem": Affs.Add(new AFF_HandoverItem(aff)); break;
                case "WeaponAssembly": Affs.Add(new AFF_WeaponAssembly(aff)); break;
                case "Quest": Affs.Add(new AFF_Quest(aff)); break;
                case "Skill": Affs.Add(new AFF_Skill(aff)); break;
                case "TraderLoyalty": Affs.Add(new AFF_Loyalty(aff)); break;
                default: throw new Exception($"Unknown condition type!! {questName}");
            }
        }
        declinePlayerMessage = $"{_id} declinePlayerMessage";
        description = $"{_id} description";
        failMessageText = $"{_id} failMessageText";
        image = input["image"];
        instantComplete = input["instantComplete"];
        isKey = input["isKey"];
        location = input["location"];
        name = $"{_id} name";
        note = $"{_id} note";
        restartable = input["restartable"];
        //rewards
        secretQuest = input["secretQuest"];
        side = input["side"];
        startedMessageText = $"{_id} startedMessageText";
        successMessageText = $"{_id} successMessageText";
        traderId = input["traderId"];
        type = input["type"];
    }
    
}