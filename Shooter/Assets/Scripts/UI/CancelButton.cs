using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CancelButton : MonoBehaviour
{

    [SerializeField] private GameObject content;
    public void EmptyScrollContent()
    {
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
