using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrigger : MonoBehaviour
{
    public int floor;
    public int[] pos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.Scene_Chang(floor);
        GameManager.Instance.floor[pos[0]] = pos[1];
    }
}
