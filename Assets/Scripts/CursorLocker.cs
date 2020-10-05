using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class CursorLocker : MonoBehaviour
{
    public GraphicRaycaster screenMouseCatcher;
    public GameObject settingsPanel;
    public CinemachineVirtualCamera lockedCamera;
    public CinemachineVirtualCamera realCamera;

    private void Start() => Lock();

    private void Update()
    {
        var isSwitchingLockState = Input.GetButtonDown("Access PC");
        if (isSwitchingLockState)
            Cursor.lockState = (Cursor.lockState == CursorLockMode.Confined) ? CursorLockMode.None : CursorLockMode.Locked;
        if (Input.GetKeyDown(KeyCode.O))
        {
            settingsPanel.SetActive(true);
            Unlock();
            lockedCamera.Priority = 11;
            lockedCamera.ForceCameraPosition(realCamera.transform.position, realCamera.transform.rotation);
        }

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
