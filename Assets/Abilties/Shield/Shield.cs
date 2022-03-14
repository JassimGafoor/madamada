using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Shield : NetworkBehaviour
{
    public float duration;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = duration;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0){
            Death();
        }
    }

    public void Death(){
        NetworkServer.Destroy(gameObject);
    }
}
