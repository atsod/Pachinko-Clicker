using System;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    public static event Action<float, float> OnBallValueMultiplyed;

    [SerializeField] private int _multiplierValue;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ball ball))
        {
            OnBallValueMultiplyed?.Invoke(
                ball.GetValue(), 
                _multiplierValue);
            
            ball.OnReachTarget();
        }
    }
}
