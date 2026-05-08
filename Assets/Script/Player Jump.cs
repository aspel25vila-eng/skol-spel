using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rigibody;
    private float moveX;
    private Vector2 movement;
    public float MoveSpeed = 5f;

    public float Movespeed = 5f;
    public float JumpForce = 10f;
    public LayerMask GroundLayer;
    public BoxCollider2D GroundCollider;
    public bool Onground;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigibody = GetComponent<Rigidbody2D>();
        Onground = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.UpArrow) && Onground)
        {
            _rigibody.linearVelocity = new Vector2(_rigibody.linearVelocity.x, JumpForce);
            Onground = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(GroundLayer == (1 << other.gameObject.layer))
        {
            Onground = true;
        }
    }

    private void FixedUpdate()
    {
        movement = new Vector2(moveX * MoveSpeed, _rigibody.linearVelocity .y);
        _rigibody.linearVelocity = movement;

    }
}
