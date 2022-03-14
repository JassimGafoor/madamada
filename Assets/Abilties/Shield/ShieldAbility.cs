using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.cooldown;
using Mirror;

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
    public bool isInvulnerable = false;

    void Awake()
    {
        playerInput = new PlayerInput();
        timer = 0f;
        transform.GetChild(1).gameObject.SetActive(false);
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
        else if(isInvulnerable == true){
            shieldDisable();
        }
        
    }

    [Command] void shieldActive(){
        
        Debug.Log("Shield activated by player");
        displayShield();
    }
    [Command] void shieldDisable(){
        hideShield();
        
    }

    [ClientRpc]void displayShield(){
        isInvulnerable = true;
        transform.GetChild(1).gameObject.SetActive(true);
    }

    [ClientRpc]void hideShield(){
        isInvulnerable = false;
        transform.GetChild(1).gameObject.SetActive(false);
    }

}
