using System;

[Serializable]
public class BallUpgradeSystem
{
    #region fields

    private const float TIME_PRICE_MODIFICATOR = 1.2f;
    private const float TIME_VALUE = 0.06f;
    private const float BALL_AMOUNT_PRICE_MODIFICATOR = 2.5f;
    private const int BALL_AMOUNT_VALUE = 1;

    public static readonly float MAX_TIME_VALUE = 0.1f;
    public static readonly float MAX_BALL_AMOUNT = 10f;

    private Currency _currency;

    private float _spawnTimePrice;
    public float SpawnTimePrice => _spawnTimePrice;
    private float _ballAmountPrice;
    public float BallAmountPrice => _ballAmountPrice;
    private float _autoClickerPrice;
    public float AutoClickerPrice => _autoClickerPrice;

    private float _spawnTime;
    public float SpawnTime => _spawnTime;
    private int _ballAmount;
    public int BallAmount => _ballAmount;
    private bool _isAutoClickerBought;
    public bool IsAutoClickerBought => _isAutoClickerBought;

    #endregion

    #region constructor

    public BallUpgradeSystem(Currency currency,
        float spawnTimePrice, float ballAmountPrice, float autoClickerPrice, 
        float spawnTime, int ballAmount = 1, bool isAutoClickerBought = false)
    {
        _currency = currency;

        _spawnTimePrice = spawnTimePrice;
        _ballAmountPrice = ballAmountPrice;
        _autoClickerPrice = autoClickerPrice;

        _spawnTime = spawnTime;
        _ballAmount = ballAmount;
        _isAutoClickerBought = isAutoClickerBought;
    }

    #endregion

    #region public methods

    public void UpgradeTime(out bool isUpgraded)
    {
        if (_spawnTime <= MAX_TIME_VALUE)
        {
            isUpgraded = false;
            return;
        }

        if (_currency.CurrencyValue >= _spawnTimePrice)
        {
            _currency.CalculateCosts(_spawnTimePrice);
            _spawnTimePrice *= TIME_PRICE_MODIFICATOR;
            _spawnTime -= TIME_VALUE;

            isUpgraded = true;
        }
        else
        {
            isUpgraded = false;
        }
    }

    public void UpgradeBallAmount(out bool isUpgraded)
    {
        if(_ballAmount >= MAX_BALL_AMOUNT)
        {
            isUpgraded = false;
            return;
        }

        if (_currency.CurrencyValue >= _ballAmountPrice)
        {
            _currency.CalculateCosts(_ballAmountPrice);
            _ballAmountPrice *= BALL_AMOUNT_PRICE_MODIFICATOR;
            _ballAmount += BALL_AMOUNT_VALUE;

            isUpgraded = true;
        }
        else
        {
            isUpgraded = false;
        }
    }

    public void BuyAutoClicker(out bool isUpgraded)
    {
        if (_currency.CurrencyValue >= _autoClickerPrice && !_isAutoClickerBought)
        {
            _currency.CalculateCosts(_autoClickerPrice);
            _isAutoClickerBought = true;

            isUpgraded = true;
        }
        else
        {
            isUpgraded = false;
        }
    }

    #endregion
}
