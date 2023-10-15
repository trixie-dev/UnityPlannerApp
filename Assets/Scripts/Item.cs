using System;
using UnityEngine;


public class Item : MonoBehaviour
{
    public bool isFilled = false;
    
    public void Fill()
    {
        isFilled = true;
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnValidate()
    {
        if (isFilled)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
