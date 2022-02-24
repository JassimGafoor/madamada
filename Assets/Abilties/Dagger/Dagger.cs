using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
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
        
        if (timer <= 0){
            Death();
        }else if(transform.position == target.transform.position){
            Death();
        }
    }

    public void Death(){
        Destroy(gameObject);
    }
}