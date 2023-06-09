using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using Captain.Command;

public class PirateController : MonoBehaviour
{
    [SerializeField]
    public GameObject productPrefab;
    public float speed;
    public float version;
    private float limitSpace;
    private bool isright;
    private Vector3 targetposition;
    private Transform player;
    private bool isattack;
    public Animator animator;
    public int blood;
    public int damage = 35;
    private SpawnSystem spawnSystem;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        limitSpace = Random.Range(-19, 19);
        isright = limitSpace >= transform.position.x;
        gameObject.GetComponent<SpriteRenderer>().flipX = !isright;
        targetposition = new Vector3(limitSpace, transform.position.y, 0);
        GameObject spawnSystemObject = GameObject.Find("SpawnSystem");
        if (spawnSystemObject != null)
        {
            spawnSystem = spawnSystemObject.GetComponent<SpawnSystem>();
        }
    }

    private void Update()
    {
        MainCharacter mainCharacter = player.GetComponent<MainCharacter>();
        if (mainCharacter.isDead)
        {
            isattack = false;
            //animator.SetBool("isattack", isattack);
            return;
        }

        if (Vector3.Distance(this.gameObject.transform.position, player.position) < version)
        {
            isright = player.position.x >= transform.position.x;
            gameObject.GetComponent<SpriteRenderer>().flipX = !isright;
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, player.position, speed * Time.deltaTime);
            if (!isattack)
            {
                isattack = true;
                StartCoroutine(AttackWithDelay());
            }
        }
        else
        {
            isattack = false;
            if (Vector3.Distance(this.gameObject.transform.position, targetposition) > 0.1f)
            {
                isright = targetposition.x >= transform.position.x;
                gameObject.GetComponent<SpriteRenderer>().flipX = !isright;
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, targetposition, speed * Time.deltaTime);
                animator.SetBool("iswalk", true);
            }
            else
            {
                limitSpace = Random.Range(-19, 19);
                isright = limitSpace >= transform.position.x;
                gameObject.GetComponent<SpriteRenderer>().flipX = !isright;
                targetposition = new Vector3(limitSpace, transform.position.y, 0);
                animator.SetBool("iswalk", false);
                Debug.Log("change");
            }
        }

        if (blood <= 0)
        {
            spawnSystem.MonsterKilled(gameObject);
            Destroy(gameObject);
            int actionNumber = Random.Range(1, 3);
            if (actionNumber == 1)
            {
                GameObject product = Instantiate(productPrefab, transform.position + new Vector3(Random.Range(0, 5), 0, 0), Quaternion.identity);
                product.transform.position = Vector3.MoveTowards(product.transform.position, player.position, 6 * Time.deltaTime);
            }
        }
        
        animator.SetBool("isattack", isattack);
    }

    private IEnumerator AttackWithDelay()
    {
        while (true)
        {
            if ((Vector3.Distance(this.gameObject.transform.position, player.position) < version))
            {
                yield return new WaitForSeconds(Random.Range(1.5f, 3.0f));
                if ((Vector3.Distance(this.gameObject.transform.position, player.position) < version))
                {
                    Debug.Log("damage");
                    MainCharacter mainCharacter = player.GetComponent<MainCharacter>();
                    mainCharacter.life -= damage;
                    Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
                    if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
                    {
                        rb.AddForce(new Vector2(-5, 3), ForceMode2D.Impulse);
                    }
                    else
                    {
                        rb.AddForce(new Vector2(5, 3), ForceMode2D.Impulse);
                    }
                }
                else
                {
                    yield break;
                }
            }
            else
            {
                yield break;
            }
        }
    }

    

    // Update is called once per frame
   /* void Update()
    {
        if (limitSpace > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        var working = this.activeCommand.Execute(this.gameObject, this.productPrefab);

        this.gameObject.GetComponent<Animator>().SetBool("Exhausted", !working);

        float everyStep = speed * Time.deltaTime;
        Vector3 targetposition = new Vector3(limitSpace, transform.position.y, 0);
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, targetposition, everyStep);

        if (Vector3.Distance(this.gameObject.transform.position, targetposition) < 0.1f)
        {
            limitSpace = Random.Range(-19, 19);
        } 
        
    }*/

    //Has received motivation. A likely source is from on of the Captain's morale inducements.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Skull")
        {
            Debug.Log("Fire!");
            blood = blood - 20;
            MainCharacter mainCharacter = player.GetComponent<MainCharacter>();
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(mainCharacter.direction * 7, 0), ForceMode2D.Impulse);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Slow")
        {
            Debug.Log("Slow!");
            blood = blood - 15;
            speed = speed / 2;
            StartCoroutine(ResetSpeedAfterDelay(5));
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "Boom")
        {
            Debug.Log("Boom!");
            blood = blood - 50;
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator ResetSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        speed = speed * 2;
    }
}
