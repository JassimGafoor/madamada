using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.cooldown;


public class ShieldAbility : MonoBehaviour, IHasCooldown
{

    PlayerInput playerInput;
    [Header("References")]
    [SerializeField]private CooldownSystem cooldownSystem = null;

    public GameObject shield;
    [Header("CooldownManager")]
    [SerializeField] private int id = 3;
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
        if( playerInput.Controls.Shield.triggered && !cooldownSystem.IsOnCooldown(id)){
            shieldAbility();
            cooldownSystem.PutOnCooldown(this);
        }
    }

    void shieldAbility(){
        GameObject myShield = (GameObject) Instantiate(shield, transform.position, Quaternion.identity);
        Shield shieldScript = myShield.GetComponent<Shield> ();
        shieldScript.myOwner = this.gameObject;
    }

}
