using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{

    public bool forward;
    public float speed;
    public bool rotate;
    public float turningSpeed;
    public string shipName;
    public IslandManager islandManager;
    public GameObject targetIsland;

    // Use this for initialization
    void Start()
    {
        targetIsland = islandManager.getClosestIsland(this.transform.position);
        shipName = "Unnamed ship";
    }

    // Update is called once per frame
    void Update()
    {
        if (forward && targetIsland != null)
        {
            this.transform.LookAt(targetIsland.transform);
            this.GetComponent<Rigidbody>().velocity = transform.forward * (speed * Time.deltaTime);
        }
        if (rotate)
        {
            this.transform.Rotate(Vector3.up * Time.deltaTime * turningSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == targetIsland)
        {

        }
    }
}
