using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineGold : State<Miner>
{
    public override (int,int,int) Update(Miner miner)
    {
        miner.AddGold(2);
        return (4, 3, 5);
    }
}
