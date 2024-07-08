using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Change : MonoBehaviour
{
    [SerializeField] private Sprite[] sp;
    [SerializeField] private Image img;
    [SerializeField] private Button btn;

    private void Awake()
    {
        ImgUpdate();

        btn.onClick.AddListener(() => OnClick_btn(GameManager.Instance.State));
    }

    public void ImgUpdate()
    {
        img.sprite = sp[GameManager.Instance.State];
    }

    public void OnClick_btn(int index)
    {
        switch (index)
        {
            case 0:
                GameManager.Instance.State++;
                GameManager.Instance.OnTimer(600);
                SceneManager.LoadScene("Floor1");
                break;
            case 1:
                GameManager.Instance.State++;
                ImgUpdate();
                break;
            case 2:
                GameManager.Instance.State++;
                GameManager.Instance.OnTimer(1200);
                SceneManager.LoadScene("Floor1");
                break;
            case 3:
                GameManager.Instance.State++;
                ImgUpdate();
                break;
            case 4:
                GameManager.Instance.State++;
                SceneManager.LoadScene("SelectMurder");
                break;

        }
    }

}
