using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : BaseScreen
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _selectCaharacterButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _selectCaharacterButton.onClick.AddListener(OnSlectCaharacterButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _selectCaharacterButton.onClick.RemoveListener(OnSlectCaharacterButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnSlectCaharacterButtonClick()
    {
        ScreenShower.ShowScreen(ScreenType.CharacterSelection);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}