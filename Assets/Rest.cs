using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : State<Miner>
{
    public override (int, int, int) Update(Miner miner)
    {
        return (-8, 2, 2);
    }
}
