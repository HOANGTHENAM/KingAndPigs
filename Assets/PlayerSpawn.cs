using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] GameObject Player;
    private void Awake()
    {
        
        if (Player == null)
        {
            Instantiate(Player);
        }
        Player.gameObject.transform.position = startPoint.transform.position;
    }
}
