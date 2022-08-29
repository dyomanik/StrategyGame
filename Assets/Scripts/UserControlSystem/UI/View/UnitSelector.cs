using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private bool _isSelected;
    public void SetSelected(bool isSelected)
    {
        if (_isSelected == isSelected)
        {
            return;
        }

        if (isSelected)
        {
            _spriteRenderer.enabled = isSelected;
        }
        else
        {
            _spriteRenderer.enabled = false;
        }
        
        _isSelected = isSelected;
    }
}
