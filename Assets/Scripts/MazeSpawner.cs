using UnityEngine;
using UnityEngine.AI;

public class MazeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cell, _deadZone;
    [SerializeField] private NavMeshSurface _navMeshSurface;
    private int _width = 9;
    private int _heigth = 9;
    private int _offset = 4; // Because the plane locate in Vector3(0, 0, 0)

    private void Start()
    {
        GenearationMaze();
    }

    private void GenearationMaze()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _heigth; y++)
            {
                if(Random.value > 0.3f)
                    Instantiate(_cell, new Vector3(x - _offset, 0.1f, y - _offset), Quaternion.Euler(0, GetRandomAngle(), 0));
                else if(Random.value > 0.7f)
                    Instantiate(_deadZone, new Vector3(x - _offset, 0, y - _offset), Quaternion.identity);
            }
        }
        _navMeshSurface.BuildNavMesh();
    }
    private int GetRandomAngle() => Random.value > 0.5f ? 90 : 0;

}
