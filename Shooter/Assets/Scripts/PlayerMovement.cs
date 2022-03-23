using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    private float vertical;
    [SerializeField, Range(1f, 5f)] private float speed = 5f;

    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Camera cam;

    [SerializeField] Weapon weapon;

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
        RotatePlayer();

        // weapon will shoot as long as the user holds down left mouse button 
        if (Input.GetMouseButton(0))
        {
            // weapon?.Shoot() - instead of weapon != null, operator ? will implicitly check != null and only then call Shoot
            if (weapon != null)
            {
                weapon.Shoot();
            }
        }
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
