using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject Ground1;
    public GameObject Ground2;
    public GameObject Ground3;
    public GameObject MainCharacter;
    public GameObject PortalPrefab;

    private GameObject FlyingEyePrefab;
    private GameObject MushroomPrefab;
    private GameObject GoblinPrefab;
    public static Dictionary<GameObject, List<GameObject>> monstersByGround = new Dictionary<GameObject, List<GameObject>>();

    public static int MonsterCount = 0;

    private void Start()
    {
        FlyingEyePrefab = Resources.Load<GameObject>("Flying eye");
        MushroomPrefab = Resources.Load<GameObject>("Mushroom");
        GoblinPrefab = Resources.Load<GameObject>("Goblin");
        MainCharacter = GameObject.FindGameObjectWithTag("Player");

        monstersByGround.Add(Ground1, new List<GameObject>());
        monstersByGround.Add(Ground2, new List<GameObject>());
        monstersByGround.Add(Ground3, new List<GameObject>());

        CreateMonster();
    }

    private void DoCreate(GameObject prefab, GameObject ground)
    {
        var posY = ground.transform.position.y + 3;
        var pos = new Vector3(Random.Range(-19, 19), posY, 0);
        var monster = Instantiate(prefab, ground.transform.parent);
        monster.transform.position = pos;
        
        monstersByGround[ground].Add(monster);
    }

    private void CreateMonster()
    {
        for(int i = 0; i < 5; i++)
        {
            DoCreate(GoblinPrefab, Ground1);
            DoCreate(FlyingEyePrefab, Ground2);
            DoCreate(MushroomPrefab, Ground3);
        }
    }

    public void MonsterKilled(GameObject monster)
    {
        foreach(var ground in monstersByGround.Keys)
        {
            if (monstersByGround[ground].Contains(monster))
            {
                monstersByGround[ground].Remove(monster);

                // If there are no more monsters in this ground, spawn a portal.
                if (monstersByGround[ground].Count == 0)
                {
                    float randomOffsetX = Random.Range(5, 10);
                    Vector3 spawnPosition = MainCharacter.transform.position + new Vector3(randomOffsetX, 0, 0);
                    Instantiate(PortalPrefab, spawnPosition, Quaternion.identity);
                }
                break;
            }
        }
    }
}
