using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gravity : MonoBehaviour{

    private GameObject grandChild;

    public GameObject LightText;
    public GameObject GravityText;
    public PlayerController Player;


    private Rigidbody[] obj;
    private Light[] Lights;
    private bool gravityOn=true;
    private bool lightOn=true;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (grandChild != null && Input.GetKeyDown(KeyCode.G)){
            foreach (var ob in obj){
                ob.useGravity = !ob.useGravity;

            }
            gravityOn = !gravityOn;
        }
        if (gravityOn){
            GravityText.GetComponent<Text>().text = "Press G to disable Gravity";
        }else{
            GravityText.GetComponent<Text>().text = "Press G to enable Gravity";
        }

        if (grandChild != null && Input.GetKeyDown(KeyCode.L)){
            foreach (Light light in Lights){
                light.enabled = !light.enabled;
            }
            lightOn = !lightOn;
        }
        if (lightOn){
            LightText.GetComponent<Text>().text = "Press L to disable Lights";
        }else{
            LightText.GetComponent<Text>().text = "Press L to enable Lights";
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Button"){           
            grandChild = col.gameObject.transform.parent.gameObject;
            obj = grandChild.GetComponentsInChildren<Rigidbody>(true);     
            Lights = grandChild.GetComponentsInChildren<Light>(true);
            lightOn = Lights[0].enabled;
            gravityOn = obj[0].useGravity;
            GravityText.SetActive(true);
            LightText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Button"){
            grandChild = null;
            GravityText.SetActive(false);
            LightText.SetActive(false);

        }
    }

    
}
