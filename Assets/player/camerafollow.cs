using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float cameraHeight = 5f;
    public float cameraOffset = 4f;

    // Update is called once per frame

    void Update()
    {
         Vector3 pos = player.transform.position;
         pos.y += cameraHeight;
         pos.z -= cameraOffset;
         transform.position = pos;
        
    }
}
