﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(KUnit))]
public abstract class KUnitComponent : MonoBehaviour
{
    public KUnit unit;

    protected void Reset()
    {
        if (unit == null)
            gameObject.GetComponent<KUnit>();
    }
}
