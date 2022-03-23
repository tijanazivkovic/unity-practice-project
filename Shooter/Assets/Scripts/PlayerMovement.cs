using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    private float vertical;
    [SerializeField, Range(1f, 5f)] private float speed = 5f;

    [SerializeField] Rigidbody rigidbody;

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
        Debug.Log("Player start!");
    }

    // Update is called once per frame
    private void Update()
    {
        GetInput();
        // Move();  // basic movement implementation
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        Vector3 changePosition = new Vector3(horizontal, 0f, vertical);
        // transform.Translate(changePosition * Time.deltaTime * speed);    // basic movement implementation
        Vector3 goToPosition = transform.position + changePosition * speed * Time.deltaTime;
        rigidbody.MovePosition(goToPosition);
    }

    private void OnDestroy()
    {
        
    }


}
