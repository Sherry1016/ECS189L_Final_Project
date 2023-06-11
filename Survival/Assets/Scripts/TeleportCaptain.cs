using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportCaptain : MonoBehaviour
{
    public Image win;
    public GameObject Ground2;
    public GameObject Ground3;
    public GameObject DestinationLevel;
    public Camera MainCamera;

    void Start()
    {
        win.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (SpawnSystem.monstersByGround.ContainsKey(Ground2) && SpawnSystem.monstersByGround[Ground2].Count > 0)
        {
            DestinationLevel = GameObject.Find("Sunset");
        }
        
        else if (SpawnSystem.monstersByGround.ContainsKey(Ground3) && SpawnSystem.monstersByGround[Ground3].Count > 0)
        {
            DestinationLevel = GameObject.Find("Nighttime");
        }
        else
        {
            win.gameObject.SetActive(true);
            return;
        }

        if(collision.gameObject.name == "Main Character")
        {
            collision.gameObject.transform.position = new Vector2(-33.6f, this.DestinationLevel.transform.position.y + 3);
            this.MainCamera.transform.position = new Vector3(this.DestinationLevel.transform.position.x - 19.2f, this.DestinationLevel.transform.position.y, this.MainCamera.transform.position.z);
            FindObjectOfType<SoundManager>().PlaySoundEffect("bomb");
        }
    }
}

