using UnityEngine;

public class CursorLocker : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        var isSwitchingLockState = Input.GetButtonDown("Cancel");
        if (isSwitchingLockState)
            Cursor.lockState = (Cursor.lockState == CursorLockMode.Confined) ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
