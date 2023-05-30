﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

public class PirateController : MonoBehaviour
{
    [SerializeField]
    public IPirateCommand activeCommand;
    
    [SerializeField]
    public GameObject productPrefab;

    // Start is called before the first frame update
    void Start()
    {
        this.activeCommand = ScriptableObject.CreateInstance<SlowWorkerPirateCommand>();
    }

    // Update is called once per frame
    void Update()
    {
        var working = this.activeCommand.Execute(this.gameObject, this.productPrefab);

        this.gameObject.GetComponent<Animator>().SetBool("Exhausted", !working);
    }

    //Has received motivation. A likely source is from on of the Captain's morale inducements.
    public void Motivate()
    {
        var rand = new System.Random();
        int workStyle = rand.Next(1,4);
        switch (workStyle)
        {
            case 1:
                this.activeCommand = Object.Instantiate(ScriptableObject.CreateInstance<SlowWorkerPirateCommand>());
                break;
            case 2:
                this.activeCommand = Object.Instantiate(ScriptableObject.CreateInstance<NormalWorkerPirateCommand>());
                break;
            case 3:
                this.activeCommand = Object.Instantiate(ScriptableObject.CreateInstance<FastWorkerPirateCommand>());
                break;
        }
        
    }
}
