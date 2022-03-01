using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasCooldown
{
    // Start is called before the first frame update
    int Id {get;}
    float CooldownDuration {get;}
}
