using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Data/CharacterConfig", order = 0)]
public class CharacterData : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField, Range(0, 1)] private float _experiencePercentage;

    public Sprite Icon => _icon;
    public float ExperiencePercentage => _experiencePercentage;
}