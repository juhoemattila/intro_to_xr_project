using UnityEngine;
using UnityEngine.InputSystem;

public class LightController : MonoBehaviour
{
    private Light pointLight; 
    public InputActionReference changeLightAction; 

    void Start()
    {
        pointLight = GetComponent<Light>();

        changeLightAction.action.Enable();
    }

    void Update()
    {
        if (changeLightAction.action.triggered)
        {
            ChangeLightColor(Color.cyan);
        }
    }

    void ChangeLightColor(Color color)
    {
        if (pointLight != null)
        {
            pointLight.color = color;
        }
        else
        {
            Debug.LogError("Light component not found!");
        }
    }

    void OnDisable()
    {
        changeLightAction.action.Disable();
    }
}
