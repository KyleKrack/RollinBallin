using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using TMPro; 

public class playerController : MonoBehaviour
{
    public GameObject winTextObject; 
    
    public TextMeshProUGUI countText; 
    
    public float speed = 0;
    
    private Rigidbody rb;

    private int count; 

    private float movementX;

    private float movementY;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0; 
        
        setCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y; 
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++; 
            Debug.Log(count);
            setCountText(); 
        }
        
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 14)
        {
            winTextObject.SetActive(true);
        }
    }
    

}
