using UnityEngine;

public class Task : MonoBehaviour
{
    private TaskManager manager;

    private void Start()
    {
        manager = TaskManager.instance;
        manager.OnTaskSpawn(this);
    }

    public void AccessTask()
    {
        print("Access");
    }

    public void StopAccessingTask()
    {

    }

    public void TaskSuccess() => manager.Success();
    public void TaskFailure() => manager.Failure();
}
