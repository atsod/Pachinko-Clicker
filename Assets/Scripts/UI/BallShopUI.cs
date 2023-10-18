using UnityEngine;

public class BallShopUI : MonoBehaviour
{
    [SerializeField] private GameObject _ballContainer;

    private BallShop _ballShop;

    public void Initialize(BallShop ballShop, bool isBallBought)
    {
        _ballShop = ballShop;

        if(isBallBought)
        {
            BuyBallCore();
        }
    }

    public void BuyBall(float ballPrice)
    {
        _ballShop.BuyBall(ballPrice, out bool isSuccess);
        
        if(isSuccess)
        {
            BuyBallCore();
        }
    }

    private void BuyBallCore()
    {
        _ballContainer.SetActive(true);
        gameObject.SetActive(false);
    }
}
