using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAbility : MonoBehaviour, IHasCooldown
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
        if( playerInput.Controls.Slash.triggered && !cooldownSystem.IsOnCooldown(id)){
            slashAbility(transform.eulerAngles.y);
            cooldownSystem.PutOnCooldown(this);
        }
    }

    void slashAbility(float yRotation){
        GameObject mySlash = (GameObject) Instantiate(slash, transform.position, Quaternion.identity);
        Slash slashScript = mySlash.GetComponent<Slash> ();
        slashScript.myOwner = this.gameObject;
        slashScript.myDirection = yRotation;
    }

}
