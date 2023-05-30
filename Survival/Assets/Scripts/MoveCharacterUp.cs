using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

/*
    This MoveCharacterUp class will make the captain perform the jumping movement. 
    Use the up key in the keyboard to make the jump. If you want to jump higher, 
    just press the up key two more times, the more you press the higher you jump.
*/

namespace Captain.Command
{
    public class MoveCharacterUp : ScriptableObject, ICaptainCommand
    {
        private float height = 5.0f;

        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, height);
            }
        }
    }
}