using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacter : MonoBehaviour
{
    public Button startButton;
    public Image win;
    public Image lose;
    public Image BeginStory;
    public Image EndStory;
    [SerializeField]
    public GameObject productPrefab1;
    public GameObject productPrefab2;
    public GameObject productPrefab3;
    private Vector3 targetposition;
    private Transform[] pirates;
    public Animator animator;
    public Image lifeBar;
    public Image energyBar;
    public int life;
    public const int maxLife = 100;
    private float xvalue;
    private float yvalue;
    public float speed;
    private bool isFireball;
    private bool ishurt;
    public bool isDead;
    public bool isStart = false;
    private float attackCooldown = 1.0f;
    private float nextAttackTime = 0.0f;
    private float skillCooldown = 1.0f;
    private float nextSkillTime = 0.0f;
    private float dodgeCooldown = 1.0f;
    private float nextDodgeTime = 0.0f;
    private float energyRecoveryCooldown = 1.0f;
    private float nextEnergyRecoveryTime = 0.0f;
    public float direction;

    private BoxCollider2D attackCollider;

    public int energy;
    public const int maxEnergy = 30;
    private bool islanded = true;
    //private Rigidbody2D rigidbody;

    private void OnStartButtonClick()
    {
        isStart = true;
        BeginStory.gameObject.SetActive(true);
    }

    void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
        BeginStory.gameObject.SetActive(false);
        EndStory.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
        //rigidbody = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(-33.6f, transform.position.y, transform.position.z);
        targetposition = new Vector3(transform.position.x, transform.position.y, 0);
        isFireball = false;
        isDead = false;
        life = 100;
        energy = 30;
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
        if (isStart == false)
        {
            return;
        }

        if (win.gameObject.activeSelf)
        {
            EndStory.gameObject.SetActive(true);
            return;
        }
        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        lifeBar.transform.position = screenPos + new Vector3(0, 40, 0);
        lifeBar.transform.localScale = new Vector3(10, 10, 1);
        energyBar.transform.position = screenPos + new Vector3(0, 30, 0);
        energyBar.transform.localScale = new Vector3(10, 10, 1);
        if (life <= 0 && !isDead)
        {
            animator.SetBool("isdead", life <= 0);
            isDead = true;
            // if the player lose, play this sound.
            FindObjectOfType<SoundManager>().PlaySoundEffect("lose");
        }

        if (isDead)
        {
            lose.gameObject.SetActive(true);
            return;
        }

        if (Time.time > nextEnergyRecoveryTime)
        {
            nextEnergyRecoveryTime = Time.time + energyRecoveryCooldown;
            if (energy < maxEnergy)
            {
                energy++;
                energyBar.fillAmount = (float)energy / maxEnergy;
            }
        }

        GameObject[] pirateObjects = GameObject.FindGameObjectsWithTag("Pirate");
        pirates = new Transform[pirateObjects.Length];
    
        for (int i = 0; i < pirateObjects.Length; i++)
        {
            pirates[i] = pirateObjects[i].transform;
        }

        StartCoroutine(Skill());
        FireBall();
        Dodge();
        MoveCharacter();
        
    }

    private IEnumerator Jump()
    {
        if (yvalue != 0)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody.velocity.y == 0)
            {
                FindObjectOfType<SoundManager>().PlaySoundEffect("jump");
                yield return new WaitForSeconds(0.5f); // add delay
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 8);
            }
        }
    }
    
    private IEnumerator Skill()
    {
        if (Time.time > nextSkillTime)
        {
            if (Input.GetKeyDown(KeyCode.O) && energy >= 10)
            {
                nextSkillTime = Time.time + skillCooldown;
                isFireball = true;
                animator.SetTrigger("fireball");
                for(int i = 1; i <= 6; i++)
                {
                    StartCoroutine(DelayedSkill());
                    // Play a sound effect when the main character using the magic fire.
                    FindObjectOfType<SoundManager>().PlaySoundEffect("fire");
                    yield return new WaitForSeconds(0.1f);
                }
                energy = energy - 10;
                energyBar.fillAmount = (float)energy / maxEnergy;
            }
            else
            {
                isFireball = false;
            }
        }
    }
    
    private IEnumerator DelayedSkill()
    {
        yield return new WaitForSeconds(0.05f);
        
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
        fireball.GetComponent<SpriteRenderer>().flipX = gameObject.GetComponent<SpriteRenderer>().flipX;
        Rigidbody2D fireballRigidbody = fireball.GetComponent<Rigidbody2D>();
        if (gameObject.GetComponent<SpriteRenderer>().flipX == false)
        {
            fireballRigidbody.velocity = transform.right * 6;
        }
        else if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
        {
            fireballRigidbody.velocity = transform.right * -6;
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
            isFireball = true;
            StartCoroutine(DelayedFireBall());
            animator.SetTrigger("fireball");
             // Play a sound effect when the main character using the fire.
            FindObjectOfType<SoundManager>().PlaySoundEffect("fire");
        }
        else
        {
            isFireball = false;
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
            fireballRigidbody.velocity = transform.right * 6;
        }
        else if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
        {
            fireballRigidbody.velocity = transform.right * -6;
        }
        fireballRigidbody.velocity = new Vector2(fireballRigidbody.velocity.x, 0);
        fireballRigidbody.gravityScale = 0;
        Destroy(fireball, 2f);
    }

    private void Dodge()
    {
        if (Time.time > nextDodgeTime)
        {
            if (Input.GetKeyDown(KeyCode.L) && energy >= 3)
            {
                nextDodgeTime = Time.time + dodgeCooldown;
                var rigidBody = gameObject.GetComponent<Rigidbody2D>();
                // Play a sound effect when the main character defend.
                FindObjectOfType<SoundManager>().PlaySoundEffect("dodge");
                if (gameObject.GetComponent<SpriteRenderer>().flipX == false)
                {
                    rigidBody.velocity = new Vector2(6, rigidBody.velocity.y);
                }
                else
                {
                    rigidBody.velocity = new Vector2(-6, rigidBody.velocity.y);
                }
                energy = energy - 3;
                energyBar.fillAmount = (float)energy / maxEnergy;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gem")
        {
            Destroy(collision.gameObject);
            energy = energy + 5;
            energyBar.fillAmount = (float)energy / maxEnergy;
        }
    }

    public void GetHurt(int damage)
    {
        lifeBar.fillAmount = (float)life / maxLife;

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