using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontal;
    private float vertical;
    [SerializeField, Range(1f, 5f)] private float speed = 5f;

    [SerializeField] Rigidbody rbody;
    [SerializeField] Camera cam;

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
        Debug.Log("Ribbet ribbet!");
    }

    // Update is called once per frame
    private void Update()
    {
        GetInput();
        // Move();  // basic movement implementation
        RotatePlayer();
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
        rbody.MovePosition(goToPosition);
    }

    private void RotatePlayer()
    {
        // raycast implemented here - from camera fprojects an infinite ray towards mouse position on screen
        RaycastHit hit;
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            // hit.transform returns transform of the object that was hit
            // why transform.position.y? - to avoid tilting the player towards the ground, the idea is
            // for player to only look towards the mouse point
        }
    }

    private void OnDestroy()
    {
        
    }
}
