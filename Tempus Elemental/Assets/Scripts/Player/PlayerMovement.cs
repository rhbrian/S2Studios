﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;					//how quickly the player moves
	public float rotationSpeed = 30.0f;	//how quickly the player faces the direction they are moving
	public bool charging = false;
    public float circleOffsetCoefficient = .18f;

    private CircleCollider2D cc2d;
    private Rigidbody2D rb2d;

    void Start()
    {
		charging = false;
        rb2d = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CircleCollider2D>();
    }
		
    private void FixedUpdate()
    {
		if (!charging) {
			//x
			float moveHorizontal = Input.GetAxis ("Horizontal" + gameObject.tag);
			//y
			float moveVertical = Input.GetAxis ("Vertical" + gameObject.tag);

			Vector2 movement = new Vector2 (moveHorizontal, moveVertical).normalized;

			rb2d.velocity = movement * speed;
            cc2d.offset = movement * circleOffsetCoefficient;
			//(Parr's rotation suggestion) <- delete this comment if you like it :)
			//Angular Movement
//		if (Mathf.Abs (moveHorizontal) > 0.1 || Mathf.Abs (moveVertical) > 0.1) {
//			float angle = Mathf.Atan2 (moveVertical, moveHorizontal) * Mathf.Rad2Deg - 90;
//			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.AngleAxis (angle, Vector3.forward), Time.deltaTime * rotationSpeed);
//		} 
		} else {
			
		}
    }
}
