using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShieldPressing : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Immortality _immortality;
    private Image _image;
    private Collider _playerCollider;
    private bool _isPressed;

    private void Start()
    {
        _playerCollider = _immortality.gameObject.GetComponent<Collider>();
        _image = GetComponent<Image>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _immortality.ActiveImmortality();
        IndicateActivationStatus(false, true);
        transform.localScale *= 1.2f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _immortality.DeactivateImmortality();
        IndicateActivationStatus(true, false);
        transform.localScale /= 1.2f;
    }
    private void Update()
    {
        if(_isPressed)
        {
            _image.fillAmount -= Time.deltaTime / 2;
            if (_image.fillAmount == 0)
            {
                IndicateActivationStatus(true, false);
                _immortality.DeactivateImmortality();
            }     
        }
    }
    private void IndicateActivationStatus(bool playerCollider, bool isPressed)
    {
        _playerCollider.enabled = playerCollider;
        _isPressed = isPressed;
    }
}
