using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _speed = 5f;

    private Rigidbody2D _rb;
    private Animator _animator;

    private bool _isGrounded= true;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();       
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(_speed * moveHorizontal, _rb.velocity.y);

        if (moveHorizontal != 0 ) 
        {
            _animator.SetBool("IsWalking", true);
            FlipSprite(moveHorizontal);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
        _rb.AddForce(Vector2.up * _jumpForce , ForceMode2D.Impulse);   
            _isGrounded = false;
            _animator.SetBool("IsJumping", true);
           
        }
      
            }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            _animator.SetBool("IsJumping", false);
        }
       
    }
    void FlipSprite(float moveHorizontal)
    {
        Vector3 scale = gameObject.transform.localScale;
        scale.x = (moveHorizontal > 0) ? 5 : -5;  //value comes from x scale from character
        transform.localScale = scale;
    }
}

