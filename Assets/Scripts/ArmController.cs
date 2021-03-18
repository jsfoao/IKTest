using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    public bool mouseControl;
    public Transform pointTarget;
    public Transform leftArmTarget;
    public Transform rightArmTarget;
    public Transform itemOrigin;
    public Vector3 defaultTargetPos;
    public Vector3 secTargetOffset;

    private void Update()
    {
        if (mouseControl)
        {
            pointTarget.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
        }
        else
        {
            pointTarget.position = transform.position + defaultTargetPos;
        }

        leftArmTarget.position = pointTarget.position;
        rightArmTarget.position = itemOrigin.position + secTargetOffset;
    }
}
