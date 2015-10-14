using UnityEngine;
using System.Collections;

public class KUnit : MonoBehaviour
{
    public GameObject selectionDecal;

    protected bool _bSelected;
    public bool bSelected
    {
        get
        {
            return _bSelected;
        }
        set
        {
            _bSelected = value;
            if (_bSelected)
            {
                OnSelection();
            }
            else
            {
                OnDeselection();
            }
        }
    }

    protected virtual void OnSelection()
    {
        if (selectionDecal != null)
            selectionDecal.SetActive(true);
    }

    protected virtual void OnDeselection()
    {
        if (selectionDecal != null)
            selectionDecal.SetActive(false);
    }
}
