using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void OnTaskSpawn(Task task)
    {
        print("There is new task for you.");
    }

    public void Failure()
    {
        print("Current task has FAILED!");
    }

    public void Success()
    {
        print("Current task has succeeded.");
    }
}
