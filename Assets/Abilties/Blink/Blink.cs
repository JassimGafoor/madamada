using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Blink : MonoBehaviour, IHasCooldown
{
    [Header("References")]
    private PlayerInput playerInput;
    [SerializeField]private CooldownSystem cooldownSystem= null;

    CharacterController cc;

    public float distance;
    Vector3 destination;

    [Header("CooldownManager")]
    [SerializeField] private int id = 4;
    [SerializeField] private float cooldownDuration = 5;
    public int Id => id;
    public float CooldownDuration => cooldownDuration;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInput.Controls.Blink.triggered && !cooldownSystem.IsOnCooldown(id)){   
        calcDistance();
        cooldownSystem.PutOnCooldown(this);
        cc.enabled = false; //turn off character contorlelr so you can blink
        transform.position = destination;
        cc.enabled = true;
        Debug.Log("blink used");
        }
    }

    void calcDistance(){
        RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, distance + 0.5f)){
                float dist = Vector3.Distance(transform.position, hit.point);
                Debug.Log(hit.distance);
                Debug.DrawLine(transform.position, hit.point, Color.red, 2f);
                if(hit.distance < 0.25f){
                    destination = transform.position;
                }
                else if(hit.distance > 2f){
                    destination = transform.position + transform.forward*distance;
                }
                else{
                    destination = transform.position + transform.forward * (hit.distance - 0.25f);
                }
            }
            else{
                destination = transform.position + transform.forward*distance;
                float dist2 = Vector3.Distance(transform.position, destination);
                Debug.Log(dist2);

            }
    }
    void OnEnable(){
        playerInput.Controls.Enable();
    }
    void OnDisable(){
        playerInput.Controls.Disable();
    }
}
