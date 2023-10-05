using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : State<Miner>
{
    public override (int, int, int) Update(Miner miner)
    {
        return (1, 2, -7);
    }
}
