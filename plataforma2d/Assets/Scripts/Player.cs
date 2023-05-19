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
    private float moveY;
    private Rigidbody2D rigi;

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
    }

    void onMove()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        rigi.velocity = new Vector2(moveX * moveSpeed, rigi.velocity.y);

        if (moveX > 0) { transform.eulerAngles = new Vector3(0, 0, 0); }
        if (moveX < 0) { transform.eulerAngles = new Vector3(0, 180, 0); }
        //TODO animação de caminhada

    }


    void onJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigi.velocity = new Vector2(rigi.velocity.x, jumpForce * Time.fixedDeltaTime );
            //TODO , verificar se esta ocando no chão , animeção de pula
        }
    }
}
