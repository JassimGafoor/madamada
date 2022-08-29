using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Scripts.cooldown;
public class PlayerState : NetworkBehaviour
{
    //Animator and other stuff
    [SyncVar]
    public bool isInvulnerable = false;
    // Start is called before the first frame update
    [SyncVar]
    public bool isDead = false;
    public GameObject canvas;
    public void playerAlive(){
        isDead = false;
    }
    public void playerDead(){
        isDead = true;
    }

    void Start(){
        if(isLocalPlayer){
            canvas = GameObject.Find("slashM");
            Debug.Log(canvas);
            canvas.GetComponent<animatecooldown>().cooldownSystem = this.gameObject.GetComponent<CooldownSystem>();
            //canvas.animatecooldown.cooldownSystem = this.;
        }
    }
}
