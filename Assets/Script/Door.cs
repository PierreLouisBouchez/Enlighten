﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private bool inDoor;
    private Transform doorObject;
    public GameObject door;


    private void Start() {
        doorObject = door.transform;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Character") {
            Debug.Log(this.name);
            inDoor = true;
        }
    }
    

    private void OnTriggerExit(Collider other){
        if (other.gameObject.name == "Character")
        {
            inDoor = false;
        }
    }

    public void Update()
    {
        if (inDoor && doorObject.position.y < 3)
        {
            doorObject.Translate(0, 2f*Time.deltaTime, 0);
        }
        else if(!inDoor && doorObject.position.y>0)
        {
            doorObject.Translate(0, -2f * Time.deltaTime, 0);

        }
    }

}