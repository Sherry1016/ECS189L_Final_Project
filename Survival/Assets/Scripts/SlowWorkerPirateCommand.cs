using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

namespace Captain.Command
{
    public class SlowWorkerPirateCommand : ScriptableObject, IPirateCommand
    {
        private float totalWorkDuration;
        private float totalWorkDone;
        private float currentWork;
        private const float PRODUCTION_TIME = 8.0f;
        private bool exhausted = false;

        public SlowWorkerPirateCommand()
        {
            var rand = new System.Random();
            this.totalWorkDuration = 20.0f +(float)rand.NextDouble() * 40.0f;

        }

        public bool Execute(GameObject pirate, Object productPrefab)
        {
            //This function returns false when no work is done. 
            //After you implement work according to the specification and
            //generate instances of productPrefab, this function should return true.
            if (this.exhausted)
            {
                return false;
            }

            if(this.totalWorkDuration < 1.0f)
            {
                this.totalWorkDuration = 20.0f + Random.value * 40.0f;
                this.totalWorkDone = 0.0f;
                this.currentWork = 0.0f;
                return true;
            }

            this.currentWork += Time.deltaTime;
            this.totalWorkDone += Time.deltaTime;
            if (currentWork >= PRODUCTION_TIME)
            {
                var product = (GameObject)Instantiate(productPrefab, pirate.transform.position, Quaternion.identity);
                product.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.value * 7.0f, Random.value * 7.0f);
                this.currentWork = 0.0f;
            }

            if(this.totalWorkDone >= this.totalWorkDuration)
            {
                this.exhausted = true;
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}