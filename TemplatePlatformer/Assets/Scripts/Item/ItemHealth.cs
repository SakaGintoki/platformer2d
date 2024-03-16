using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class ItemHealth : Item
{
    protected override Task OnPickup()
    {
        player.GetComponent<Health>().generateHealth();
        return base.OnPickup();
    }
}
