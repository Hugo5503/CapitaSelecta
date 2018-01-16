using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipControl : MonoBehaviour
{

    public bool forward;
    public float speed;
    public bool rotate;
    public float turningSpeed;
    public string shipName;
    public IslandManager islandManager;
    public GameObject targetIsland;
    public int wood;
    public int iron;
    public int gold;

    public Text shipNameText;
    public Text woodText;
    public Text ironText;
    public Text goldText;

    // Use this for initialization
    void Start()
    {
        int x = Random.Range(-10, 10);
        int z = Random.Range(-10, 10);
        transform.position = new Vector3(x, transform.position.y, z);

        targetIsland = islandManager.getRandomIsland(targetIsland);
        if (shipName == "")
            shipName = "Unnamed ship";
    }

    // Update is called once per frame
    void Update()
    {
        shipNameText.text = shipName;
        woodText.text = wood.ToString();
        ironText.text = iron.ToString();
        goldText.text = gold.ToString();

        if (forward && targetIsland != null)
        {
            this.transform.LookAt(targetIsland.transform);
            this.GetComponent<Rigidbody>().velocity = transform.forward * (speed * Time.deltaTime);
        }
        /*
        if (rotate)
        {
            this.transform.Rotate(Vector3.up * Time.deltaTime * turningSpeed);
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetIsland)
        {
            Debug.Log(shipName + " Reached destination: " + targetIsland.GetComponent<Island>().islandName);
            StartCoroutine(Wait(targetIsland));
            forward = false;
            this.GetComponent<Rigidbody>().velocity = new Vector3();
        }
    }

    IEnumerator Wait(GameObject oldIsland)
    {
        yield return new WaitForSeconds(3);
        targetIsland = islandManager.getRandomIsland(oldIsland);
        forward = true;
    }
}
