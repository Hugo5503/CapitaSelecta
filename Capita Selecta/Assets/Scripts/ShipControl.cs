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
        int x = Random.Range(-10,10);
        int z = Random.Range(-10, 10);
        transform.position = new Vector3(x,transform.position.y,z);

        targetIsland = islandManager.getRandomIsland(targetIsland);
        if (shipName == "")
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
            Debug.Log(shipName + " Reached destination: " + targetIsland.GetComponent<Island>().islandName);
            //GameObject possibleNewLocation = islandManager.getRandomIsland();
            /*while (possibleNewLocation == targetIsland)
            {
                Debug.Log("It happened");
                possibleNewLocation = islandManager.getRandomIsland();
            }*/
            targetIsland = islandManager.getRandomIsland(targetIsland);
            Debug.Log(shipName + " Setting course to: " + targetIsland.GetComponent<Island>().islandName);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("So " + shipName + " stayed in port for a while......");
    }
}
