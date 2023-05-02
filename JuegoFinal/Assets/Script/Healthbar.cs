using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _timeToDrain = 0.25f;
    private Image _image;

    private float _target;
    private float _currentHealth;

    private Coroutine drainHealthBarCoroutine;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth, float damageAmount)
    {
        _currentHealth = currentHealth - damageAmount;
        _target = _currentHealth / maxHealth;

        drainHealthBarCoroutine = StartCoroutine(DrainHealthBar());
    }

    private IEnumerator DrainHealthBar()
    {
        float fillAmount = _image.fillAmount;

        float elapsedTime = 0f;
        while (elapsedTime < _timeToDrain)
        {
            elapsedTime += Time.deltaTime;

            _image.fillAmount = Mathf.Lerp(fillAmount, _target, (elapsedTime / _timeToDrain));

            yield return null;
        }
    }
}
