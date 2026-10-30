using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CounterInput))]
public class Counter : MonoBehaviour
{
    public static event Action OnCounterStarted;
    public static event Action OnCounterStopped;
    public static event Action OnCounterChanged;

    [SerializeField] private float _delay;

    private int _value = 0;

    private bool _isActive = false;

    private Coroutine _coroutine;

    public int Value => _value;

    private void OnEnable()
    {
        CounterInput.OnMouseClicked += StartStopCounter;
    }

    private void OnDisable()
    {
        CounterInput.OnMouseClicked += StartStopCounter;
    }

    public void StartStopCounter()
    {
        _isActive = !_isActive;

        if (_isActive)
        {
            _coroutine = StartCoroutine(StartCount(_delay));

            OnCounterStarted?.Invoke();
        }
        else
        {
            StopCoroutine(_coroutine);

            OnCounterStopped?.Invoke();
        }
    }

    public void StopCounter()
    {

    }

    private IEnumerator StartCount(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (_isActive)
        {
            yield return wait;

            _value++;

            OnCounterChanged?.Invoke();
        }
    }
}