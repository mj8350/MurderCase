using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] public GameObject View;

    [SerializeField] public Sprite[] sp;
    [SerializeField] public Image[] InvenBtn;

    [SerializeField] public Image ClueBoard;
    [SerializeField] public Image Clue;
    [SerializeField] public Image PhoneClue;

    private int curimg=0;

    private void Awake()
    {
        InvenRe();
    }


    public void OnInven()
    {
        InvenRe();
        View.SetActive(true);
        ChangeClue();
    }
    public void OffInven()
    {
        View.SetActive(false);
    }

    public void InvenRe()
    {
        for(int i = 0; i < InvenBtn.Length; i++)
        {
            if (!GameManager.Instance.Inventory[i])
                InvenBtn[i].sprite = null;
            else if (GameManager.Instance.Inventory[i])
                InvenBtn[i].sprite = sp[i];
        }
    }

    public void ChangeClue()
    {
        if (curimg < 24||curimg>=34)
        {
            PhoneClue.gameObject.SetActive(false);
            ClueBoard.gameObject.SetActive(true);
            Clue.sprite = InvenBtn[curimg].sprite;
        }else if(curimg>=24&&curimg<34)
        {
            ClueBoard.gameObject.SetActive(false);
            PhoneClue.gameObject.SetActive(true);
            PhoneClue.sprite = InvenBtn[curimg].sprite;
        }
    }

    public void OnClick_Btn(int newimg)
    {
        curimg = newimg;
        ChangeClue();
    }

}
