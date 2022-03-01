using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerAbility : MonoBehaviour, IHasCooldown
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
        if( playerInput.Controls.Dagger.triggered && !cooldownSystem.IsOnCooldown(id)){
            daggerAbility();
            cooldownSystem.PutOnCooldown(this);
        }
    }

    void daggerAbility(){
        GameObject myDagger = (GameObject) Instantiate(dagger, transform.position, Quaternion.identity);
        Dagger daggerScript = myDagger.GetComponent<Dagger> ();
        daggerScript.myOwner = this.gameObject;
        daggerScript.target = enemy.gameObject;
    }
}
