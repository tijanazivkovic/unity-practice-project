using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{
    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.speed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPLayer();
    }
}
