using UnityEngine;
using System.Collections;
using System.IO;

[RequireComponent(typeof(KUnit))]
public abstract class KUnitComponent : MonoBehaviour
{
    public KUnit unit;

    public virtual void Initialize()
    {
        //nothing for now
    }

    public T ReadJson<T>(string componentJsonName)
    {
        // read json
        string[] heroJson = JsonHelper.GetJsonObject(File.ReadAllText(unit.jsonPath), unit.heroJsonName);
        string[] componentJson = JsonHelper.GetJsonObject(heroJson[0], componentJsonName);
        return JsonUtility.FromJson<T>(componentJson[0]);
    } 
}
