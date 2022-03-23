using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private float xPos;
    private float zPos;
    [SerializeField, Range(1f, 5f)] private float speed = 5f;
    float time = 0f;
    float deg = 0f;

    private void Awake()
    {

    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }


    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Enemy start!");
    }

    // Update is called once per frame
    private void Update()
    {
        time += 1f;
        if (time >= 100)
        {
            Rotate();
            time = 0f;
        }
        
        Move();
    }

    private void Rotate()
    {
        deg = Random.Range(-45f, 45f);
        transform.Rotate(0f, deg, 0f, Space.World);
    }

    private void Move()
    {
        Vector3 changePosition = new Vector3(1f, 0f, 0f);
        transform.Translate(changePosition * Time.deltaTime * speed, Space.Self);

        xPos = gameObject.transform.position.x;
        zPos = gameObject.transform.position.z;

        if (xPos > 10f || xPos < -10f || zPos > 10f || zPos < -10f)
        {
            transform.Rotate(0f, (-1) * deg, 0f, Space.World);
        }
        
    }

    private void OnDestroy()
    {

    }
}
