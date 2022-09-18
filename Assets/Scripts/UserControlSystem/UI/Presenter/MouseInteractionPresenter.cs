using System.Linq;
using Abstractions;
using UnityEngine;
using UnityEngine.EventSystems;
using UserControlSystem;
using UniRx;

public sealed class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private EventSystem _eventSystem;

    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackableObjectRMB;
    [SerializeField] private Transform _groundTransform;
    private Plane _groundPlane;

    private void Start()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);
        ProcessMouseButtons();
    }

    private void ProcessMouseButtons()
    {
        var nonBlockedByUIStream = Observable.EveryUpdate().Where(_ => !_eventSystem.IsPointerOverGameObject());

        var raysStream = nonBlockedByUIStream.Select(_ => _camera.ScreenPointToRay(Input.mousePosition));
        var rayAndHitsStream = raysStream.Select(ray => (ray, Physics.RaycastAll(ray)));

        var leftMouseButtonClickedStream = rayAndHitsStream.Where(_ => Input.GetMouseButtonUp(0));
        var rightMouseButtonClickedStream = rayAndHitsStream.Where(_ => Input.GetMouseButtonUp(1));

        leftMouseButtonClickedStream.Subscribe(rayAndHitsData =>
        {
            var (ray, hits) = rayAndHitsData;
            if (hits.Length == 0)
            {
                return;
            }
            var selectable = hits
            .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
            .Where(c => c != null)
            .FirstOrDefault();
            _selectedObject.SetValue(selectable);
        });

        rightMouseButtonClickedStream.Subscribe(rayAndHitsData =>
        {
            var (ray, hits) = rayAndHitsData;
            if (isHiting<IAttackable>(hits, out var attackable))
            {
                _attackableObjectRMB.SetValue(attackable);
            }
            else if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            }
        });
    }

    private bool isHiting<T>(RaycastHit[] hits, out T result) where T : class
    {
        result = default(T);

        if (hits.Length == 0)
        {
            return false;
        }
        result = hits
        .Select(hit => hit.collider.GetComponentInParent<T>())
        .Where(c => c != null)
        .FirstOrDefault();

        return result != default(T);
    }

}