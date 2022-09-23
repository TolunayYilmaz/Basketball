using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject PanelUi;
    [SerializeField] private GameObject GameUi;
    [SerializeField] private GameObject SliderUi;

    public Slider forceSlider;
    private void Start()
    {
        Cursor.visible = false;
    }
    public void Pause()
    {
        Time.timeScale = 0;
        GameUi.SetActive(false);
        SliderUi.SetActive(false);
        PanelUi.SetActive(true);
        Cursor.visible = true;   
    }
    public void Resume()
    {
        Time.timeScale = 1;
        PanelUi.SetActive(false);
        SliderUi.SetActive(true);
        GameUi.SetActive(true);
        Cursor.visible=false;
    }
    public void Exit()
    {
        Application.Quit();
    }
     
    public void ForceSlider(float value)
    {
        forceSlider.value = value;  
    }
}
