using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.cooldown;
using Ability.Slash;
using Mirror;

public class SlashAbility : NetworkBehaviour, IHasCooldown
{

    PlayerInput playerInput;
    [Header("References")]
    [SerializeField]private CooldownSystem cooldownSystem = null;

    public GameObject slash;

    [Header("CooldownManager")]
    [SerializeField] private int id = 1;
    [SerializeField] private float cooldownDuration = 5;
    public int Id => id;
    public float CooldownDuration => cooldownDuration;

    void Awake()
    {
        playerInput = new PlayerInput();
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
        if( playerInput.Controls.Slash.triggered && !cooldownSystem.IsOnCooldown(id)){
            slashAnimation(transform.rotation);
            cooldownSystem.PutOnCooldown(this);
        }
    }

    void calcHit(){
        
    }
    [Command] void slashAnimation(Quaternion _viewDirection){
        GameObject slashClone = Instantiate(slash, transform.position, _viewDirection);
        NetworkServer.Spawn(slashClone, connectionToClient);
    }

}
