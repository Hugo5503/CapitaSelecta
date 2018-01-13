using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Island : MonoBehaviour {

    public string islandName;
    public int wood;
    public int iron;
    public int gold;
    public Text islandNameText;
    public Text woodText;
    public Text ironText;
    public Text goldText;

    // Use this for initialization
    void Start () {
        if (islandName == "")
        {
            islandName = "UnnamedIsland";
        }
        wood = Random.Range(200,500);
        iron = Random.Range(50, 250);
        gold = Random.Range(20, 100);
	}
	
	// Update is called once per frame
	void Update () {
        islandNameText.text = islandName;
        woodText.text = wood.ToString();
        ironText.text = iron.ToString();
        goldText.text = gold.ToString();
    }
}
