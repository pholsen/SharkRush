using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WaveScript : MonoBehaviour
{

    [Header("Elevator")]

    [SerializeField] private float _patrolRange;
    [SerializeField] private float _moveSpeed;

    private Vector3 _initialPosition;
    private Vector3 _minPatrolPosition;
    private Vector3 _maxPatrolPosition;
    private Vector3 _destinationPoint;

    private void Awake()
    {
        elevatorUpDownAwake();
    }

    void Start()
    {

    }

    void Update()
    {
        elevatorUpDownUpdate();
    }

    private void SetDestination(Vector3 destination)
    {
        _destinationPoint = destination;
    }

    public void elevatorUpDownUpdate()
    {
        if (Math.Abs(Vector3.Distance(transform.position, _maxPatrolPosition)) < 0.1f)
        {
            SetDestination(_minPatrolPosition);
        }
        else if (Math.Abs(Vector3.Distance(transform.position, _minPatrolPosition)) < 0.1f)
        {
            SetDestination(_maxPatrolPosition);
        }

        transform.position = Vector3.MoveTowards(transform.position, _destinationPoint, Time.deltaTime * _moveSpeed);
    }
    public void elevatorUpDownAwake()
    {
        _initialPosition = transform.position;
        _minPatrolPosition = _initialPosition + Vector3.forward * _patrolRange;
        _maxPatrolPosition = _initialPosition + Vector3.back * _patrolRange;
        SetDestination(_maxPatrolPosition);
    }

}
