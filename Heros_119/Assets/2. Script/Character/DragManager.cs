using UnityEngine;

public class DragManager : MonoBehaviour
{
    private Camera camera;
    private IDrag currentDragTarget;
    private Vector3 offset;

    private void Awake()
    {
        camera = Camera.main;
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        HandleMouse();
#else
        HandleTouch();
#endif
    }

    private void HandleMouse()
    {
        if (Input.GetMouseButtonDown(0)) // Ŭ�� ����
        {
            Vector2 pos = camera.ScreenToWorldPoint(Input.mousePosition);
            TryStartDrag(pos);
        }
        else if (Input.GetMouseButton(0) && currentDragTarget != null) // �巡�� ��
        {
            Vector3 pos = camera.ScreenToWorldPoint(Input.mousePosition);
            (currentDragTarget as MonoBehaviour).transform.position = pos + offset;
            currentDragTarget.OnDragging();
        }
        else if (Input.GetMouseButtonUp(0) && currentDragTarget != null) // �巡�� ����
        {
            currentDragTarget.OnDragEnd();
            currentDragTarget = null;
        }
    }

    private void HandleTouch()
    {
        if (Input.touchCount == 0) return;
        Touch touch = Input.GetTouch(0);
        Vector2 pos = camera.ScreenToWorldPoint(touch.position);

        switch (touch.phase)
        {
            case TouchPhase.Began:
                TryStartDrag(pos);
                break;
            case TouchPhase.Moved:
                if (currentDragTarget != null)
                {
                    (currentDragTarget as MonoBehaviour).transform.position = pos + offset;
                    currentDragTarget.OnDragging();
                }
                break;
            case TouchPhase.Ended:
            case TouchPhase.Canceled:
                if (currentDragTarget != null)
                {
                    currentDragTarget.OnDragEnd();
                    currentDragTarget = null;
                }
                break;
        }
    }

    private void TryStartDrag(Vector2 worldPos)
    {
        Collider2D hit = Physics2D.OverlapPoint(worldPos);
        if (hit && hit.TryGetComponent<IDrag>(out var drag))
        {
            currentDragTarget = drag;
            offset = hit.transform.position - (Vector3)worldPos;
            drag.OnDragStart();
        }
    }
}




// ? 4. ���� �ʿ��� ����
// - DragManager ������Ʈ 1�� ����
// - DragManager ��ũ��Ʈ ���̱�
// - �巡�� ������ ������Ʈ: Collider2D + IDrag ����ü�� ���̸� ��!