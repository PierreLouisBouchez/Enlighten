using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour{

    private GameObject grandChild;
    public Rigidbody[] obj;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if(grandChild != null && Input.GetKeyDown(KeyCode.A)){
            foreach (var ob in obj){
                ob.useGravity = !ob.useGravity;
            }
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Button"){
            print("test");
            grandChild = col.gameObject.transform.parent.gameObject;
            obj = grandChild.GetComponentsInChildren<Rigidbody>(true);
            
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Button"){
            grandChild = null;
            
            
        }
    }

    
}
