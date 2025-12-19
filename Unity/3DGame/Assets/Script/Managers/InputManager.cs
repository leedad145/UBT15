using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Action _onInputKey;
    public event Action OnInputKey
    {
        add 
        { 
            _onInputKey += value;
        }
        remove 
        { 
            _onInputKey -= value;
        }
    }
    void Update()
    {
        _onInputKey?.Invoke();
    }
    public void Init()
    {
        
    }
}
