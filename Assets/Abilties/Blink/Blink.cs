using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Blink : MonoBehaviour
{
    
    private PlayerInput playerInput;

    CharacterController cc;

    public float distance;
    Vector3 destination;
    bool blinking = false;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInput.Controls.Blink.triggered){   
        calcDistance();
        blinking = true;
        cc.enabled = false; //turn off character contorlelr so you can blink
        }
        else if(blinking){
            
            transform.position = destination;
            blinking = false;
            cc.enabled = true;
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
