using UnityEngine;
using DG.Tweening;
using System;

public enum Direction { Top, Bottom, Left, Right }

[Serializable]
public class WindowAppearAnimation
{

    [SerializeField] private float _delayFirstElements = 0.1f;
    [SerializeField] private float _delayBetweenElements = 0.1f;
    [SerializeField] private WindowAnimatedElement[] _animatedElements;

    private Vector2[] _originalPositions;
    private bool _isAnimating;
    private bool _isInitialized;

    private void Initialize()
    {
        _originalPositions = new Vector2[_animatedElements.Length];

        for (int i = 0; i < _animatedElements.Length; i++)
            _originalPositions[i] = _animatedElements[i].RectTransform.anchoredPosition;

        _isInitialized = true;
    }

    public void PlayEnterAnimation()
    {
        if (_isAnimating)
            StopAnimations();

        if (_isInitialized == false)
            Initialize();

        _isAnimating = true;

        for (int i = 0; i < _animatedElements.Length; i++)
        {
            RectTransform element = _animatedElements[i].RectTransform;
            Vector2 direction = GetDirectionVector(_animatedElements[i].EnterDirection);

            element.anchoredPosition = _originalPositions[i] + direction * _animatedElements[i].MoveDistance;

            element.DOAnchorPos(_originalPositions[i], _animatedElements[i].Duration)
                .SetDelay(i * _delayBetweenElements + _delayFirstElements)
                .SetEase(_animatedElements[i].EaseType)
                .OnComplete(() => _isAnimating = false);
        }
    }

    public void PlayExitAnimation()
    {
        if (_isAnimating)
            return;

        if (_isInitialized == false)
            Initialize();

        _isAnimating = true;

        for (int i = _animatedElements.Length - 1; i >= 0; i--)
        {
            RectTransform element = _animatedElements[i].RectTransform;
            Vector2 direction = GetDirectionVector(_animatedElements[i].EnterDirection);

            element.DOAnchorPos(_originalPositions[i] + direction * _animatedElements[i].MoveDistance, _animatedElements[i].Duration)
                .SetDelay((_animatedElements.Length - 1 - i) * _delayBetweenElements + _delayFirstElements)
                .SetEase(_animatedElements[i].EaseType)
                .OnComplete(() =>
                {
                    _isAnimating = false;
                });
        }
    }

    public void StopAnimations()
    {
        foreach (var element in _animatedElements)
            element.RectTransform.DOKill();
    }

    private Vector2 GetDirectionVector(Direction direction)
    {
        return direction switch
        {
            Direction.Top => Vector2.up,
            Direction.Bottom => Vector2.down,
            Direction.Left => Vector2.left,
            Direction.Right => Vector2.right,
            _ => Vector2.up
        };
    }
}