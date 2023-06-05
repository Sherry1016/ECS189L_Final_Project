using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    private Vector3 targetposition;
    private Transform pirate;
    public Animator animator;
    private float elapsedTime;
    private const float DURATION = 0.4f;
    private float xvalue;
    private float yvalue;
    public float speed;
    public float version;
    private bool isattack;
    private bool isfireball;
    public int attackPower = 35;

    void Start()
    {
        targetposition = new Vector3(transform.position.x, transform.position.y, 0);
        this.elapsedTime = 0.0f;
        isattack = false;
        isfireball = false;
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
        if (pirate == null)
        {
            pirate = GameObject.FindGameObjectWithTag("Pirate").transform;
        }

        MoveCharacter();
        Attack();
        FireBall();
        if (isattack && pirate != null)
        {
            //blood hurt
            if (Vector3.Distance(this.gameObject.transform.position, pirate.position) < version)
            {
                Debug.Log("attack");
                PirateController pirateController = pirate.GetComponent<PirateController>();
                pirateController.blood -= attackPower;
                isattack = false;
            }
        }
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

    private void FireBall()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            isfireball = true;
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            isfireball = false;
        }
        animator.SetBool("isfireball", isfireball);
    }

    /*private void OnTriggerStay2D(Collider2D other)
    {
        if (isattack && other.gameObject.CompareTag("Pirate"))
        {
            // blood hurt
            PirateController pirateController = other.gameObject.GetComponent<PirateController>();
            isattack = false;
            if (pirateController != null)
            {
                pirateController.blood -= attackPower;
                Debug.Log("Pirate health: " + pirateController.blood);
            }
        }
    }*/
}
