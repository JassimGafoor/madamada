using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float scoreKills;

    
    void Start()
    {
        scoreKills = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void EnemyKilled(){
        Debug.Log("EnemyKilled");
    }

}
