using UnityEngine;

public class TaskMachine : MonoBehaviour
{
    private TaskManager manager;

    public GameObject screenOverlay;
    public GameObject playerCinemachineCamera;
    public CursorLocker cursorLocker;

    private void Start() => manager = TaskManager.instance;

    public void AccessTask()
    {
        screenOverlay.SetActive(true);
        playerCinemachineCamera.SetActive(false);
        cursorLocker.Unlock();
        manager.StartTasks();
    }

    public void StopAccessingTask()
    {
        screenOverlay.SetActive(false);
        playerCinemachineCamera.SetActive(true);
        cursorLocker.Lock();
    }

    public void TaskSuccess() => manager.Success();
    public void TaskFailure() => manager.Failure();
}
