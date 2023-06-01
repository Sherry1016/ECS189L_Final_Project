using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

public class PirateController : MonoBehaviour
{
    [SerializeField]
    public IPirateCommand activeCommand;
    
    [SerializeField]
    public GameObject productPrefab;

    public float speed = 1.0f;
    private float limitSpace;


// Start is called before the first frame update
void Start()
    {
        this.activeCommand = ScriptableObject.CreateInstance<SlowWorkerPirateCommand>();
        limitSpace = Random.Range(-19, 19);
    }

    // Update is called once per frame
    void Update()
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
        Vector3 targetposition = new Vector3(limitSpace, 0, 0);
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, targetposition, everyStep);

        if (Vector3.Distance(this.gameObject.transform.position, targetposition) < 0.1f)
        {
            limitSpace = Random.Range(-19, 19);
        } 
        
    }

    //Has received motivation. A likely source is from on of the Captain's morale inducements.
    public void Motivate()
    {
        var rand = new System.Random();
        int workStyle = rand.Next(1,4);
        switch (workStyle)
        {
            case 1:
                StartCoroutine(prefabDelay());
                break;
            case 2:
                StartCoroutine(prefabDelay());
                break;
            case 3:
                StartCoroutine(prefabDelay());
                break;
        }

    }

    IEnumerator prefabDelay()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
        Instantiate(productPrefab, transform.position + new Vector3(Random.Range(0, 5),0,0), Quaternion.identity);
        Instantiate(productPrefab, transform.position + new Vector3(Random.Range(0, 5), 0, 0), Quaternion.identity);
        Instantiate(productPrefab, transform.position + new Vector3(Random.Range(0, 5), 0, 0), Quaternion.identity);
    }
}
