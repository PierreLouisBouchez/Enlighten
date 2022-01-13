using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllElementPiece : MonoBehaviour{

    public GameObject grandChild;
    public Rigidbody[] obj;
    private GameObject GoName;

    // Start is called before the first frame update
    void Start(){
        grandChild = grandChild.transform.parent.gameObject;
        obj = GetComponentsInChildren<Rigidbody>(true);
    }

    // Update is called once per frame
    void Update(){
        if(GoName != null && Input.GetKeyDown(KeyCode.A)){
            foreach (var ob in obj){
                ob.useGravity = !ob.useGravity;
            }
        }
       
     
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            print("test");
            GoName = col.gameObject;
            
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player"){
            GoName = null;
            
        }
    }
}
