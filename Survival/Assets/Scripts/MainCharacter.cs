using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    private Vector3 targetposition;
    private Transform[] pirates;
    public Animator animator;
    public int life = 100;
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
        GameObject[] pirateObjects = GameObject.FindGameObjectsWithTag("Pirate");
        pirates = new Transform[pirateObjects.Length];
    
        for (int i = 0; i < pirateObjects.Length; i++)
        {
            pirates[i] = pirateObjects[i].transform;
        }

        MoveCharacter();
        Attack();
        FireBall();
        
        foreach (Transform pirate in pirates)
        {
            if (pirate != null && isattack)
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

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            isattack = true;
        }
        else
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
        else
        {
            isfireball = false;
        }
        animator.SetBool("isfireball", isfireball);
    }
}
