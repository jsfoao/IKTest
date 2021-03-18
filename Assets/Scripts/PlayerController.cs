using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    public GameObject player;
    private Rigidbody2D player_rb;

    void Start()
    {
        player_rb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Horizontal movement
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        //Jump
        if (Input.GetButtonDown("Jump") && player_rb.velocity.y < 0.0001f && player_rb.velocity.y > -0.0001f)
        {
            player_rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
