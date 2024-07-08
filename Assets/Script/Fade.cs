using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public void FadeIn()
    {
        gameObject.SetActive(false);
        GameManager.Instance.moveBool = true;
    }

    public void FadeOut()
    {
        GameManager.Instance.FadeClear();
    }
}
