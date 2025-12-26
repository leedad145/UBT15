using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{                       //Invoke C# Events 방식으로 수정하기
    Action<Define.InputEvent> _onInputKey;
    public event Action<Define.InputEvent> OnInputKey
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
    bool _Rpress = false;
    bool _Lpress = false;
    public void OnUpdate()
    {
        _onInputKey?.Invoke(Define.InputEvent.MouseMove);
        #region Mouse
        if(Input.GetMouseButton(1))
        {
            _onInputKey?.Invoke(Define.InputEvent.RPress);
            if(Input.GetMouseButtonDown(0))
            {
                _onInputKey?.Invoke(Define.InputEvent.RLClick);
            }
            _Rpress = true;
        }
        else if(Input.GetMouseButton(0))
        {
            _onInputKey?.Invoke(Define.InputEvent.LClick);
            _Lpress = true;
        }
        else if(_Rpress)
        {
            _onInputKey?.Invoke(Define.InputEvent.RUp);
            _Rpress = false;
        }
        else if(_Lpress)
        {
            _onInputKey?.Invoke(Define.InputEvent.LUp);
            _Lpress = false;
        }
        #endregion Mouse
        #region Keyboard
        else 
        {
            if(Input.anyKey)
            {
                _onInputKey?.Invoke(Define.InputEvent.KeyPress);
            }
        }
        #endregion Keyboard
    }
    public void Init()
    {
        
    }
}
