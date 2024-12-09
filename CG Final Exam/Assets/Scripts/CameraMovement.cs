using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float lookSpeed = 3f; 
    public float minY = -30f; 
    public float maxY = 30f;  
    private float rotationX = 0f; 
    private float rotationY = 0f; 

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        // cursor stays in the middle FPS style
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; 
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;   

        transform.Translate(moveX, 0, moveZ);

        rotationX -= Input.GetAxis("Mouse Y") * lookSpeed; 
        rotationX = Mathf.Clamp(rotationX, minY, maxY);   
        rotationY += Input.GetAxis("Mouse X") * lookSpeed; 

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }
}
