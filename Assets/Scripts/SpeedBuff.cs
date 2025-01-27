using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]
public class SpeedBuff : PowerupEffect
{
    public int amount;
    
    public override void Apply(GameObject target)
    {
        target.GetComponent<Paddle>().speed = amount;
    }
}
