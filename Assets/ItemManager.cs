using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Transform itemOrigin;
    public Transform player;
    public Transform shootOrigin;
    // Update is called once per frame
    void Update()
    {
        transform.position = itemOrigin.position;
        transform.rotation = itemOrigin.rotation;
        transform.localScale = player.localScale;
    }
}
