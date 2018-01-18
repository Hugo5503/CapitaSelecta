using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipControl : MonoBehaviour
{

    public bool forward;
    public float speed;
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
    public GameObject UIcollection;

    // Use this for initialization
    void Start()
    {
        int x = Random.Range(-20, 20);
        int z = Random.Range(-20, 20);
        transform.position = new Vector3(x, transform.position.y, z);
        StartCoroutine(Wait(null));
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetIsland)
        {
            StartCoroutine(Wait(targetIsland));
            forward = false;
            this.GetComponent<Rigidbody>().velocity = new Vector3();
        }
    }

    IEnumerator Wait(GameObject oldIsland)
    {
        int randomInt = Random.Range(0,3);
        yield return new WaitForSeconds(1 + randomInt);
        targetIsland = islandManager.getRandomIsland(oldIsland);
        forward = true;
    }
}
