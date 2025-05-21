using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CharacterIcon))]
public class UISelectAnimation : MonoBehaviour
{
    [SerializeField] private float _selectScaleFactor = 1.1f;
    [SerializeField] private float _duration = 0.3f;

    private CharacterIcon _characterIcon;
    private Vector3 _originalScale;
    private bool _isInitialized;
    private bool _isAnimating;

    private void Awake()
    {
        _characterIcon = GetComponent<CharacterIcon>();
    }

    private void OnEnable()
    {
        _characterIcon.Selected += OnSelect;
        _characterIcon.Deselected += OnDeselect;
    }

    private void OnDisable()
    {
        _characterIcon.Selected -= OnSelect;
        _characterIcon.Deselected -= OnDeselect;
    }

    private void Initialize()
    {
        _originalScale = transform.localScale;
        _isInitialized = true;
    }

    private void OnSelect(CharacterIcon _)
    {
        if (_isInitialized == false)
            Initialize();

        AnimateScale(_originalScale * _selectScaleFactor);
    }

    private void OnDeselect(CharacterIcon _)
    {
        if (_isInitialized == false)
            Initialize();

        AnimateScale(_originalScale);
    }

    private void AnimateScale(Vector3 targetScale)
    {
        if (_isAnimating)
            return;

        _isAnimating = true;

        transform.DOScale(targetScale, _duration)
            .OnComplete(() => _isAnimating = false);
    }
}