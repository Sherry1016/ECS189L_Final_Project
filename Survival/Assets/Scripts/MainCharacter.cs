using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public Animator animator;
    private float xvalue;
    private float yvalue;
    public float speed;
    private bool isattack;

    
    void Start()
    {
        
    }

    private void MoveCharacter()
    {
        xvalue = Input.GetAxis("Horizontal");
        yvalue = Input.GetAxis("Vertical");
       
        if (xvalue != 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = xvalue < 0;
            transform.Translate(xvalue * speed * Time.deltaTime * Vector2.right);
        }

        animator.SetBool("iswalk", xvalue != 0);
    }

    private void Update()
    {
        MoveCharacter();
        Attack();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            isattack = true;
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            isattack = false;
        }
        animator.SetBool("isattack", isattack);
    }

    private void OnTriggerStay2D (Collider other)
    {
        if (isattack)
        {
            //blood hurt
        }
    }
}
