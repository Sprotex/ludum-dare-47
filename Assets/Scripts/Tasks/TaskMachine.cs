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
        if (!manager.isRunning)
        {
            playerCinemachineCamera.SetActive(false);
            cursorLocker.Unlock();
            manager.StartTasks();
        }
    }

    public void StopAccessingTask()
    {
        if (manager.isRunning)
        {
            playerCinemachineCamera.SetActive(true);
            cursorLocker.Lock();
        }
    }

    public void TaskSuccess() => manager.Success();
    public void TaskFailure() => manager.Failure();
}
