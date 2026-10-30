using System;
using UnityEngine;

public class CounterInput : MonoBehaviour
{
    public event Action MouseClicked;

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
        LeftMouseBtn = 0,
        RightMouseBtn = 1,
    }
}
