using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerStateMachine : StateMachine<Miner>
{
    public MinerStateMachine()
    {
        states = new DesirableState<Miner>[] { new DesirableState<Miner>(new MineGold(), 7.0f), new DesirableState<Miner>(new BankGold(), 0.0f), 
            new DesirableState<Miner>(new Rest(), 0.0f), new DesirableState<Miner>(new Drink(), 0.0f), new DesirableState<Miner>(new Eat(), 0.0f) };
    }

    public override (int, int, int, int) Update(Miner miner)
    {
        UpdateCurrentState(miner);
        (int, int, int) ints = states[currentState].state.Update(miner);
        return (ints.Item1, ints.Item2, ints.Item3, currentState);
    }

    protected override void UpdateCurrentState(Miner miner)
    {
        int[] allStats = miner.GetAllStats();
        states[1].desirablitiy = allStats[0];
        states[2].desirablitiy = allStats[2];
        states[3].desirablitiy = allStats[3];
        states[4].desirablitiy = allStats[4];
        for (int i = 0; i < states.Length; i++)
        {
            if (states[i].desirablitiy > states[currentState].desirablitiy) currentState = i;
        }
            
    }
}
