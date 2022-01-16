using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickableObject : MonoBehaviour{

    public int streng = 1500;

    private bool canTake = false;
    private bool taken = false;
    private GameObject GoName;
    private Transform parent;

    void Start(){

    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.A) && taken){
            Eject(1);
        }

        else if(!taken && canTake && Input.GetKeyDown(KeyCode.A)){
            GoName.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //GoName.transform.position = GameObject.Find("ObjectTake").transform.position;
            parent = GoName.gameObject.transform.parent;
            GoName.gameObject.transform.parent = GameObject.Find("ObjectTake").transform;
            taken = true;
        }

        else if(Input.GetButtonDown("Fire1") && taken){
            Eject(streng);
        }

        
    }

    void Eject(float streng){
        GoName.gameObject.transform.parent = parent;
        parent = null;
        GoName.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        GoName.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward * streng));
        taken = false;
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "TackableObject"){
            canTake = true;
            if(!taken){
                GoName = col.gameObject;
            }
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "TackableObject"){
            canTake = false;
            if(!taken){
                GoName = null;
            }
        }
    }
}
