using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    public Transform player;
    public Transform playerPos;
    public Transform armOrigin;
    public bool isFacingLeft;
    public bool isFacingRight;
    private Vector3 rightScale;
    private Vector3 leftScale;

    void Start()
    {
        rightScale = player.transform.localScale;
        leftScale = rightScale;
        leftScale.x = -rightScale.x;
    }

    void FixedUpdate()
    {
        Vector3 difference = armOrigin.position - playerPos.position;
        difference.Normalize();

        if (difference.x >= 0)
        {
            player.transform.localScale = leftScale;
            isFacingRight = true;
            isFacingLeft = false;
        }

        if (difference.x < 0)
        {
            player.transform.localScale = rightScale;
            isFacingRight = false;
            isFacingLeft = true;
        }
    }
}
