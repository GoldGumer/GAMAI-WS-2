using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankGold : State<Miner>
{
    public override (int,int,int) Update(Miner miner)
    {
        miner.BankGold();
        return (2, 2, 2);
    }
}
