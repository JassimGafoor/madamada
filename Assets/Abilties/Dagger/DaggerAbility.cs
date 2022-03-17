using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.cooldown;
using Ability.Dagger;
using Mirror;
public class DaggerAbility : NetworkBehaviour, IHasCooldown
{
    // Start is called before the first frame update
    PlayerInput playerInput;
    [Header("References")]
    [SerializeField]private CooldownSystem cooldownSystem = null;

    public GameObject dagger;
    public GameObject enemy;
    [Header("CooldownManager")]
    [SerializeField] private int id = 2;
    [SerializeField] private float cooldownDuration = 5;
    public int Id => id;
    public float CooldownDuration => cooldownDuration;

    void Awake()
    {
        playerInput = new PlayerInput();
        enemy = GameObject.Find("Cube (2)");
    }
    void OnEnable()
    {
        playerInput.Controls.Enable();
    }

    void OnDisable()
    {
        playerInput.Controls.Disable();
    }

    void Update(){
        if(!isLocalPlayer){
            return;
        }

        if( playerInput.Controls.Dagger.triggered && !cooldownSystem.IsOnCooldown(id)){
            daggerAbility();
            cooldownSystem.PutOnCooldown(this);
        }
    }

    [Command] void daggerAbility(){
        GameObject myDagger = (GameObject) Instantiate(dagger, transform.position, Quaternion.identity);
        Dagger daggerScript = myDagger.GetComponent<Dagger> ();
        daggerScript.myOwner = this.gameObject; 
        daggerScript.target = enemy.gameObject;
        NetworkServer.Spawn(myDagger, connectionToClient);
    }
}
