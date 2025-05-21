using System.Collections;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [Header("Configs")]
    [SerializeField] private CharacterData[] _allCharacters;

    [Header("Dependencies")]
    [SerializeField] private ScreenShower _screenShower;
    [SerializeField] private CharacterSelectionPanel _characterSelectionPanel;

    private void Start()
    {
        StartCoroutine(InitializeUI());
    }

    private IEnumerator InitializeUI()
    {
        yield return new WaitForEndOfFrame();

        _characterSelectionPanel.Fill(_allCharacters);
        _screenShower.InitializeScreens();

        _screenShower.ShowScreen(ScreenType.MainMenu);
    }
}