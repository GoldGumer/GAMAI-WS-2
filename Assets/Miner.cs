using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Miner : MonoBehaviour
{
    float time = 0;

    [SerializeField] int goldCarried;
    [SerializeField] int bankedGold;
    [SerializeField] int tiredness;
    [SerializeField] int thirstiness;
    [SerializeField] int hunger;
    
    MinerStateMachine stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new MinerStateMachine();
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 2.0f) 
        { 
            (int, int, int, int) statUpdate = stateMachine.Update(gameObject.GetComponent<Miner>()); 
            time = 0.0f;

            tiredness += statUpdate.Item1;
            thirstiness += statUpdate.Item2;
            hunger += statUpdate.Item3;
            switch (statUpdate.Item4)
            {
                case 0:
                    Debug.Log("Mining Gold. Gold Carried: " + goldCarried);
                    break;
                case 1:
                    Debug.Log("Banking Gold. Banked Gold Amount: " + bankedGold);
                    break;
                case 2:
                    Debug.Log("Sleeping. Tiredness: " + tiredness);
                    break;
                case 3:
                    Debug.Log("Drinking. Thirstiness: " + thirstiness);
                    break;
                case 4:
                    Debug.Log("Eating. Hunger: " + hunger);
                    break;
                default:
                    Debug.Log("No Report for this state");
                    break;
            }
        }
        time += Time.deltaTime;
    }

    public void AddGold(int amount) { goldCarried += amount; }
    public void RemoveGold(int amount) {  goldCarried -= amount; }

    public void BankGold() 
    { 
        bankedGold += goldCarried;
        goldCarried = 0;
    }

    public int GetStat(string statName)
    {
        switch (statName)
        {
            case "goldCarried":
                return goldCarried;

            case "bankedGold":
                return bankedGold;

            case "tiredness":
                return tiredness;

            case "thirstiness":
                return thirstiness;

            case "hunger":
                return hunger;

            default:
                return 0;
        }
    }

    public int[] GetAllStats() 
    {
        return new int[] {goldCarried, bankedGold, tiredness, thirstiness, hunger};
    }
}
