using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePhysics : MonoBehaviour
{

    [SerializeField] Rigidbody rigidbody;
    [SerializeField] MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.J)) 
        {
            rigidbody.AddForce(Vector3.up * 100, ForceMode.Force);
        }
        if (Input.GetKeyUp(KeyCode.K)) 
        {
            rigidbody.AddForce(Vector3.up * 4, ForceMode.Impulse);
        }
        if (Input.GetKeyUp(KeyCode.L)) 
        {
            rigidbody.AddTorque(Vector3.up * 10, ForceMode.VelocityChange);
        }
    }

    // if isTrigger is checked in BoxCollider then OnTriggerEnter and OnTriggerExit will be executed
    // also - the cube wont be a block for other objects which means that other objects could walk through it
    // also also - for cube check Is Kinematic and uncheck Use Gravity in Rigid Body
    private void OnTriggerEnter(Collider other)
    {
        meshRenderer.material.color = Color.cyan;
    }

    private void OnTriggerExit(Collider other)
    {
        meshRenderer.material.color = Color.white;
    }

    private void OnCollisionEnter(Collision other)
    {
        meshRenderer.material.color = Color.yellow;
        // to find the object which our cube has collided with use: other.gameObject...
    }


}
