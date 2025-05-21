using UnityEngine;
using DG.Tweening;
using System;

[Serializable]
public class WindowAnimatedElement
{
    [SerializeField] private Direction _enterDirection = Direction.Top;
    [SerializeField] private float _moveDistance = 1000f;
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private Ease _easeType = Ease.OutBack;
    [SerializeField] private RectTransform _rectTransform;

    public Direction EnterDirection => _enterDirection;
    public float MoveDistance => _moveDistance;
    public float Duration => _duration;
    public Ease EaseType => _easeType;
    public RectTransform RectTransform => _rectTransform;
}
