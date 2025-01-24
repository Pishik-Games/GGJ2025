using System;
using UnityEngine;

public class FollowPlayer:MonoBehaviour
{
    GameObject player;
    
    private void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    private void Update()
    {
        transform.position = player.transform.position;
    }
}