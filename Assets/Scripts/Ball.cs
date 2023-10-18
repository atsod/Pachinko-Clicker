using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] private int _value;

    public Action OnReachTarget;

    public int GetValue()
    {
        return _value;
    }

    public void OnReachMultiplyer(Action OnReachTarget)
    {
        this.OnReachTarget = OnReachTarget;
    }
}
