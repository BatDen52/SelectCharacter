using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Button))]
public class UIButtonAnimation : MonoBehaviour
{
    [SerializeField] private float _punchScale = 0.1f;
    [SerializeField] private float _duration = 0.3f;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(AnimateButton);
    }

    private void OnDisable()
    {        
        _button.onClick.RemoveListener(AnimateButton);
    }

    private void AnimateButton()
    {
        transform.DOPunchScale(Vector3.one * _punchScale, _duration);
    }
}