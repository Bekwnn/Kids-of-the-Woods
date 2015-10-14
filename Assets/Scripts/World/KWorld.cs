using UnityEngine;
using System.Collections.Generic;

public class KWorld : MonoBehaviour
{
    // empty object our world instance is on
    GameObject gameWorldObject;

    // list of current players
    List<KPlayerState> players;

    // singleton instance
    protected static KWorld _instance;
    public static KWorld instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<KWorld>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }
}
