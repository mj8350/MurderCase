using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene1 : MonoBehaviour
{
    [SerializeField] private Sprite[] image;
    [SerializeField] private Image sp;
    [SerializeField] private Image Select;
    private int change=1;
    

    private void Awake()
    {
        if (!sp.TryGetComponent<Image>(out sp))
            Debug.Log("sp참조 오류");
        Select.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (change <image.Length+1 &&Input.GetMouseButtonDown(0))
        {
            if (change == image.Length)
            {
                sp.gameObject.SetActive(false);
                Select.gameObject.SetActive(true);
            }
            else
            {
                sp.sprite = image[change];
            }
                change++;
        }

    }

    public void OnClick_Player(int player)
    {
        GameManager.Instance.Charactor = player;
        SceneManager.LoadScene("SceneChange");
    }
    
}
