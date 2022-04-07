using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{
    [SerializeField] private GameObject healthBarPrefab;
    public float moveSpeed = 1f;
    private int id;
    public void SetEnemyId(int i)
    {
        id = i;
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.Log("Player is NULL!!!");
        }
    }

    public void SetHealthBar()
    {
        Transform canvas = transform.Find("CharacterCanvas");
        if (canvas != null)
        {
            Transform hObject = canvas.Find("HealthObject(Clone)");
            if (hObject != null)
            {
                HealthElement hElement = hObject.GetComponent<HealthElement>();
                hElement.SetHealth(Health/100, Color.red);
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.speed = moveSpeed;
        SetHealth(100);
        GameObject healthBar = Instantiate(healthBarPrefab, transform.Find("CharacterCanvas").gameObject.transform);
        if (healthBar != null)
        {
            HealthElement hElement = healthBar.GetComponent<HealthElement>();
            hElement.SetHealth(Health/100, Color.red);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPLayer();
    }
}
