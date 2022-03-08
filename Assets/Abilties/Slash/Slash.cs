using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ability.Slash{
public class Slash : MonoBehaviour
{

    public GameObject myOwner;
    
    public float duration = 0.6f;
    public float speed = 7.0f;
    
    public float myDirection;


    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0,myDirection,0,Space.Self);
        
    }

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;

        
        transform.Translate(Vector3.forward *Time.deltaTime * speed);

        if (duration <= 0){
            Death();
        }
        

        
    }

    public void Death(){
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider target){
        Debug.Log("hit registerd");
    }
}
}
