using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Scripts.cooldown;


public class animatecooldown : MonoBehaviour, IHasCooldown
{
    public Image abilityImage;
    public CooldownSystem cooldownSystem;

    [SerializeField] private int id = 1;
    [SerializeField] private float cooldownDuration = 5f;

    public int Id => id;
    public float CooldownDuration => cooldownDuration;

    // Start is called before the first frame update
    void Start()
    {
        if(cooldownSystem == null){
            abilityImage.fillAmount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldownSystem == null){
            

        }
        else{
                if(cooldownSystem.IsOnCooldown(id)){
                    abilityImage.fillAmount = cooldownSystem.GetRemainingDuration(id)/CooldownDuration;
                }
                else{
                    abilityImage.fillAmount = 0;
                }
        }
    }



}
