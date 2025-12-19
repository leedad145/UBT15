using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers instance;
    public static Managers Instance
    { 
        get 
        {
            if(instance == null)
            {
                GameObject go = GameObject.Find("@Managers");
                if(go == null)
                {
                    go = new GameObject{ name = "@Managers" };
                    go.AddComponent<Managers>();
                }
                DontDestroyOnLoad(go);
                instance = go.GetComponent<Managers>();
            }
            
            return instance;
        }
    }
    InputManager _input = new InputManager();
    public static InputManager Input { get {return Instance._input;}}
    // UIManager _ui = new UIManager();
    // public static UIManager UI { get {return Instance._ui;}}
    void Start()
    {
        
    }

    void Update()
    {
        _input.OnUpdate();
    }
}
