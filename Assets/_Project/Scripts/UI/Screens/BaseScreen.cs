using System;
using UnityEngine;

[RequireComponent(typeof(ScreenView), typeof(ScreenAnimator))]
public abstract class BaseScreen : MonoBehaviour
{
    [SerializeField] private ScreenView _view;
    [SerializeField] private ScreenAnimator _animator;

    public event Action<BaseScreen> Showed;
    public event Action<BaseScreen> Hided;

    protected ScreenShower ScreenShower { get; private set; }

    public void Initialize(ScreenShower screenShower)
    {
        ScreenShower = screenShower;
    }

    public virtual void Show()
    {
        _view.Activate();
        _animator.FadeIn(() => Showed?.Invoke(this));
    }

    public virtual void Hide()
    {
        _animator.FadeOut(() =>
        {
            _view.Deactivate();
            Hided?.Invoke(this);
        });
    }
}
