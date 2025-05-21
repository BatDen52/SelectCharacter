using UnityEngine;

public class ScreenView : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private CanvasGroup _canvasGroup;

    public bool IsVisible => _canvas.enabled;

    public void Activate()
    {
        _canvas.enabled = true;
        _canvasGroup.alpha = 1f;
    }

    public void Deactivate()
    {
        _canvas.enabled = false;
        _canvasGroup.alpha = 0f;
    }
}
