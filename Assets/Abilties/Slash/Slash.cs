using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Ability.Slash{
    public class Slash : NetworkBehaviour
    {
        public float force = 50f;
        public Rigidbody rigidBody;
        float duration = 2f;

        public override void OnStartServer(){
            Invoke(nameof(DestroySelf), duration);
        }
        void Update(){
            rigidBody.AddForce(transform.forward * force);
        }


        [Server] void DestroySelf()
        {
            NetworkServer.Destroy(gameObject);
        }

    }
}
