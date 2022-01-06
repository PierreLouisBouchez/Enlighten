using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miroir : MonoBehaviour
{
    public Transform CameraMiroir;
    public Transform PlayerCamera;

    // Update is called once per frame
    void Update()
    {
        CalculateRotation();
    }

    void CalculateRotation()
    {

        Vector3 dir = (PlayerCamera.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(dir);
        rotation.eulerAngles = transform.eulerAngles - rotation.eulerAngles;
        CameraMiroir.localRotation = rotation;
    }
}
