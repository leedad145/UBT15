using System;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class InputManager
{
    private Action _keyAction = null;
    public event Action KeyAction
    {
        add { _keyAction += value; }
        remove { _keyAction -= value; }
    }
    public void OnUpdate()
    {
        if(Input.anyKey == false)
            return;

        // if(KeyAction != null)
        //     KeyAction.Invoke();
        _keyAction?.Invoke();
        
    }
}
