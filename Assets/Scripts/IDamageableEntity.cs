using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageableEntity
{
    float Health { get;}

    void ApplyDamage(float dmg);
    void HealDamage(float dmg);
}
