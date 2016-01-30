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

    protected virtual void Reset()
    {
        if (unit == null)
            unit = GetComponent<KUnit>();
    }

    protected T ReadJson<T>(string componentJsonName)
    {
        // read json
        string heroJson = JsonHelper.GetJsonObject(File.ReadAllText(unit.jsonPath), unit.jsonName);
        string componentJson = JsonHelper.GetJsonObject(heroJson, componentJsonName);
        return JsonUtility.FromJson<T>(componentJson);
    }
}
