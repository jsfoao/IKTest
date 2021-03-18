using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{
    public Transform player;
    public Transform targetLock;
    public Transform frontTarget;
    public Transform backTarget;
    public float moveSpeed;
    public float frontStepOffset;
    public float backStepOffset;
    public float stepDistance;
    public float maxStepHeight;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetLock.position, moveSpeed * Time.deltaTime);
        CreateTarget(frontTarget, frontStepOffset);
        CreateTarget(backTarget, backStepOffset);

        float distanceStepsY;
        float distanceFront;
        float distanceBack;
        distanceStepsY = Mathf.Abs(frontTarget.position.y - backTarget.position.y);
        distanceFront = Mathf.Abs(targetLock.position.x - frontTarget.position.x);
        distanceBack = Mathf.Abs(targetLock.position.x - backTarget.position.x);
        Debug.Log(distanceStepsY);

        if (distanceFront > stepDistance && distanceStepsY < maxStepHeight)
        {
            targetLock.position = frontTarget.position;
        }
        else if (distanceBack > stepDistance && distanceStepsY < maxStepHeight)
        {
            targetLock.position = backTarget.position;
        }
    }

    private void CreateTarget(Transform target, float targetOffset)
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(player.position.x + targetOffset, player.position.y + maxStepHeight), -Vector2.up, 12f, LayerMask.GetMask("Ground"));
        //Debug.DrawRay(new Vector2(player.position.x + targetOffset, player.position.y + 2), -10* Vector2.up, Color.green, .1f, true);
        if (hit.collider != null)
        {
            target.position = new Vector2(hit.point.x, hit.point.y);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(frontTarget.position, .3f);
        Gizmos.DrawWireSphere(backTarget.position, .3f);
    }
}
