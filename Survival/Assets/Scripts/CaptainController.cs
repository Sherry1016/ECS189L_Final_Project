using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Captain.Command;

public class CaptainController : MonoBehaviour
{
    private ICaptainCommand fire1;
    private ICaptainCommand fire2;
    private ICaptainCommand right;
    private ICaptainCommand left;

    [SerializeField]
    private UnityEngine.UI.Text booty;
    private int mushrooms;
    private int skulls;
    private int gems;
    private float lastAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.AddComponent<CaptainMotivateCommand>();
        //this.fire1 = gameObject.AddComponent<CaptainMotivateCommand>();
        this.fire2 = ScriptableObject.CreateInstance<MoveCharacterUp>();
        this.right = ScriptableObject.CreateInstance<MoveCharacterRight>();
        this.left = ScriptableObject.CreateInstance<MoveCharacterLeft>();
        this.booty.text = "Booty";
        this.lastAttackTime = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time - lastAttackTime >= 0.5f)
        {
            this.fire1.Execute(this.gameObject);
            lastAttackTime = Time.time;
        }
        if (Input.GetAxis("Vertical") > 0.01)
        {
            this.fire2.Execute(this.gameObject);
        }
        if(Input.GetAxis("Horizontal") > 0.01)
        {
            this.right.Execute(this.gameObject);
        }
        if(Input.GetAxis("Horizontal") < -0.01)
        {
            this.left.Execute(this.gameObject);
        }

        var animator = this.gameObject.GetComponent<Animator>();
        animator.SetFloat("Velocity", Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.x/5.0f));
        this.booty.text = "x" + (this.mushrooms * 1 + this.gems * 3 + this.skulls * 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision);
        if (collision.gameObject.tag == "Mushroom")
        {
            Destroy(collision.gameObject);
            this.mushrooms++;
        }
        else if (collision.gameObject.tag == "Skull")
        {
            Destroy(collision.gameObject);
            this.skulls++;
        }
        else if(collision.gameObject.tag == "Gem")
        {
            Destroy(collision.gameObject);
            this.gems++;
        }
    }
}