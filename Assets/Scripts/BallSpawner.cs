using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private CooldownBarUI _cooldownBar;

    private const int BALL_PRELOAD_COUNT = 10;

    private BallUpgradeSystem _ballUpgradeSystem;

    private PoolBase<Ball> _ballPool;

    private Vector3 _ballSpawnPosition;
    
    private bool _isCooldownOver;

    public void Initialize(BallUpgradeSystem ballUpgradeSystem)
    {
        _ballUpgradeSystem = ballUpgradeSystem;

        _ballSpawnPosition = new Vector3(4.55f, 3.3f, 0f);

        _isCooldownOver = true;

        _ballPool = new PoolBase<Ball>(Preload, GetAction, ReturnAction, BALL_PRELOAD_COUNT);
    }

    private void Start()
    {
        if(_ballUpgradeSystem.IsAutoClickerBought)
        {
            SpawnBall();
        }
    }

    public void SpawnBall()
    {
        StartCoroutine(SpawnBallWithCooldown(_ballUpgradeSystem.SpawnTime));
    }

    private IEnumerator SpawnBallWithCooldown(float cooldownTime)
    {
        if (_isCooldownOver)
        {
            _isCooldownOver = false;

            for (int i = 0; i < _ballUpgradeSystem.BallAmount; i++)
            {
                Ball ball = _ballPool.Get();

                ball.GetComponent<Rigidbody2D>().AddForce(
                    GenerateRandomImpulseDirection(),
                    ForceMode2D.Impulse);

                ball.OnReachMultiplyer(OnReachTarget);

                void OnReachTarget() => _ballPool.Return(ball);
            }

            IEnumerator cooldownCoroutine = _cooldownBar.ActivateCooldown(_ballUpgradeSystem.SpawnTime);
            StartCoroutine(cooldownCoroutine);

            yield return new WaitForSeconds(cooldownTime);

            StopCoroutine(cooldownCoroutine);

            _isCooldownOver = true;

            if(_ballUpgradeSystem.IsAutoClickerBought)
            {
                SpawnBall();
            }
        }
    }

    private Vector2 GenerateRandomImpulseDirection()
    {
        Vector2 impulseDirection = new (
            Random.Range(-200, 200) / 100f,
            0f);

        if(impulseDirection.Equals(Vector2.zero))
        {
            impulseDirection = GenerateRandomImpulseDirection();
        }

        return impulseDirection;
    }

    public Ball Preload()
    {
        return Instantiate(_ballPrefab, _ballSpawnPosition, Quaternion.identity);
    }

    public void GetAction(Ball ball)
    {
        ball.gameObject.SetActive(true);
    }
    
    public void ReturnAction(Ball ball)
    {
        ball.gameObject.SetActive(false);
        ball.transform.position = _ballSpawnPosition;
    }
}
