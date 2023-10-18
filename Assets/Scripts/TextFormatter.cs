using TMPro;

public static class TextFormatter
{
    public static void FormatCurrencyValueText(TextMeshProUGUI currencyText, float currencyValue)
    {
        if (currencyValue < 1000)
        {
            currencyText.text = string.Format("${0:0}", currencyValue);
        }
        else if (currencyValue < 1000000)
        {
            float bigValue = currencyValue / 1000;
            currencyText.text = string.Format("${0:0.00}κ", bigValue);
        }
        else
        {
            float extraBigValue = currencyValue / 1000000;
            currencyText.text = string.Format("${0:0.00}κκ", extraBigValue);
        }
    }
}
