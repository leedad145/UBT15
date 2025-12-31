using System;
using UnityEngine;
/// <summary>
/// Input events manager (non-MonoBehaviour). 호출 플로우에 따라 매 프레임 OnUpdate()를 호출해주세요.
/// </summary>
public sealed class InputManager
{
    /// <summary>구독 가능한 입력 이벤트</summary>
    public event Action<Define.InputEvent> OnInputKey;

    private bool _rPressed = false;
    private bool _lPressed = false;

    /// <summary>
    /// 매 프레임 호출해서 입력을 처리합니다.
    /// </summary>
    public void OnUpdate()
    {
        // 기본적으로 마우스 이동 알림(원래 동작 유지)
        OnInputKey?.Invoke(Define.InputEvent.MouseMove);

        // 마우스 우클릭(눌림)
        if (Input.GetMouseButton(1))
        {
            OnInputKey?.Invoke(Define.InputEvent.RPress);

            // 우클릭 중 좌클릭이 들어오면 RLClick 이벤트
            if (Input.GetMouseButtonDown(0))
            {
                OnInputKey?.Invoke(Define.InputEvent.RLClick);
            }

            _rPressed = true;
            _lPressed = false;
            return;
        }

        // 마우스 좌클릭(눌림)
        if (Input.GetMouseButton(0))
        {
            OnInputKey?.Invoke(Define.InputEvent.LClick);
            _lPressed = true;
            _rPressed = false;
            return;
        }

        // 우클릭에서 손을 뗀 경우
        if (_rPressed)
        {
            OnInputKey?.Invoke(Define.InputEvent.RUp);
            _rPressed = false;
            return;
        }

        // 좌클릭에서 손을 뗀 경우
        if (_lPressed)
        {
            OnInputKey?.Invoke(Define.InputEvent.LUp);
            _lPressed = false;
            return;
        }

        // 키 입력(마우스 입력이 없을 때)
        if (Input.anyKey)
        {
            OnInputKey?.Invoke(Define.InputEvent.KeyPress);
        }
    }

    /// <summary>
    /// 초기화용 자리(현재는 필요시 추가 로직을 넣으세요).
    /// </summary>
    public void Init()
    {
        // Optional: 초기화 로직
    }
}
