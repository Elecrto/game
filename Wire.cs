using UnityEngine;

public class Wire : MonoBehaviour
{
    public Color wireColor;
    public bool isConnected = false;
    public Wire connectedWire;

    private void OnMouseDown()
    {
        if (!isConnected)
        {
            GameManager.Instance.SelectWire(this);
        }
    }

    public void ConnectTo(Wire otherWire)
    {
        if (!isConnected && !otherWire.isConnected && wireColor == otherWire.wireColor)
        {
            isConnected = true;
            otherWire.isConnected = true;
            connectedWire = otherWire;
            otherWire.connectedWire = this;
        }
    }
    private void Update()
{
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0); // Первое касание
        if (touch.phase == TouchPhase.Began)
        {
            // Если касание началось, проверьте, находится ли точка касания над проводом
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Wire wire = hit.collider.GetComponent<Wire>();
                if (wire != null)
                {
                    wire.OnMouseDown();
                }
            }
        }
    }
}

}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Wire selectedWire;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectWire(Wire wire)
    {
        if (selectedWire == null)
        {
            selectedWire = wire;
        }
        else
        {
            selectedWire.ConnectTo(wire);
            selectedWire = null;
        }
    }
}
