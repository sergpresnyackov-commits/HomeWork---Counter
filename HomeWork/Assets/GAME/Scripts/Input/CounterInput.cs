using System;
using UnityEngine;

public class CounterInput : MonoBehaviour
{
    public static event Action OnMouseClicked;

    [SerializeField] private MouseEnum _startStopInput;

    private void Update()
    {
        if (Input.GetMouseButtonDown((int)_startStopInput))
        {
            OnMouseClicked?.Invoke();
        }
    }

    enum MouseEnum
    {
        leftMouseBtn,
        rightMouseBtn,
    }
}