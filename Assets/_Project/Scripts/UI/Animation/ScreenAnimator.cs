using DG.Tweening;
using System;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ScreenAnimator : MonoBehaviour
{
    [SerializeField] private float _fadeDuration = 0.5f;
    [SerializeField] private WindowAppearAnimation[] _windowAnimations;

    private CanvasGroup _canvasGroup;
    private Tweener _activeTween;

    private void Awake() => _canvasGroup = GetComponent<CanvasGroup>();

    private void OnDestroy() => _activeTween?.Kill();

    public void FadeIn(Action onComplete = null)
    {
        PlayFadeAimation(1f, onComplete);

        foreach (var animation in _windowAnimations)
            animation?.PlayEnterAnimation();
    }

    public void FadeOut(Action onComplete = null)
    {
        PlayFadeAimation(0f, onComplete);

        foreach (var animation in _windowAnimations.Reverse())
            animation?.PlayExitAnimation();
    }

    private void PlayFadeAimation(float targetValue, Action onComplete)
    {
        _activeTween?.Kill();

        _activeTween = _canvasGroup.DOFade(targetValue, _fadeDuration)
                    .OnComplete(() =>
                    {
                        onComplete?.Invoke();
                        _activeTween = null;
                    });
    }
}