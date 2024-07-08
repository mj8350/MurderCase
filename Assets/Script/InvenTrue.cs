using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenTrue : MonoBehaviour
{
    private InventoryScript inven;
    private bool on;
    private void Awake()
    {
        inven = GameObject.FindFirstObjectByType<InventoryScript>();
        on = false;
    }

    private void Update()
    {
        if (!on&&Input.GetKeyDown(KeyCode.I))
        {
            inven.OnInven();
            on = true;
        }

        else if (on)
        {
            if (Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.I))
            {
                inven.OffInven();
                on = false;
            }
        }
    }
}
