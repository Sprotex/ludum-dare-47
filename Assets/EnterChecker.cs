using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnterChecker : MonoBehaviour
{
    public TMPro.TMP_InputField inputField;
    public Button submitButton;

    private void Update()
    {
        var isInputFieldSelected = EventSystem.current.currentSelectedGameObject == inputField.gameObject;
        if (isInputFieldSelected && Input.GetKeyDown(KeyCode.Return))
            submitButton.onClick.Invoke();
    }
}
