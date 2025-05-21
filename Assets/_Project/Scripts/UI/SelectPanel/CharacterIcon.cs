using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterIcon : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _icon;

    public event Action<CharacterIcon> Selected;
    public event Action<CharacterIcon> Deselected;

    public CharacterData Data { get; private set; }

    private void OnEnable()
    {
        _button.onClick.AddListener(Select);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Select);
    }

    public void Initialize(CharacterData character)
    {
        Data = character;
        _icon.sprite = character.Icon;
    }

    public void Select()
    {
        Selected?.Invoke(this);
    }

    public void Deselect()
    {
        Deselected?.Invoke(this);
    }
}