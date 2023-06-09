using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    [SerializeField]
    public GameObject productPrefab1;
    public GameObject productPrefab2;
    public GameObject productPrefab3;
    private Vector3 targetposition;
    private Transform[] pirates;
    public Animator animator;
    public int life = 100;
    private float xvalue;
    private float yvalue;
    public float speed;
    private bool isattack;
    private bool isfireball;
    private bool isflame;
    public bool isDead;
    public int attackPower = 35;
    private float attackCooldown = 1.0f;
    private float nextAttackTime = 0.0f;
    public float direction;

    private BoxCollider2D attackCollider;
    public float attackRange = 2.0f;
    public float attackHeight = 1.0f;

    public int skillPoint;

    void Start()
    {
        targetposition = new Vector3(transform.position.x, transform.position.y, 0);
        isattack = false;
        isfireball = false;
        isDead = false;
        skillPoint = 0;
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

        if (yvalue != 0)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody.velocity.y==0)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 8);
            }
        }

        animator.SetBool("iswalk", xvalue != 0);
    }

    private void Update()
    {
        if (isDead)
        {
            return;
        }

        GameObject[] pirateObjects = GameObject.FindGameObjectsWithTag("Pirate");
        pirates = new Transform[pirateObjects.Length];
    
        for (int i = 0; i < pirateObjects.Length; i++)
        {
            pirates[i] = pirateObjects[i].transform;
        }

        //Attack();
        StartCoroutine(Skill());
        FireBall();
        //Flame();
        Dodge();
        MoveCharacter();
        

        if (life <= 0)
        {
            Debug.Log("No blood");
            //animator.SetBool("isdead", life <= 0);
            isDead = true;
        }
    }

    /*private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J) && Time.time > nextAttackTime)
        {
            animator.SetTrigger("attack");
            nextAttackTime = Time.time + attackCooldown;
            attackCollider = gameObject.AddComponent<BoxCollider2D>();
            attackCollider.isTrigger = true;
            attackCollider.size = new Vector2(attackRange, attackHeight);
            isattack = true;
        }
        else
        {
            isattack = false;
            if (attackCollider != null)
            {
                Destroy(attackCollider);
            }
        }
    }*/
    
    private IEnumerator Skill()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            isfireball = true;
            animator.SetTrigger("fireball");
            //animator.SetTrigger("attackPose");
            for(int i = 1; i <= 5; i++)
            {
                StartCoroutine(DelayedFireBall());
                yield return new WaitForSeconds(0.5f);
            }
            skillPoint--;
        }
        else
        {
            isfireball = false;
            //animator.ResetTrigger("attackPose");
        }
    }

    private void FireBall()
    {
        if (Input.GetKeyDown(KeyCode.J) && Time.time > nextAttackTime)
        {
            nextAttackTime = Time.time + attackCooldown;
            isfireball = true;
            StartCoroutine(DelayedFireBall());
            animator.SetTrigger("fireball");
        }
        else
        {
            isfireball = false;
        }

    }

    private IEnumerator DelayedFireBall()
    {
        // Wait for 0.75 second
        yield return new WaitForSeconds(0.75f);
        
        direction = 0f;
        if (gameObject.GetComponent<SpriteRenderer>().flipX == false)
        {
            direction = 0.7f;
        }
        else if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
        {
            direction = -0.7f;
        }
        Vector3 fireballPosition = transform.position + new Vector3(direction, -0.55f, 0f);
        int actionNumber = Random.Range(1, 10);
        GameObject fireball = null;
        if (actionNumber <= 5)
        {
            fireball = Instantiate(productPrefab1, fireballPosition, Quaternion.identity);
        }
        else if (actionNumber > 5 && actionNumber <= 8)
        {
            fireball = Instantiate(productPrefab2, fireballPosition, Quaternion.identity);
        }
        else if (actionNumber == 9)
        {
            fireball = Instantiate(productPrefab3, fireballPosition, Quaternion.identity);
        }
        Rigidbody2D fireballRigidbody = fireball.GetComponent<Rigidbody2D>();
        if (gameObject.GetComponent<SpriteRenderer>().flipX == false)
        {
            fireballRigidbody.velocity = transform.right * 5;
        }
        else if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
        {
            fireballRigidbody.velocity = transform.right * -5;
        }
        fireballRigidbody.velocity = new Vector2(fireballRigidbody.velocity.x, 0);
        fireballRigidbody.gravityScale = 0;
        Destroy(fireball, 2f);
    }


    /*private void Flame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isflame = true;
            animator.SetTrigger("flame");
        }
        else
        {
            isflame = false;
        }
    }*/

    private void Dodge()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (gameObject.GetComponent<SpriteRenderer>().flipX == false)
            {
                rigidBody.velocity = new Vector2(6, rigidBody.velocity.y);
            }
            else
            {
                rigidBody.velocity = new Vector2(-6, rigidBody.velocity.y);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gem")
        {
            Destroy(collision.gameObject);
            this.skillPoint++;
        }
    }

    /*void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Pirate")) 
        {
            if (isattack) {
                Debug.Log("attack");
                PirateController pirateController = other.gameObject.GetComponent<PirateController>();
                pirateController.blood -= attackPower;
            }
        }
    }*/
}
