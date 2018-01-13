using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour {

    public string islandName;
    public int wood;
    public int iron;
    public int gold;

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
		
	}
}
