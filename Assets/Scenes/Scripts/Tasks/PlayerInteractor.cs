using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public Camera mainCamera;

    private void Update()
    {
        var isMouseClicked = Input.GetMouseButtonDown(0);
        if (isMouseClicked)
            TryUseInteractableInFront();
    }

    private void TryUseInteractableInFront()
    {
        var maxDistance = 1f;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out var info, maxDistance))
        {
            var task = info.collider.GetComponent<TaskMachine>();
            if (task != null)
                task.AccessTask();
        }
            
    }
}
