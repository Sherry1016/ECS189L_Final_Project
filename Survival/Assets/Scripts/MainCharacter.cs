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
    private bool ishurt;
    public bool isDead;
    public int attackPower = 35;
    private float attackCooldown = 1.0f;
    private float nextAttackTime = 0.0f;
    public float direction;

    private BoxCollider2D attackCollider;
    public float attackRange = 2.0f;
    public float attackHeight = 1.0f;

    public int energe;
    private bool islanded = true;
    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        targetposition = new Vector3(transform.position.x, transform.position.y, 0);
        isattack = false;
        isfireball = false;
        isDead = false;
        energe = 30;
    }

    private void MoveCharacter()
    {
        xvalue = Input.GetAxis("Horizontal");
        yvalue = Input.GetAxis("Vertical");

        float camHalfHeight = Camera.main.orthographicSize;
        float camHalfWidth = camHalfHeight * Camera.main.aspect;

        float minX = Camera.main.transform.position.x - camHalfWidth;
        float maxX = Camera.main.transform.position.x + camHalfWidth;
        float minY = Camera.main.transform.position.y - camHalfHeight;
        float maxY = Camera.main.transform.position.y + camHalfHeight;

        if (xvalue != 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = xvalue < 0;
            Vector3 moveDirection = xvalue * speed * Time.deltaTime * Vector2.right;
            Vector3 newPosition = transform.position + moveDirection;

            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            transform.position = newPosition;
        }

        if (yvalue != 0 && islanded == true)
        {
            islanded = false;
            animator.SetTrigger("jump");
            StartCoroutine(Jump());
        }

        if (yvalue == 0)
        {
            islanded = true;
        }

        animator.SetBool("iswalk", xvalue != 0);
    }

    private void Update()
    {

        if (life <= 0 && !isDead)
        {
            Debug.Log("No blood");
            animator.SetBool("isdead", life <= 0);
            isDead = true;
        }

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

    private IEnumerator Jump()
    {
        if (yvalue != 0)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody.velocity.y == 0)
            {
                yield return new WaitForSeconds(0.5f); // add delay
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 8);
            }
        }
    }
    
    private IEnumerator Skill()
    {
        if (Input.GetKeyDown(KeyCode.O) && energy >= 0)
        {
            isfireball = true;
            animator.SetTrigger("fireball");
            //animator.SetTrigger("attackPose");
            for(int i = 1; i <= 5; i++)
            {
                StartCoroutine(DelayedSkill());
                yield return new WaitForSeconds(0.1f);
            }
            energy = energy - 10;
        }
        else
        {
            isfireball = false;
        }
    }
    
    private IEnumerator DelayedSkill()
    {
        yield return new WaitForSeconds(0.1f);
        
        direction = 0f;
        if (gameObject.GetComponent<SpriteRenderer>().flipX == false)
        {
            direction = 0.7f;
        }
        else if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
        {
            direction = -0.7f;
        }
        float height = Random.Range(-1.8f, -0.5f);
        Vector3 fireballPosition = transform.position + new Vector3(direction, height, 0f);
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
        yield return new WaitForSeconds(0.65f);

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
        fireball.GetComponent<SpriteRenderer>().flipX = gameObject.GetComponent<SpriteRenderer>().flipX;
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
            energy = energe + 10;
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

    public void GetHurt(int damage)
    {
        if (isDead)
        {
            return;
        }

        life -= 10; //damage;
        
        if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
        {
            rigidbody.AddForce(new Vector2(-5, 3), ForceMode2D.Impulse);
        }
        else
        {
            rigidbody.AddForce(new Vector2(5, 3), ForceMode2D.Impulse);
        }

        animator.SetBool("ishurt", true);
        ishurt = true;
        StartCoroutine(BoolDelay());
    }

    IEnumerator BoolDelay()
    {
        yield return new WaitForSeconds(0.35f);
        if (ishurt)
        {
            animator.SetBool("ishurt", false);
            ishurt = false;
        }
    }
}
