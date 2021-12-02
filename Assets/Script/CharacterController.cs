using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float sensitive;

    [SerializeField] float lateralspeed;
    float timer = 0;
    float defaultPosY = 0;

    float rotateX = 0.0f;
    float rotateY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        Transform c = GetComponent<Transform>();
        Camera camera = Camera.main;
        Transform cameraTransform = camera.GetComponent<Transform>();



        if (Input.GetKey(KeyCode.Z))
        {
            c.Translate(Vector3.forward * speed * Time.deltaTime );
        }
        if (Input.GetKey(KeyCode.S))
        {
            c.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            c.Translate(Vector3.left * lateralspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            c.Translate(Vector3.right * lateralspeed * Time.deltaTime);
        }


        rotateY += Input.GetAxis("Mouse X") * sensitive;
        rotateX -= Input.GetAxis("Mouse Y") * sensitive;

        rotateX = Mathf.Clamp(rotateX, -60f, 60f);

        cameraTransform.localEulerAngles = new  Vector3(rotateX,0,0)  ;


        c.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * sensitive , 0));

        
        
        /*
        timer += Time.deltaTime * 5.0f;
        transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * 0.1f, transform.localPosition.z);
        */

    }
}
