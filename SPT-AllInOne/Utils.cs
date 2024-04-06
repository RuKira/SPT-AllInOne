using System.IO;
using System.Text.Json;

namespace SPT_AllInOne;

public class Utils
{
    public static void test()
    {
        string jsonString = File.ReadAllText("quests.json");
        List<string> quests = JsonSerializer.Deserialize<List<string>>(jsonString)!;
        Console.WriteLine(quests);
    }
}