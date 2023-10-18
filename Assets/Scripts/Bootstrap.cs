using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [Header("Currency")]
    [SerializeField] private CurrencyUI _currencyUI;

    [Header("Spawners")]
    [SerializeField] private BallSpawner _whiteBallSpawner;
    [SerializeField] private BallSpawner _yellowBallSpawner;
    [SerializeField] private BallSpawner _blueBallSpawner;

    [Header("UpgradeSystemsUI")]
    [SerializeField] private BallUpgradeSystemUI _whiteBallUpgradeSystemUI;
    [SerializeField] private BallUpgradeSystemUI _yellowBallUpgradeSystemUI;
    [SerializeField] private BallUpgradeSystemUI _blueBallUpgradeSystemUI;

    [Header("CooldownBars")]
    [SerializeField] private CooldownBarUI _whiteCooldownBarUI;
    [SerializeField] private CooldownBarUI _yellowCooldownBarUI;
    [SerializeField] private CooldownBarUI _blueCooldownBarUI;

    [Header("BallShops")]
    [SerializeField] private BallShopUI _yellowBallShopUI;
    [SerializeField] private BallShopUI _blueBallShopUI;

    private Currency _currency;

    private BallUpgradeSystem _whiteBallUpgradeSystem;
    private BallUpgradeSystem _yellowBallUpgradeSystem;
    private BallUpgradeSystem _blueBallUpgradeSystem;

    private BallShop _ballShop;

    private void Awake()
    {
        _currency = new Currency();

        _whiteBallUpgradeSystem = new (_currency, 5, 30, 1000, 3);
        _yellowBallUpgradeSystem = new (_currency, 5 * 30, 30 * 30, 1000 * 40, 5);
        _blueBallUpgradeSystem = new (_currency, 5 * 30 * 25, 30 * 30 * 25, 1000 * 40 * 25, 10);

        _ballShop = new BallShop(_currency);

        _currencyUI.Initialize(_currency);

        _whiteBallSpawner.Initialize(_whiteBallUpgradeSystem);
        _yellowBallSpawner.Initialize(_yellowBallUpgradeSystem);
        _blueBallSpawner.Initialize(_blueBallUpgradeSystem);

        _whiteBallUpgradeSystemUI.Initialize(_whiteBallUpgradeSystem, _whiteBallSpawner);
        _yellowBallUpgradeSystemUI.Initialize(_yellowBallUpgradeSystem, _yellowBallSpawner);
        _blueBallUpgradeSystemUI.Initialize(_blueBallUpgradeSystem, _blueBallSpawner);

        _whiteCooldownBarUI.Initialize();
        _yellowCooldownBarUI.Initialize();
        _blueCooldownBarUI.Initialize();

        _yellowBallShopUI.Initialize(_ballShop, false);
        _blueBallShopUI.Initialize(_ballShop, false);
    }
}
