using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpheigt;
    [SerializeField] float sensitive;

    public CharacterController controller;
    public Transform camera;
    public Transform feet;
    public Component Light1;


    float rotationX = 0.0f;
    public float gravity = 9.5f;
    float fall;
    bool onGround;
    public LayerMask ground;
    private bool isCrouching;


    public AudioClip ambient;
    private AudioSource Audio;

    void Start()
    {
        Audio = GetComponent<AudioSource>();
        Audio.clip = ambient;
        Audio.loop = true;
        Audio.Play();
    }

    void Update()
    {

        onGround = Physics.CheckSphere(feet.position,0.5f, ground);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical   = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            vertical *= 1.5f;
        }
        if (controller.isGrounded)
        {
            fall = -2;

            if (Input.GetButtonDown("Jump") && !isCrouching)
            {
                Debug.Log("Jump");
                fall = jumpheigt;

            }
        }


        fall -= gravity* Time.deltaTime;
        Vector3 move = transform.right * horizontal + transform.forward* vertical;
        move.y = fall;

        controller.Move(move*speed*Time.deltaTime);

     
        float mouseX = Input.GetAxis("Mouse X") * sensitive * Time.deltaTime;
        rotationX -= Input.GetAxis("Mouse Y") * sensitive * Time.deltaTime;

        
        rotationX = Mathf.Clamp(rotationX, -60f, 60f);

        camera.localRotation = Quaternion.Euler(rotationX, 0f,0f);
        transform.Rotate(Vector3.up * mouseX);

        if (Input.GetButtonDown("Light"))
        {
            Light1.GetComponent<Light>().enabled = !Light1.GetComponent<Light>().enabled;

        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = .5f;
            isCrouching = true;
        }
        else
        {
            controller.height = 2.8f;
            isCrouching = false;
        }
    }
}
