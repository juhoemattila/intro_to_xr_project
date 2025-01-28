using UnityEngine;

public class Quit : MonoBehaviour
{
    public UnityEngine.InputSystem.InputActionReference action;
    
    void Start()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        };
    }
}
