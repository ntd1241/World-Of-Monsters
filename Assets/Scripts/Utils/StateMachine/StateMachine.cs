using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public class StateMachine : MonoBehaviour
{
    [SerializedDictionary("State Name", "State")]
    public SerializedDictionary<string, State> initStates = new(); //Dict<Name,State>
    Dictionary<string, State> instanceStates = new Dictionary<string, State>();
    State curState;
    [SerializeField]
    protected string currentStateName;

    protected virtual void Awake()
    {
        foreach (var stateName in initStates.Keys)
        {
            instanceStates[stateName] = Instantiate(initStates[stateName]);
            instanceStates[stateName].machine = this;
            instanceStates[stateName].Initialize();
        }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        SwitchState(currentStateName);

        //Start current state (if exist)
        curState?.Enter();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        curState?.Update();
    }

    protected virtual void FixedUpdate()
    {
        curState?.FixedUpdate();
    }

    bool SwitchState(string stateName)
    {
        State state = instanceStates[stateName];
        if (state == null) return false;

        curState?.Exit();
        curState = state;
        curState.Enter();

        return true;
    }
}
