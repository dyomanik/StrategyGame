using Abstractions;
using UnityEngine;
using UserControlSystem;

public class UnitSelectorPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    private UnitSelector _unitSelector;
    private ISelectable _currentSelectable;

    private void Start()
    {
        _selectable.OnNewValue += onSelected;
        onSelected(_selectable.CurrentValue);
    }

    private void onSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        _currentSelectable = selectable;

        setSelected(_unitSelector, false);
        _unitSelector = null;

        if (selectable != null)
        {
            _unitSelector = (selectable as Component).GetComponentInParent<UnitSelector>();
            setSelected(_unitSelector, true);
        }

    }

    static void setSelected(UnitSelector unitSelector, bool value)
    {
        if (unitSelector != null)
        {
            unitSelector.SetSelected(value);
        }
    }
}