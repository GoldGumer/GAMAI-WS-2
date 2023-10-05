using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesirableState<T>
{
    public State<T> state;
    public float desirablitiy;
    public DesirableState(State<T> _state, float _desirability)
    {
        state = _state;
        desirablitiy = _desirability;
    }
}

public abstract class StateMachine<T>
{
    protected DesirableState<T>[] states;
    protected int currentState = 0;

    public abstract (int, int, int, int) Update(T actor);

    protected abstract void UpdateCurrentState(T actor);
}
