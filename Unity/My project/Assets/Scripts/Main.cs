using UnityEngine;

public enum Step
{
    Step1_Countdown,
    Step2_Wait,
    Step3_WaitSpace,
}
public class Main : MonoBehaviour
{

    Step _step = Step.Step1_Countdown;
    void Start()
    {
        
    }

    int _counter = 5;
    float _sumTime = 1;
    void Update()
    {
        if (_step == Step.Step1_Countdown)
        {
            _sumTime += Time.deltaTime;
            if (_sumTime >= 1)
            {
                Debug.Log(_counter);
                _counter--;
                _sumTime = 0;
                if (_counter == 0)
                {
                    _step = Step.Step2_Wait;
                }
            }

        }
        else if (_step == Step.Step2_Wait)
        {
            _sumTime += Time.deltaTime;
            if (_sumTime >= 3)
            {
                _step = Step.Step3_WaitSpace;
            }
        }
        else if (_step == Step.Step3_WaitSpace)
        {
            
        }
    }
}
