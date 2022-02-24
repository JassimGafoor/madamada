using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public GameObject myOwner;
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

        transform.position = myOwner.transform.position;

        if (timer <= 0){
            Death();
        }
    }

    public void Death(){
        Destroy(gameObject);
    }
}
