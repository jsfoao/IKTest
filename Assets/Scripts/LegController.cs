using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegController : MonoBehaviour
{
    public Transform leftLegPos;
    public Transform rightLegPos;
    public Transform leftLegTarget;
    public Transform rightLegTarget;
    public Transform leftLegNext;
    public Transform rightLegNext;

    public float speed;
    public float newTargetOffset;
    public float walkDistance;

    public Transform bodyTarget;
    public float bodySpeed;
    public float defaultStandDistance; //3.5

    void Update()
    {
        //Lock leg targets
        LockOnTarget(leftLegPos, leftLegTarget, speed);
        LockOnTarget(rightLegPos, rightLegTarget, speed);
        //Calculate next leg targets
        NewTarget(leftLegTarget, leftLegNext, -newTargetOffset, speed);
        NewTarget(rightLegTarget, rightLegNext, newTargetOffset, speed);

        //Calculate body target
        BodyTarget(this.transform, bodyTarget, defaultStandDistance, bodySpeed);

        float distance;
        distance = Vector2.Distance(leftLegTarget.position, leftLegNext.position);

    }

    private void NewTarget(Transform currentTarget, Transform nextTarget, float targetOffset, float speed)
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + targetOffset, transform.position.y + 2), -Vector2.up, 12f, LayerMask.GetMask("Ground"));
        //Debug.DrawRay(new Vector2(transform.position.x + targetOffset, transform.position.y + 2), -Vector2.up, Color.green, .1f, true);

        if (hit.collider != null)
        {
            nextTarget.position = new Vector2(hit.point.x, hit.point.y);

            float distance;

            distance = Vector2.Distance(currentTarget.position, nextTarget.position);
            if (Mathf.Abs(distance) > walkDistance)
            {
                currentTarget.position = nextTarget.position;
            }
        }
    }

    private float AverageLegPos(Transform leftPos, Transform rightPos)
    {
        float averagedPos;
        averagedPos = (leftPos.position.y + rightPos.position.y) / 2;
        return averagedPos;
    }

    private void BodyTarget(Transform playerTransform, Transform bodyTarget, float defaultDistance, float bodySpeed)
    {
        Vector2 newPos = new Vector2(transform.position.x, AverageLegPos(leftLegPos, rightLegPos) + defaultDistance);
        bodyTarget.position = newPos;
        LockOnTarget(this.transform, bodyTarget, bodySpeed);
    }

    private void LockOnTarget(Transform initialTarget, Transform finalTarget, float speed)
    {
        initialTarget.position = Vector2.MoveTowards(initialTarget.position, finalTarget.position, speed * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(leftLegNext.position, .2f);
        Gizmos.DrawWireSphere(rightLegNext.position, .2f);
        Gizmos.DrawWireSphere(leftLegTarget.position, .2f);
        Gizmos.DrawWireSphere(rightLegTarget.position, .2f);
        Gizmos.DrawWireSphere(bodyTarget.position, .2f);
    }
}
