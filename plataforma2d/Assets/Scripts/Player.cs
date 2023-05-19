using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float moveX;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    public Transform isGroundPosition;
    public Transform spritePlayer;
    //public Animator anim;
    public float radius;
    private float moveY;
    private Rigidbody2D rigi;
    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        onMove();
        onJump();
        //confirmedGrounded();
    }

    void onMove()
    {

        Collider2D isGround = Physics2D.OverlapCircle(isGroundPosition.position, radius, layer);


        moveX = Input.GetAxisRaw("Horizontal");
        rigi.velocity = new Vector2(moveX * moveSpeed, rigi.velocity.y);

        if (moveX > 0 && isGround)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
                spritePlayer.GetComponent<Animator>().SetInteger("transition", 1);
        }
        if (moveX < 0 && isGround) 
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
                spritePlayer.GetComponent<Animator>().SetInteger("transition", 1);
        }

        if (isGround && moveX == 0)
        {
            spritePlayer.GetComponent<Animator>().SetInteger("transition", 0);
        }


        //TODO animação de caminhada

    }


    void onJump()
    {
        Collider2D isGround = Physics2D.OverlapCircle(isGroundPosition.position, radius, layer);
        //if(isGround != null) { Debug.Log("tocou o chao"); }

        if (Input.GetButtonDown("Jump") && isGround)
        {
            rigi.AddForce(Vector2.up * jumpForce , ForceMode2D.Impulse);
                spritePlayer.GetComponent<Animator>().SetInteger("transition", 2);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(isGroundPosition.position, radius);
    }
}
