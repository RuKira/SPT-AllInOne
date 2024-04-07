using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;

namespace SPT_AllInOne;

public class Utils
{
    public static void test()
    {
        string jsonString = File.ReadAllText("quests.json");
        var jsp = new JsonParser();
        dynamic objects = jsp.Parse(jsonString);
        
        foreach (var k in objects.Keys)
            Console.WriteLine(k);
    }
}