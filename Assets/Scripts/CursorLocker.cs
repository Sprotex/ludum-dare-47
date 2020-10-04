using UnityEngine;
using UnityEngine.UI;

public class CursorLocker : MonoBehaviour
{
    public GraphicRaycaster screenMouseCatcher;

    private void Start() => Cursor.lockState = CursorLockMode.Locked;

    private void Update()
    {
        var isSwitchingLockState = Input.GetButtonDown("Access PC");
        if (isSwitchingLockState)
            Cursor.lockState = (Cursor.lockState == CursorLockMode.Confined) ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void Unlock()
    {
        Cursor.lockState = CursorLockMode.None;
        gameObject.SetActive(false);
        screenMouseCatcher.enabled = true;
    }

    public void Lock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(true);
        screenMouseCatcher.enabled = false;
    }
}
