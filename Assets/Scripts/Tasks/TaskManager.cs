using System.Collections;
using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;
    public GameObject screenIntroText;
    public GameObject screenEndingText;
    public GameObject successImage;
    public GameObject failureImage;
    public GeneralTask[] tasks;
    public float delayAfterSuccess = 0.5f;
    [HideInInspector]
    public bool isRunning;
    public TextMeshProUGUI completedTasksUGUI;
    public TaskSounds soundManager;
    public Interactable door;
    private int completedTasks;
    private int taskIndex;
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
        currentTask = null;
        taskIndex = 0;
        completedTasks = 0;
    }

    public bool CanBeRunAgain => completedTasks < 20;

    private IEnumerator StartTask()
    {
        yield return new WaitForSeconds(1f);
        screenIntroText.SetActive(false);
        if (currentTask == null)
        {
            if (taskIndex >= tasks.Length)
                taskIndex = 0;
            currentTask = tasks[taskIndex];
            currentTask.Setup();
            taskIndex = taskIndex + 1;
        }
    }

    public void StartTasks()
    {
        if (CanBeRunAgain)
        {
            isRunning = true;
            if (currentTask == null)
            {
                screenIntroText.SetActive(true);
                StartCoroutine(StartTask());
            }
        }
    }

    public void StopTasks() => isRunning = false;

    private IEnumerator TaskEndImage(GameObject imageObject, bool isDone = false)
    {
        yield return new WaitForSeconds(1f);
        imageObject.SetActive(false);
        if (!isDone)
        {
            screenIntroText.SetActive(true);
            StartCoroutine(StartTask());
        }
        else
        {
            screenEndingText.SetActive(true);
            door.enabled = true;
        }
    }

    public void Failure()
    {
        soundManager.Failure();
        failureImage.SetActive(true);
        currentTask.gameObject.SetActive(false);
        currentTask.Teardown();
        currentTask = null;
        StartCoroutine(TaskEndImage(failureImage));
    }

    public void TaskState(bool isCompleted)
    {
        if (isCompleted)
            Success();
        else
            Failure();
    }

    public void Success() => StartCoroutine(DelayedSuccess());

    private IEnumerator DelayedSuccess()
    {
        var cachedTask = currentTask;
        var waitInstruction = new WaitForSeconds(delayAfterSuccess);
        yield return waitInstruction;
        if (cachedTask.hasSucceeded)
        {
            soundManager.Success();
            successImage.SetActive(true);
            currentTask.gameObject.SetActive(false);
            currentTask.Teardown();
            currentTask = null;
            ++completedTasks;
            completedTasksUGUI.text = string.Format("{0}/20 completed tasks", completedTasks);
            StartCoroutine(TaskEndImage(successImage, !CanBeRunAgain));
        }
    }
}
