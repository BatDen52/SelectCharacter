using System;
using System.Linq;
using UnityEngine;

public class ScreenShower : MonoBehaviour
{
    [SerializeField] private ScreenTypePair[] _screens;

    private BaseScreen _currentScreen;

    public void InitializeScreens()
    {
        foreach (ScreenTypePair screen in _screens)
        {
            screen.Screen.Hide();
            screen.Screen.Initialize(this);
        }
    }

    public void ShowScreen(ScreenType screenType)
    {
        BaseScreen targetScreen = _screens.FirstOrDefault(s => s.Type == screenType)?.Screen;

        if (targetScreen == null)
        {
            Debug.LogError("Invalid screen type");
            return;
        }

        if (_currentScreen == targetScreen) 
            return;

        if (_currentScreen != null)
        {
            _currentScreen.Hide();
            _currentScreen.Hided += OnHided;
        }
        else
        {
            targetScreen.Show();
        }

        _currentScreen = targetScreen;
    }

    private void OnHided(BaseScreen screen)
    {
        _currentScreen.Hided -= OnHided;
        _currentScreen.Show();
    }

    [Serializable]
    class ScreenTypePair
    {
        public ScreenType Type;
        public BaseScreen Screen;
    }
}