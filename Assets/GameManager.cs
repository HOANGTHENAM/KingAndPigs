using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] GameObject Player;
    private void Awake()
    {
        if (startPoint == null)
            startPoint = GameObject.FindGameObjectWithTag("StartPoint").transform;
        PlayerSpawn();
    }
    public void PlayerSpawn()
    {
        if (Player == null)
        {
            Instantiate(Player);
        }
        Player.gameObject.transform.position = startPoint.transform.position;
    }
}
