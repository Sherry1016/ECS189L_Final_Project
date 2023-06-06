using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCaptain : MonoBehaviour
{
    public GameObject Ground2;
    public GameObject Ground3;
    public GameObject DestinationLevel;
    public Camera MainCamera;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if Ground2 still has monsters. If so, set DestinationLevel to Sunset
        if (SpawnSystem.monstersByGround.ContainsKey(Ground2) && SpawnSystem.monstersByGround[Ground2].Count > 0)
        {
            DestinationLevel = GameObject.Find("Sunset");
        }
        
        // Check if Ground3 still has monsters. If so, set DestinationLevel to Nighttime
        else if (SpawnSystem.monstersByGround.ContainsKey(Ground3) && SpawnSystem.monstersByGround[Ground3].Count > 0)
        {
            DestinationLevel = GameObject.Find("Nighttime");
        }

        if(collision.gameObject.name == "Main Character")
        {
            collision.gameObject.transform.position = new Vector2(Random.value * 20.0f - 10.0f, this.DestinationLevel.transform.position.y + 4);
            this.MainCamera.transform.position = new Vector3(this.DestinationLevel.transform.position.x, this.DestinationLevel.transform.position.y, this.MainCamera.transform.position.z);
            FindObjectOfType<SoundManager>().PlaySoundEffect("bomb");
        }
    }
}

