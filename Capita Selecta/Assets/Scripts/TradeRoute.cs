using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeRoute : MonoBehaviour
{

    public List<Island> route;
    /*
    public Dictionary<resource,int> intakeResource;
    */

    public enum resource { wood, iron, gold };

    // Use this for initialization
    void Start()
    {
        route = new List<Island>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddIsland()
    {

    }

    public Island getNextIsland(Island currentIsland)
    {
        int indexOld = route.IndexOf(currentIsland);
        if (route.Count < indexOld)
        {
            return route[indexOld + 1];
        }
        else
        {
            return route[0];
        }
    }
}
