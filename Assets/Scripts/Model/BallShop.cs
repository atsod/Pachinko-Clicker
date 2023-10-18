
public class BallShop
{
    private Currency _currency;

    public BallShop(Currency currency)
    {
        _currency = currency;
    }

    public void BuyBall(float ballPrice, out bool isSuccess)
    {
        if(_currency.CurrencyValue >= ballPrice)
        {
            _currency.CalculateCosts(ballPrice);
            isSuccess = true;
        }
        else
        {
            isSuccess = false;
        }
    }
}
