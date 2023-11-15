using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    private void OnMouseDown()
    {
        // Запомните смещение между позицией мыши и центром объекта
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            // Получите текущую позицию мыши и преобразуйте ее в мировые координаты
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Переместите объект к текущей позиции мыши с учетом смещения
            transform.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, transform.position.z);
        }
    }
}
