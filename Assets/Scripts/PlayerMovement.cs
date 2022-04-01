using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Speed = 5f;
    GameObject BiteBox;
    SpriteRenderer _SprRenderer;
    Animator _Animator;
    Rigidbody2D _Rb;
    Vector3 firstPosition, lastPosition;
    bool isMoving, isBiting;

    private float speedModifier = 100f;

    void Start()
    {
        _SprRenderer = GetComponent<SpriteRenderer>();
        BiteBox = transform.GetChild(0).gameObject;
        _Animator = GetComponent<Animator>();
        _Rb = GetComponent<Rigidbody2D>();
        firstPosition = this.transform.position;
        BiteBox.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isBiting == false)
        {
            StartCoroutine(BiteTimer());
        }
    }

    void FixedUpdate()
    {
        InputHandler();

        lastPosition = this.transform.position;
        if (lastPosition != firstPosition)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
            _Animator.SetInteger("AnimDir", 0);
        }
        firstPosition = lastPosition;
    }

    private void InputHandler()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.up * Speed / speedModifier);
            BiteBox.transform.localPosition = new Vector3(0, 0.8f, transform.localPosition.z);
            _Animator.SetInteger("AnimDir", 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector3.right * -Speed / speedModifier);
            BiteBox.transform.localPosition = new Vector3(-1.25f, 0, transform.localPosition.z);
            _SprRenderer.flipX = false;
            _Animator.SetInteger("AnimDir", 3);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.up * -Speed / speedModifier);
            BiteBox.transform.localPosition = new Vector3(0, -0.8f, transform.localPosition.z);
            _Animator.SetInteger("AnimDir", 2);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.right * Speed / speedModifier);
            BiteBox.transform.localPosition = new Vector3(1.25f, 0, transform.localPosition.z);
            _SprRenderer.flipX = true;
            _Animator.SetInteger("AnimDir", 4);
        }
    }

    IEnumerator BiteTimer()
    {
        isBiting = true;
        BiteBox.SetActive(true);
        yield return new WaitForSeconds(1);
        BiteBox.SetActive(false);
        isBiting = false;
    }
}
