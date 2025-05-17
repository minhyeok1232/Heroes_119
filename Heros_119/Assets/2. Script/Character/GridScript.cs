using UnityEngine;

public class GridScript : MonoBehaviour
{
    // grid
    [SerializeField] private Transform[] gridSlots;

    public Transform[] getGridSlots()
    {
        return gridSlots;
    }
}
