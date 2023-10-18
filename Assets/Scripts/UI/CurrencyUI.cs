using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currencyValueText;

    private Currency _currency;

    public void Initialize(Currency currency)
    {
        _currency = currency;

        ChangeCurrencyValueText(_currency.CurrencyValue);
    }

    private void OnEnable()
    {
        Multiplier.OnBallValueMultiplyed += CalculateProfit;
        Currency.OnValueChanged += ChangeCurrencyValueText;
    }

    private void OnDisable()
    {
        Multiplier.OnBallValueMultiplyed -= CalculateProfit;
        Currency.OnValueChanged -= ChangeCurrencyValueText;
    }

    private void CalculateProfit(float ballValue, float multiplyerValue)
    {
        _currency.CalculateProfit(ballValue, multiplyerValue);
    }

    private void ChangeCurrencyValueText(float currencyValue)
    {
        TextFormatter.FormatCurrencyValueText(_currencyValueText, currencyValue);
    }
}
