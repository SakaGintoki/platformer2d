using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ItemShield: Item
{
    protected override Task OnPickup()
    {
        Shield shield = player.GetComponentInChildren<Shield>();
        shield.AddShield();
        return base.OnPickup();
    }
}
