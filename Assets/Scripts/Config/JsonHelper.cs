using UnityEngine;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class JsonHelper
{
    public static string[] GetJsonObject(string jsonString, string handle)
    {
        string pattern = "\"" + handle + "\"\\s*:\\s*\\{";

        //find each regex match
        Regex regx = new Regex(pattern);

        //check if there's a match at all, return null if not
        if (!regx.IsMatch(jsonString)) return null;

        List<string> jsonObjList = new List<string>();
        foreach (Match match in regx.Matches(jsonString))
        {
            int bracketCount = 1;
            int i;
            int startOfObj = match.Index + match.Length;
            for (i = startOfObj; bracketCount > 0; i++)
            {
                if (jsonString[i] == '{') bracketCount++;
                else if (jsonString[i] == '}') bracketCount--;
            }
            jsonObjList.Add("{" + jsonString.Substring(startOfObj, i - startOfObj));
        }

        return jsonObjList.ToArray();
    }
}
