﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VBPlayer : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1f;

    Rigidbody2D _body;

    public Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            _body.position += new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime,0);
        }
    }   
}
