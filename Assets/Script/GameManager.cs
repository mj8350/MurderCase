using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public int State = 0;

    public int Charactor=0;

    public int[] floor = { 0, 0, 0, 0, 0, 0, 0 };

    public bool[] Inventory = { false };

    public bool moveBool;

    private UIManager uiManager;
    public UIManager UI_Manager
    {
        get
        {
            if (uiManager == null)
            {
                uiManager = FindFirstObjectByType<UIManager>();
            }
            return uiManager;
        }
    }

    public void Clue_Find(int index, string newEx)
    {
        if (index < 20)
            UI_Manager.ClueChang(index, newEx);
        else if (index >= 20 && index < 24)
            UI_Manager.DiaryChange(index);
        else if (index >= 24 && index<34)
            UI_Manager.PhoneChang(index, newEx);
        else if(index >=34)
            UI_Manager.ClueChang(index, newEx);
    }

    public void BoardOff()
    {
        UI_Manager.Board_Off();

    }

    public void Scene_Chang(int index)
    {
        UI_Manager.SceneChang(index);
    }

    public void FadeClear()
    {
        UI_Manager.GoFloor_Scene();
    }

    public void GoChange()
    {
        for(int i = 0; i<floor.Length;i++)
        {
            floor[i] = 0;
        }
        SceneManager.LoadScene("SceneChange");
    }
    
    public void OnTimer(float tt)
    {
        StartCoroutine("Timer", tt);
    }

    public IEnumerator Timer(float tt)
    {
        yield return new WaitForSecondsRealtime(tt);
        GoChange();
    }
}
