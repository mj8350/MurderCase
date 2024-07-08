using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMurder : MonoBehaviour
{
    public Sprite[] sp;
    public Image img;
    private int cur;

    private void Awake()
    {
        cur = 0;
        img.sprite = sp[cur];
    }


    private void Update()
    {
        if(cur<2 && Input.GetMouseButtonDown(0))
        {
            cur++;
            img.sprite = sp[cur];
        }
    }

}
