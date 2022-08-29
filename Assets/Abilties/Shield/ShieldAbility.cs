using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.cooldown;
using Mirror;
using Ability;
public class ShieldAbility : NetworkBehaviour, IHasCooldown
{

    PlayerInput playerInput;
    [Header("References")]
    [SerializeField]private CooldownSystem cooldownSystem = null;

    
    [Header("CooldownManager")]
    [SerializeField] private int id = 3;
    [SerializeField] private float cooldownDuration = 5f;
    public int Id => id;
    public float CooldownDuration => cooldownDuration;
    public float AbilityDuration = 2f;
    float timer;

    PlayerState playerState;
    

    void Awake()
    {
        playerInput = new PlayerInput();
        timer = 0f;
        transform.GetChild(1).gameObject.SetActive(false);
        playerState =  GetComponent<PlayerState>();
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
            if( playerInput.Controls.Shield.triggered && !cooldownSystem.IsOnCooldown(id)){
                shieldActive();
                timer = AbilityDuration;
                cooldownSystem.PutOnCooldown(this);
            }
        if(timer >= 0f){
            timer -= Time.deltaTime;
        }
        else if(playerState.isInvulnerable == true){
            shieldDisable();
        }
        
    }

    [Command] void shieldActive(){
        playerState.isInvulnerable = true;
        displayShield();
    }
    [Command] void shieldDisable(){
        hideShield();
        playerState.isInvulnerable = false;
    }

    [ClientRpc]void displayShield(){
        
        transform.GetChild(1).gameObject.SetActive(true);
    }

    [ClientRpc]void hideShield(){
        
        transform.GetChild(1).gameObject.SetActive(false);
    }

    

}
