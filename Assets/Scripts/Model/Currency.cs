using System;

[Serializable]
public class Currency
{
    public static event Action<float> OnValueChanged;

    private float _currencyValue = 10200;
    public float CurrencyValue => _currencyValue;

    public void CalculateProfit(float ballValue, float multiplyerValue)
    {
        _currencyValue += (ballValue * multiplyerValue);
        
        OnValueChanged?.Invoke(_currencyValue);
    }

    public void CalculateCosts(float costsValue)
    {
        _currencyValue -= costsValue;
        OnValueChanged?.Invoke(_currencyValue);
    }
}
