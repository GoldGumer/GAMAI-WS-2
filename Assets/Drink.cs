using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : State<Miner>
{
    public override (int, int, int) Update(Miner miner)
    {
        return (1, -6, 0);
    }
}
