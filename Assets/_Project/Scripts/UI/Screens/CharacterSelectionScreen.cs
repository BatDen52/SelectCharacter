using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharacterSelectionScreen : BaseScreen
{
    [SerializeField] private CharacterSelectionPanel _selectionPanel;
    [SerializeField] private Image _selectedCharacterIcon;
    [SerializeField] private Button _backButton;
    [SerializeField] private Image _experienceBar;

    [SerializeField] private float _iconHideDuration = 0.2f;
    [SerializeField] private float _iconShowDuration = 0.3f;
    [SerializeField] private float _iconHideScale = 0f;
    [SerializeField] private float _experienceFillDuration = 0.5f;

    private Vector3 _iconScale;

    private void OnEnable()
    {
        _backButton.onClick.AddListener(OnBackButtonClick);
        _selectionPanel.Selected += UpdateCharacterSelection;
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveListener(OnBackButtonClick);
        _selectionPanel.Selected -= UpdateCharacterSelection;
    }

    private void Start()
    {
        _iconScale = _selectedCharacterIcon.rectTransform.localScale;
    }

    private void OnBackButtonClick()
    {
        ScreenShower.ShowScreen(ScreenType.MainMenu);
    }

    private void UpdateCharacterSelection(CharacterData character)
    {
        _selectedCharacterIcon.transform.DOScale(_iconHideScale, _iconHideDuration).OnComplete(() =>
        {
            _selectedCharacterIcon.sprite = character.Icon;
            _selectedCharacterIcon.transform.DOScale(_iconScale, _iconShowDuration);
        });

        _experienceBar.DOFillAmount(character.ExperiencePercentage, _experienceFillDuration);
    }
}