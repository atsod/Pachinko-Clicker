using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PachinkoCircle : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly string _ballHitAnimationName = "ball_hit";

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball _))
        {
            _animator.Play(_ballHitAnimationName, 0, 0);
        }
    }
}
