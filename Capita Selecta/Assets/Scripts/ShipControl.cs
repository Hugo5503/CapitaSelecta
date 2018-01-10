using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{

    public bool forward;
    public float speed;
    public bool rotate;
    public float turningSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (forward)
        {
            this.GetComponent<Rigidbody>().velocity = transform.forward * (speed * Time.deltaTime);
        }
        if (rotate)
        {
            this.transform.Rotate(Vector3.up * Time.deltaTime * turningSpeed);
        }
    }
}
