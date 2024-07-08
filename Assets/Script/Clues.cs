using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clues : MonoBehaviour
{
    public int index;
    public string Explain;
    public string Special;
    public int Special_num=-1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.num = index;
            if (GameManager.Instance.Charactor == Special_num)
                player.EX = Special;
            else if (Explain =="")
            {
                player.EX = null;
            }
            else
                player.EX = Explain;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.num = -1;
            player.EX = null;
        }
    }
}
