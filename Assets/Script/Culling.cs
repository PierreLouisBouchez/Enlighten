using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Culling : MonoBehaviour
{

    private GameObject Room1;
    private GameObject Corridor;
    private GameObject Room2;


    private bool InRoom1;
    private bool InCorridor;
    private bool InRoom2;


    // Start is called before the first frame update
    void Start()
    {
        Room1 = GameObject.FindGameObjectWithTag("Room1");
        Corridor = GameObject.FindGameObjectWithTag("Corridor");
        Room2 = GameObject.FindGameObjectWithTag("Room2");
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void Cull()
    {        
        foreach (Transform child in Room1.transform)
        {
            child.gameObject.SetActive( InRoom1 || InCorridor );
        }
        
        foreach (Transform child in Room2.transform)
        {
            child.gameObject.SetActive(InRoom2 || InCorridor);
        }
     }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Room1")
        {
            InRoom1 = true;
        }
        else if (other.gameObject.tag == "Corridor")
        {
            InCorridor = true;
        }
        else if (other.gameObject.tag == "Room2")
        {
            InRoom2 = true;
        }
        Cull();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Room1")
        {
            InRoom1 = false;
        }
        else if (other.gameObject.tag == "Corridor")
        {
            InCorridor = false;
        }
        else if (other.gameObject.tag == "Room2")
        {
            InRoom2 = false;
        }
        Cull();
    }
}
