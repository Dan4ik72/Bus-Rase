using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingToBusState : BusInteractionState
{
    private IMoveHandler _moveHandler;
    private float _moveSpeed = 50;

    private float _minDistanceToBusTrigger = 0.5f;

    public GoingToBusState(StateMachine stateMachine, BusEntryPointTrigger busEntryPointTrigger, Transform passengerTransform, IMoveHandler moveHandler) : base(stateMachine, busEntryPointTrigger, passengerTransform) 
    {
        _moveHandler = moveHandler;
    }

    public override void Update()
    {
        if (GetDistanceToBusTrigger() < MaxDistanceToBusTigger)
            MoveToBusTigger();
        else
            StateMachine.SetState<WaitingForBusState>();

        if (GetDistanceToBusTrigger() <= _minDistanceToBusTrigger)
            StateMachine.SetState<TakeEmptyBusCellState>();
    }

    private void MoveToBusTigger()
    {
        Vector3 direction = (BusEntryPointTrigger.transform.position - PassengerTransform.position).normalized;

        _moveHandler.Move(direction * _moveSpeed);
    }

    private float GetDistanceToBusTrigger()
    {
        return Vector3.Distance(BusEntryPointTrigger.transform.position, PassengerTransform.position);
    }
}
