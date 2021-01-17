using UnityEngine;
using UnityEngine.EventSystems;


public class Draggable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    Transform dragTransform = default;

    Vector2 previousMousePosition = default;

    bool isDragging = default;


    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;

        // Reset previous mouse position to current position to prevent jumping between drags.
        previousMousePosition = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }

    private void Update()
    {
        if (!isDragging)
        {
            return;
        }

        Vector2 mouseDelta = (Vector2)Input.mousePosition - previousMousePosition;
        dragTransform.Translate(mouseDelta);
        previousMousePosition = Input.mousePosition;
    }
}
