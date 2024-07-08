using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class Scene2 : MonoBehaviour
{
    [SerializeField] private Sprite[] image;
    [SerializeField] private Image sp;
    [SerializeField] private Button Left;
    [SerializeField] private Button Right;

    private int page;
    private int pageStart;
    private int pageEnd;

    private void Awake()
    {
        page = GameManager.Instance.Charactor * 5;
        pageStart = page;
        pageEnd = pageStart + 4;

        sp.sprite = image[page];
        Left.gameObject.SetActive(false);

    }

    public void OnClick_Right()
    {
        if (page < pageEnd)
        {
            page++;
            if (page == pageStart+1)
            {
                Left.gameObject.SetActive(true);
            }
            sp.sprite = image[page];
        }
        else if (page == pageEnd)
        {
            //게임씬으로 이동
            //SceneManager.LoadScene("SceneChange");
            GameManager.Instance.GoChange();
        }
    }
    public void OnClick_Left()
    {
        if (page > pageStart)
        {
            page--;
            sp.sprite = image[page];
        }
        else if (page == pageStart)
        {
            Left.gameObject.SetActive(false);
        }
    }

}
