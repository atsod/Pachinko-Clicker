using TMPro;
using UnityEngine;

public class BallUpgradeSystemUI : MonoBehaviour
{
    #region fields
    
    [SerializeField] private TextMeshProUGUI _spawnTimeText;
    [SerializeField] private TextMeshProUGUI _ballAmountText;
    [SerializeField] private TextMeshProUGUI _autoClickerText;

    [SerializeField] private TextMeshProUGUI _spawnTimePriceText;
    [SerializeField] private TextMeshProUGUI _ballAmountPriceText;
    [SerializeField] private TextMeshProUGUI _autoClickerPriceText;

    private const string MAX_UPGRADE = "Макс";

    private BallUpgradeSystem _upgradeSystem;
    private BallSpawner _ballSpawner;

    #endregion

    #region initializer

    public void Initialize(BallUpgradeSystem upgradeSystem, BallSpawner ballSpawner)
    {
        _upgradeSystem = upgradeSystem;
        _ballSpawner = ballSpawner;

        UpgradeTimeCore();
        UpgradeBallAmountCore();
        BuyAutoClickerCore();
    }

    #endregion

    #region public methods

    public void UpgradeTime()
    {
        _upgradeSystem.UpgradeTime(out bool isUpgraded);

        if(isUpgraded)
        {
            UpgradeTimeCore();
        }
    }

    public void UpgradeBallAmount()
    {
        _upgradeSystem.UpgradeBallAmount(out bool isUpgraded);

        if (isUpgraded)
        {
            UpgradeBallAmountCore();
        }
    }
    
    public void BuyAutoClicker()
    {
        _upgradeSystem.BuyAutoClicker(out bool isUpgraded);

        if (isUpgraded)
        {
            BuyAutoClickerCore();
        }
    }

    #endregion

    #region private methods

    private void UpgradeTimeCore()
    {
        _spawnTimeText.text = string.Format("{0:0.00} сек", _upgradeSystem.SpawnTime);
        if (_upgradeSystem.SpawnTime <= BallUpgradeSystem.MAX_TIME_VALUE)
        {
            _spawnTimePriceText.text = MAX_UPGRADE;
            return;
        }
        TextFormatter.FormatCurrencyValueText(_spawnTimePriceText, _upgradeSystem.SpawnTimePrice);
    }

    private void UpgradeBallAmountCore()
    {
        _ballAmountText.text = $"Кол-во шаров: {_upgradeSystem.BallAmount}";
        if (_upgradeSystem.BallAmount >= BallUpgradeSystem.MAX_BALL_AMOUNT)
        {
            _ballAmountPriceText.text = MAX_UPGRADE;
            return;
        }
        TextFormatter.FormatCurrencyValueText(_ballAmountPriceText, _upgradeSystem.BallAmountPrice);
    }

    private void BuyAutoClickerCore()
    {
        if(_upgradeSystem.IsAutoClickerBought)
        {
            _autoClickerText.text = $"Автокликер вкл.";
            _autoClickerPriceText.text = MAX_UPGRADE;
            _ballSpawner.SpawnBall();
        }
        else
        {
            _autoClickerText.text = $"Автокликер выкл.";
            TextFormatter.FormatCurrencyValueText(_autoClickerPriceText, _upgradeSystem.AutoClickerPrice);
        }
    }

    #endregion
}
