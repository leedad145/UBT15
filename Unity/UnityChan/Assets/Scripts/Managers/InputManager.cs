using System;
using UnityEngine;

public class InputManager
{
    private Action<Define.MouseEvent> _mouseAction = null;
    public event Action<Define.MouseEvent> MouseAction
    {
        add { _mouseAction += value; }
        remove { _mouseAction -= value; }
    }
    bool _pressed;
    public void OnUpdate()
    {
        if(Input.anyKey == false)
            return;

        if(Input.GetMouseButton(0))
        {
            _mouseAction?.Invoke(Define.MouseEvent.Press);
            _pressed = true;
        }
        else
        {
            if(_pressed)
            {
                _mouseAction.Invoke(Define.MouseEvent.Click);
            }
            _pressed = false;
        }
    }
    public void Init()
    {
        _pressed = false;
    }
}
