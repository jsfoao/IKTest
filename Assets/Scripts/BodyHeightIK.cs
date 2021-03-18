using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHeightIK : MonoBehaviour
{
    public Limb rightLeg, leftLeg;
    public Transform target;
    public float speed, defaultDistance;
    //body target shit

    private void Update()
    {
        float averagedPos;
        averagedPos = (rightLeg.transform.position.y + leftLeg.transform.position.y) / 2;

        Vector2 newPos = new Vector2(transform.position.x, averagedPos + defaultDistance);
        target.position = newPos;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
