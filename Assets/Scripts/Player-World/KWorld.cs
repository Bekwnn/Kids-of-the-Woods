using UnityEngine;
using System.Collections.Generic;

public class KWorld : MonoBehaviour
{
    // list of current players
    public KGameState gameState;

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
            InitializeWorld();
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    void InitializeWorld()
    {
        gameState.InitializeGameState();
    }
}
