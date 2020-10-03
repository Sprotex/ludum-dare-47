using System.Collections;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;
    public GeneralTask[] tasks;
    public float delayAfterSuccess = 0.5f;

    private GeneralTask currentTask;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        var index = Random.Range(0, tasks.Length);
        currentTask = tasks[index];
        currentTask.Setup();
    }

    public void Failure()
    {
        print("Current task has FAILED!");
        currentTask.gameObject.SetActive(false);
        currentTask.Teardown();

    }

    public void TaskState(bool isCompleted)
    {
        if (isCompleted)
            Success();
        else
            Failure();
    }

    public void Success()
    {
        StartCoroutine(DelayedSuccess());
    }

    private IEnumerator DelayedSuccess()
    {
        var waitInstruction = new WaitForSeconds(delayAfterSuccess);
        yield return waitInstruction;
        if (currentTask.hasSucceeded)
        {
            print("Current task has succeeded.");
            currentTask.gameObject.SetActive(false);
            currentTask.Teardown();
        }
    }
}
