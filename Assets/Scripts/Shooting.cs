using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootOrigin;
    //public PlayerFlip playerFlip;

    void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(shootOrigin.position, shootOrigin.right);
        Debug.DrawRay(shootOrigin.position, shootOrigin.right * -10, Color.green, 0.1f, true);

        if (hitInfo)
        {
            Debug.Log(hitInfo.transform.name);
        }
        /*
        if (playerFlip.isFacingLeft)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(shootOrigin.position, -shootOrigin.right);
            Debug.DrawRay(shootOrigin.position, shootOrigin.right * -10, Color.green, 0.1f, true);

            if (hitInfo)
            {
                Debug.Log(hitInfo.transform.name);
            }
        }

        if (playerFlip.isFacingRight)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(shootOrigin.position, shootOrigin.right);
            Debug.DrawRay(shootOrigin.position, shootOrigin.right * 10, Color.green, 0.1f, true);

            if (hitInfo)
            {
                Debug.Log(hitInfo.transform.name);
            }
        }*/
    }
}
