using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ability{
public class Radar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Search();
    }

    public void Search(){
        Collider[] _colliders = Physics.OverlapSphere(transform.position, 50f);
        foreach(Collider _collider in _colliders){
            if(_collider.CompareTag("Player")){
                Debug.Log(_collider);
            }
        }
    }

}

}
