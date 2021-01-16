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
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector2 mouseDelta = (Vector2)Input.mousePosition - previousMousePosition;
            dragTransform.Translate(mouseDelta);
        }

        previousMousePosition = Input.mousePosition;
    }
}
