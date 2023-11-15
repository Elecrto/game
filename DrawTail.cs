using UnityEngine;
using System.Collections.Generic;

public class DragAndDrawTail : MonoBehaviour
{
    public LineRenderer tailRenderer; // Ссылка на компонент Line Renderer
    public float tailWidth = 0.1f; // Ширина хвоста
    public Material tailMaterial; // Материал хвоста
    public Color tailColor = Color.white; // Цвет хвоста
    public int maxTailSegments = 100; // Максимальное количество сегментов хвоста

    private List<Vector3> tailPositions = new List<Vector3>(); // Список позиций хвоста

    private void Start()
    {
        InitializeTailRenderer();
    }

    private void InitializeTailRenderer()
    {
        tailRenderer.positionCount = 0;
        tailRenderer.widthCurve = AnimationCurve.Constant(0, 1, tailWidth);
        tailRenderer.material = tailMaterial;
        tailRenderer.startColor = tailColor;
        tailRenderer.endColor = tailColor;
    }

    private void Update()
    {
        // Если пользователь нажимает и перемещает объект, обновляем хвост
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UpdateTail(mousePosition);
        }
    }

    private void UpdateTail(Vector3 newPosition)
    {
        // Добавляем новую позицию в хвост
        tailPositions.Add(newPosition);

        // Ограничиваем количество сегментов хвоста, чтобы не превышать максимальное значение
        if (tailPositions.Count > maxTailSegments)
        {
            tailPositions.RemoveAt(0);
        }

        // Устанавливаем позиции в Line Renderer
        tailRenderer.positionCount = tailPositions.Count;
        tailRenderer.SetPositions(tailPositions.ToArray());
    }
}
