using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePartBreaking : MonoBehaviour
{
    private Transform normalFix;
    public Quaternion startRotation;
    public Quaternion nextRotation;

    void Start()
    {
        //normalFix = this.transform;
    }

    void Update()
    {
        transform.rotation = Quaternion.Lerp(startRotation, nextRotation, Mathf.PingPong(Time.time, 1));
        //transform.position = Vector3.Lerp(?, ?, Mathf.PingPong(Time.time, 1));
    }
}
