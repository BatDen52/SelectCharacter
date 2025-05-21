using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionPanel : MonoBehaviour
{
    [SerializeField] private CharacterIcon _iconPrefab;
    [SerializeField] private ScrollRect _container;
    [SerializeField] private LayoutGroup _layoutGroup;

    private List<CharacterIcon> _icons = new();
    private CharacterIcon _currentSelected;

    public event Action<CharacterData> Selected;
    public event Action<CharacterData> Deselected;

    private void OnDestroy()
    {
        UnsubscribeIcons();
    }

    public void Fill(CharacterData[] characters)
    {
        UnsubscribeIcons();
        _icons.Clear();

        CreateIcons(characters);

        if (_icons.Count == 0)
            return;

        _currentSelected = _icons[0];
        _currentSelected.Select();

        if (_layoutGroup != null)
            StartCoroutine(Align());
    }

    private IEnumerator Align()
    {
        var fitter = _layoutGroup.GetComponent<ContentSizeFitter>();

        _layoutGroup.enabled = true;

        if (fitter != null)
            fitter.enabled = true;

        yield return new WaitForEndOfFrame();

        _layoutGroup.enabled = false;

        if (fitter != null)
            fitter.enabled = false;

        _container.verticalNormalizedPosition = 1;
    }

    private void CreateIcons(CharacterData[] characters)
    {
        CharacterIcon icon;

        foreach (CharacterData character in characters)
        {
            icon = Instantiate(_iconPrefab, _container.content);
            _icons.Add(icon);
            icon.Initialize(character);

            icon.Selected += OnSelected;
            icon.Deselected += OnDeselected;
        }
    }

    private void OnSelected(CharacterIcon icon)
    {
        _currentSelected?.Deselect();
        _currentSelected = icon;

        Selected?.Invoke(icon.Data);
    }

    private void OnDeselected(CharacterIcon icon)
    {
        Deselected?.Invoke(icon.Data);
    }

    private void UnsubscribeIcons()
    {
        foreach (CharacterIcon icon in _icons)
        {
            icon.Selected -= OnSelected;
            icon.Deselected -= OnDeselected;
        }
    }
}
