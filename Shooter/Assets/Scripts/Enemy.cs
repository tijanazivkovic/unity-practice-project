using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{
    public float moveSpeed = 1f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.Log("Player is NULL!!!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.speed = moveSpeed;
        SetHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPLayer();
    }
}
