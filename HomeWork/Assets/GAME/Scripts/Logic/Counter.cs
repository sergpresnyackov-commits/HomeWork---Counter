using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CounterInput))]
public class Counter : MonoBehaviour
{
    public event Action CounterStarted;
    public event Action CounterStopped;
    public event Action CounterChanged;

    [SerializeField] private float _delay;

    private int _value = 0;
    private bool _isActive = false;

    private Coroutine _coroutine;
    private CounterInput _counterInput;

    public int Value => _value;

    private void OnEnable()
    {
        _counterInput.MouseClicked += StartStopCounter;
    }

    private void OnDisable()
    {
        _counterInput.MouseClicked += StartStopCounter;
    }

    private void Awake()
    {
        _counterInput = GetComponent<CounterInput>();
    }

    public void StartStopCounter()
    {
        _isActive = !_isActive;

        if (_isActive)
        {
            _coroutine = StartCoroutine(StartCount(_delay));

            CounterStarted?.Invoke();
        }
        else
        {
            StopCoroutine(_coroutine);

            CounterStopped?.Invoke();
        }
    }

    private IEnumerator StartCount(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (_isActive)
        {
            yield return wait;

            _value++;

            CounterChanged?.Invoke();
        }
    }
}
