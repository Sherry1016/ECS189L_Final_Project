using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using Captain.Command;

public class PirateController : MonoBehaviour
{
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
        
        if (Vector3.Distance(this.gameObject.transform.position, player.position) < version)
        {
            isright = player.position.x >= transform.position.x;
            gameObject.GetComponent<SpriteRenderer>().flipX = !isright;
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, player.position, speed * Time.deltaTime);
            isattack = true;
            /*if ((Vector3.Distance(this.gameObject.transform.position, player.position) < version) && (isattack == true))
            {
                Debug.Log("damage");
                MainCharacter mainCharacter = player.GetComponent<MainCharacter>();
                mainCharacter.life -= damage;
                isattack = false;
            }*/
        }
        else
        {
            isattack = false;
            if (Vector3.Distance(this.gameObject.transform.position, targetposition) > 0.1f)
            {
                isright = targetposition.x >= transform.position.x;
                gameObject.GetComponent<SpriteRenderer>().flipX = !isright;
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, targetposition, speed * Time.deltaTime);
            }
            else
            {
                limitSpace = Random.Range(-19, 19);
                isright = limitSpace >= transform.position.x;
                gameObject.GetComponent<SpriteRenderer>().flipX = !isright;
                targetposition = new Vector3(limitSpace, transform.position.y, 0);
            }
        }

        if (blood <= 0)
        {
            spawnSystem.MonsterKilled(gameObject);
            Destroy(gameObject);
        }
        
        animator.SetBool("isattack", isattack);
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
    public void Motivate()
    {
       

    }

}

