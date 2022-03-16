using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] Sprite LeftSpr, UpSpr, DownSpr;
    private bool DirectionX, DirectionY;
    SpriteRenderer _SprRenderer;
    Animator _Animator;
    Rigidbody2D _Rb;

    void Start()
    {
        _SprRenderer = GetComponent<SpriteRenderer>();
        _Animator = GetComponent<Animator>();
        _Rb = GetComponent<Rigidbody2D>();
    }

   
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.up * Speed);
           // _SprRenderer.sprite = UpSpr;
           // _SprRenderer.flipY = false;
            DirectionY = true;
            _Animator.SetBool("WalkUp", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector3.right * -Speed);
            //_SprRenderer.sprite = LeftSpr;
            //_SprRenderer.flipX = false;
            DirectionX = true;

            _Animator.SetBool("WalkLeft", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.up * -Speed);
            //_SprRenderer.sprite = UpSpr;
            //_SprRenderer.flipY = true;
            DirectionY = false;
            _Animator.SetBool("WalkDown", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.right * Speed);
            //_SprRenderer.sprite = LeftSpr;
            //_SprRenderer.flipX = true;
            DirectionX = false;
            _Animator.SetBool("WalkRight", true);
        }
        if (_Rb.velocity.magnitude < 0.5f)
        {
            print("I WANT TO IDLE");
            _Animator.SetBool("IsIdle", true);
        }

    }
}
