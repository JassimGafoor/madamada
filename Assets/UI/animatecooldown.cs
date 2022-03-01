using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animatecooldown : MonoBehaviour, IHasCooldown
{
    public Image abilityImage;
    [SerializeField]private CooldownSystem cooldownSystem= null;

    [SerializeField] private int id = 1;
    [SerializeField] private float cooldownDuration = 5f;

    public int Id => id;
    public float CooldownDuration => cooldownDuration;

    // Start is called before the first frame update
    void Start()
    {
        abilityImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldownSystem.IsOnCooldown(id)){
            abilityImage.fillAmount = cooldownSystem.GetRemainingDuration(id)/CooldownDuration;
        }
    }



}
