using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

    private Text rendererComponent;
    private Color defaultColor;
    public ButtonType buttonType;

    public enum ButtonType
    {
        PlaySurvival,
        Quit
    }

    private void Start()
    {
        rendererComponent = GetComponent<Text>();
        defaultColor = rendererComponent.color;
        Cursor.visible = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (buttonType)
        {
            case ButtonType.PlaySurvival:
                SceneManager.LoadScene("Survival");
                break;
            case ButtonType.Quit:
                Application.Quit();
                break;
            default:
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rendererComponent.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rendererComponent.color = defaultColor;
    }
}
