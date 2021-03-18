using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnTarget : MonoBehaviour
{
    public Transform cameraTarget;
    public float cameraOffset;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y, cameraOffset);
    }
}
