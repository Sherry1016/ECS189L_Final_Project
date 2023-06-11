using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//using Captain.Command;

public enum MonsterType
{
    None = 0,
    Gobline,
    Flyingeye,
    Mushroom
}

public class PirateController : MonoBehaviour
{
    [SerializeField]
    public GameObject productPrefab;
    public Image bloodBar;
    public float speed;
    public float version;
    private float limitSpace;
    private bool isright;
    private Vector3 targetposition;
    private Transform player;
    private bool isattack;
    public Animator animator;
    public int blood;
    public int maxBlood;
    public int damage;
    private SpawnSystem spawnSystem;
    private Color initialColor;

    public MonsterType monsterType = MonsterType.None;

    void Start()
    {
        initialColor = GetComponent<Renderer>().material.color;
        maxBlood = blood;
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
        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        bloodBar.transform.position = screenPos + new Vector3(0, 45, 0);
        bloodBar.transform.localScale = new Vector3(10, 10, 1);
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
                //Debug.Log("change");
            }
        }

        if (blood <= 0)
        {
            spawnSystem.MonsterKilled(gameObject);
            Destroy(gameObject);
            int range = 3; // The probability of dropping a gem
            switch (monsterType)
            {
                case MonsterType.Gobline:
                    range = 4;
                    break;
                case MonsterType.Flyingeye:
                    range = 5;
                    break;
                case MonsterType.Mushroom:
                    range = 6;
                    break;
            }
            int actionNumber = Random.Range(1, range);
            if (actionNumber == 1)
            {
                GameObject product = Instantiate(productPrefab, transform.position + new Vector3(Random.Range(0, 5), 0, 0), Quaternion.identity);
                Debug.Log("have prefab");
            }

            /*var coinCount = 0;
            switch (monsterType)
            {
                case MonsterType.Gobline:
                    coinCount = 1;
                    break;
                case MonsterType.Flyingeye:
                    coinCount = 2;
                    break;
                case MonsterType.Mushroom:
                    coinCount = 3;
                    break;
            }

            for (int i = 0; i < coinCount; i++)
            {
                GameObject product = Instantiate(productPrefab, transform.position + new Vector3(Random.Range(0, 5), 0, 0), Quaternion.identity);
                Debug.Log("have prefab");
            }*/
            
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
                    animator.SetBool("isattack", isattack);
                    MainCharacter mainCharacter = player.GetComponent<MainCharacter>();
                    Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
                    if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
                    {
                        rb.AddForce(new Vector2(-5, 3), ForceMode2D.Impulse);
                    }
                    else
                    {
                        rb.AddForce(new Vector2(5, 3), ForceMode2D.Impulse);
                    }
                    mainCharacter.life -= damage; //damage
                    mainCharacter.GetHurt(damage);
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
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Skull")
        {
            Debug.Log("Fire!");
            blood -= 15;
            bloodBar.fillAmount = (float)blood / maxBlood;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Slow")
        {
            Debug.Log("Slow!");
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.color = Color.green;
            blood = blood - 10;
            bloodBar.fillAmount = (float)blood / maxBlood;
            speed = speed / 3;
            StartCoroutine(ResetSpeedAfterDelay(5));
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "Boom")
        {
            Debug.Log("Boom!");
            blood = blood - 30;
            bloodBar.fillAmount = (float)blood / maxBlood;
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator ResetSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<Renderer>().material.color = initialColor;
        speed = speed * 3;
    }
}
