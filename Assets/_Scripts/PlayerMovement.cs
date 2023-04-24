using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float sidewaysDivisor;

    float ogSpeed;

    private void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        
        ogSpeed = speed / sidewaysDivisor;

    }

    void Update()
    {
        if(!(Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f)) {
            speed = ogSpeed;
        }
        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        
    }
}
