using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandManager : MonoBehaviour {

    public List<GameObject> islands;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public GameObject getClosestIsland(Vector3 shipPos)
    {
        GameObject c = null;
        foreach (GameObject i in islands)
        {
            if (c == null)
            {
                c = i;
            }
            else
            {
                if (Vector3.Distance(i.transform.position, shipPos) < Vector3.Distance(c.transform.position, shipPos))
                {
                    c = i;
                }
            }
        }
        return c;
    }

    public GameObject getRandomIsland(GameObject currentIsland)
    {
        int randomNr = Random.Range(0, islands.Count);
        while (randomNr == islands.IndexOf(currentIsland))
        {
            randomNr = Random.Range(0, islands.Count);
        }
        return islands[randomNr];
    }
}
