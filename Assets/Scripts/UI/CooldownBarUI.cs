using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBarUI : MonoBehaviour
{
    private Image _cooldownBar;

    private bool _isNewCooldownBar;
    
    public void Initialize()
    {
        _cooldownBar = GetComponent<Image>();
    }

    public IEnumerator ActivateCooldown(float cooldownTime)
    {
        if(cooldownTime < 0.75f && !_isNewCooldownBar)
        {
            ChangeFillBar();
            _isNewCooldownBar = true;
        }
        
        if(!_isNewCooldownBar)
        {
            float timeStep = cooldownTime / 100;
            float elapsedTime = 0f;

            _cooldownBar.fillAmount = 0;
            
            while (_cooldownBar.fillAmount < 1)
            {
                elapsedTime += Time.deltaTime / cooldownTime;
                _cooldownBar.fillAmount = Mathf.Lerp(_cooldownBar.fillAmount, elapsedTime, elapsedTime / timeStep);

                yield return null;
            }
        }
    }

    private void ChangeFillBar()
    {

    }
}
