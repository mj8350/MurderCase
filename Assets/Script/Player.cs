using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Prefeb;

    private GameObject obj;
    private Animator anim;

    private Vector3 moveDir;

    public int num;
    public string EX;
    public string pass;


    [SerializeField] private Transform[] floorPos;
    public int myfloor;

    private void Awake()
    {
        if (transform.childCount > 0)
            Destroy(transform.GetChild(0).gameObject);
        obj = Instantiate(Prefeb[GameManager.Instance.Charactor], transform);
        obj.transform.SetParent(transform);


        //obj = transform.GetChild(0).gameObject;
        if (!obj.TryGetComponent<Animator>(out anim))
            Debug.Log("Player.cs - Awake() - anim참조 오류");
        moveDir = Vector3.zero;
        GameManager.Instance.BoardOff();

        transform.position = floorPos[GameManager.Instance.floor[myfloor]].transform.position;
        num = -1;
    }

    private void Update()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        moveAnim();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.BoardOff();
            GameManager.Instance.moveBool = true;
        }

        if (num>-1&&Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.Clue_Find(num, EX);
            GameManager.Instance.moveBool = false;
        }

    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.moveBool)
        {
            if (moveDir == Vector3.zero)
                anim.SetBool("MoveTo", false);
            else
            {
                anim.SetBool("MoveTo", true);
                transform.position += moveDir * Time.deltaTime * 4f;
            }
        }
    }

    private void moveAnim()
    {
        if (moveDir.x > 0)
            anim.SetFloat("Move", 0);
        else if (moveDir.x < 0)
            anim.SetFloat("Move", 2);
        else if (moveDir.x == 0 && moveDir.y > 0)
            anim.SetFloat("Move", 1);
        else if (moveDir.x == 0 && moveDir.y < 0)
            anim.SetFloat("Move", 3);
    }
}
