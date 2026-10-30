using UnityEngine;
using TMPro;

public class CounterUI : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [Space]
    [SerializeField] private TMP_Text _counterText;
    [SerializeField] private Color _activateColor;
    [SerializeField] private Color _stopColor;

    private void OnEnable()
    {
        _counter.CounterStarted += ActivateText;
        _counter.CounterStopped += StopText;
        _counter.CounterChanged += UpdateText;
    }

    private void OnDisable()
    {
        _counter.CounterStarted -= ActivateText;
        _counter.CounterStopped -= StopText;
        _counter.CounterChanged -= UpdateText;
    }

    private void ActivateText()
    {
        _counterText.color = _activateColor;
    }

    private void StopText()
    {
        _counterText.color = _stopColor;
    }

    private void UpdateText()
    {
        _counterText.text = _counter.Value.ToString();
    }
}