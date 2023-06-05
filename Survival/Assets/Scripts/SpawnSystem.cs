using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject Ground1;
    public GameObject Ground2;
    public GameObject Ground3;

    private GameObject FlyingEyePrefab;
    private GameObject MushroomPrefab;
    private GameObject GoblinPrefab;

    private void Start()
    {
        FlyingEyePrefab = Resources.Load<GameObject>("Flying eye");
        MushroomPrefab = Resources.Load<GameObject>("Mushroom");
        GoblinPrefab = Resources.Load<GameObject>("Goblin");
        CreateMonster();
    }

    private void DoCreate(GameObject prefab, GameObject ground)
    {
        var posY = ground.transform.position.y + 3;
        var pos = new Vector3(Random.Range(-19, 19), posY, 0);
        var monster = Instantiate(prefab, ground.transform.parent);
        monster.transform.position = pos;
    }

    private void CreateMonster()
    {
        for(int i = 0; i < 3; i++)
        {
            DoCreate(GoblinPrefab, Ground1);
            DoCreate(FlyingEyePrefab, Ground2);
            DoCreate(MushroomPrefab, Ground3);
        }

    }
}
