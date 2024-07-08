using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image ClueBoard;
    [SerializeField] private Image Board;
    [SerializeField] private Image Clue;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Sprite[] Clues;

    [SerializeField] private Image Phone;
    [SerializeField] private TMP_InputField inputText;
    [SerializeField] private Image PhoneScreen;
    [SerializeField] private TextMeshProUGUI PhoneName;

    [SerializeField] private Image Fade;
    private Animator FadeAnim;
    private void Awake()
    {
        if (Fade.TryGetComponent<Animator>(out FadeAnim))
        {
            FadeAnim.SetBool("Fade", false);
        }
    }

    

    private int GoFloor;
    public void SceneChang(int index)
    {
        GameManager.Instance.moveBool = false;
        Fade.gameObject.SetActive(true);
        FadeAnim.SetBool("Fade", true);
        GoFloor = index;
    }
    public void GoFloor_Scene()
    {
        switch (GoFloor)
        {
            case 0:
                SceneManager.LoadScene("Floor1");
                break;
            case 1:
                SceneManager.LoadScene("Floor1-1");
                break;
            case 2:
                SceneManager.LoadScene("Floor2");
                break;
            case 3:
                SceneManager.LoadScene("Floor3");
                break;
            case 4:
                SceneManager.LoadScene("Floor3-1");
                break;
            case 5:
                SceneManager.LoadScene("Floor4");
                break;
            case 6:
                SceneManager.LoadScene("Floor4-1");
                break;
        }
    }


    public void ClueChang(int index, string ex)
    {

        ClueBoard.gameObject.SetActive(true);
        Clue.sprite = Clues[index];
        if (Clues[index] == null)
        {
            ClueBoard.gameObject.SetActive(false);
        }
        if (ex != null)
        {
            if(index!=35)
                GameManager.Instance.Inventory[index] = true;
            Board.gameObject.SetActive(true);
            text.text = ex;
        }
        else
        {
            GameManager.Instance.Inventory[index] = true;
            Board.gameObject.SetActive(false);
        }
    }

    public void Board_Off()
    {
        if (Board.gameObject.activeSelf)
            Board.gameObject.SetActive(false);

        if (ClueBoard.gameObject.activeSelf)
            ClueBoard.gameObject.SetActive(false);

        if (Phone.gameObject.activeSelf)
        {
            PhoneScreen.gameObject.SetActive(false);
            Phone.gameObject.SetActive(false);
            whoPhone = 100;
            password = null;
        }

        if (D_Board.gameObject.activeSelf)
            D_Board.gameObject.SetActive(false);
    }

    private int whoPhone;
    private string password;

    public void PhoneChang(int index, string ex)
    {
        Phone.gameObject.SetActive(true);
        whoPhone = index;
        password = ex;
        inputText.text = null;
        WhosPhone();
    }

    public void WhosPhone()
    {
        switch (whoPhone)
        {
            case 24:
                PhoneName.text = "안친구 폰";
                break;
            case 26:
                PhoneName.text = "신이웃 폰";
                break;
            case 27:
                PhoneName.text = "황동료 폰";
                break;
            case 29:
                PhoneName.text = "서여친 폰";
                break;
            case 30:
                PhoneName.text = "박작가 폰";
                break;
        }
    }

    public void OnClick_Input()
    {
        if(inputText.text == password)
        {
            GameManager.Instance.Inventory[whoPhone] = true;
            PhoneScreen.sprite = Clues[whoPhone];
            PhoneScreen.gameObject.SetActive(true);
        }
    }
    public void OnClick_Right_P()
    {
        switch (whoPhone)
        {
            case 24:
                whoPhone++;
                break;
            case 27:
                whoPhone++;
                break;
            case 30:
                whoPhone++;
                break;
            case 31:
                whoPhone++;
                break;
            case 32:
                whoPhone++;
                break;
        }
        GameManager.Instance.Inventory[whoPhone] = true;
        PhoneScreen.sprite = Clues[whoPhone];
    }

    public void OnClick_Left_P()
    {
        switch (whoPhone)
        {
            case 25:
                whoPhone--;
                break;
            case 28:
                whoPhone--;
                break;
            case 31:
                whoPhone--;
                break;
            case 32:
                whoPhone--;
                break;
            case 33:
                whoPhone--;
                break;
        }
        PhoneScreen.sprite = Clues[whoPhone];
    }


    public Image D_Board;
    public Image D_Clue;
    private int d=20;


    public void DiaryChange(int index)
    {
        if (!D_Board.gameObject.activeSelf)
            D_Board.gameObject.SetActive(true);

        D_Clue.sprite = Clues[index];
        d = index;
        GameManager.Instance.Inventory[d] = true;
    }

    public void OnClick_Right_D()
    {
        if (d < 23)
        {
            d++;
            GameManager.Instance.Inventory[d] = true;
            D_Clue.sprite = Clues[d];
        }
    }

    public void OnClick_Left_D()
    {
        if (d > 20)
        {
            d--;
            D_Clue.sprite = Clues[d];
        }
    }


}
