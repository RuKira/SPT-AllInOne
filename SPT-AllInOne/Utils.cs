using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;

namespace SPT_AllInOne;

public class Utils
{
    public static void test()
    {
        string jsonString = File.ReadAllText("quests.json");
        List<string> raw_quests = new List<string>();
        int brackets = -1;
        int i = 0;
        int start = -1;
        int end = -1;
        do
        {
            char c = jsonString[i];
            if (c == '{')
            {
                // brackets++;
                if (brackets++ == 0)
                    start = i;
                // Console.WriteLine($"Brackets:{brackets} Start:{start}");
            }
            else if (c == '}')
            {
                // brackets--;
                if (--brackets == 0)
                {
                    end = i;
                    // Dictionary<string, dynamic> quest =
                    //     JsonSerializer.Deserialize<Dictionary<string, dynamic>>(jsonString.Substring(start, end))!;
                    
                    raw_quests.Append(jsonString.Substring(start, (end-start)));
                }
            }
        } while ( i++ < jsonString.Length-1);
        using(StreamWriter output = new StreamWriter("rawQuests.json",true))
        {
            output.Write("{ \"quests\":[");
            foreach (string rq in raw_quests)
                output.Write(rq+",");
            output.Write("]}");
        }
    }
}