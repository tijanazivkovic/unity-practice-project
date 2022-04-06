using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPElement : MonoBehaviour
{
    // private Camera cam;

    [SerializeField] private Image img;
    [SerializeField] private Image healthBar;

    public void SetImage(Sprite image) 
    {
        img.sprite = image;
    }

    public void SetHealth(float amount, Color barColor)
    {
        healthBar.fillAmount = amount;
        healthBar.color = barColor;
    }

    // Start is called before the first frame update
    private void Start()
    {
        // cam = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        // transform.LookAt(cam.transform);
        // transform.rotation = Quaternion.identity;

    }
}
