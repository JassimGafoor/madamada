using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Ability.Dagger{

public class Dagger : NetworkBehaviour
{

    public GameObject myOwner;
    public GameObject target;
    public float duration;
    public float speed = 3.0f;

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
    
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed );
        
        transform.LookAt(target.transform.position, Vector3.up);


        if (timer <= 0){
            Death();
        }
    }

    public void Death(){
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider target){
        if(target.tag == "Enemy"){
            Death();
            Debug.Log("destroyed");
            //GameManager.EnemyKilled();
        }
        else if(target.tag == "Shield"){
            Death();
            Debug.Log("shieldhit no damage");
        }
    }
}
}