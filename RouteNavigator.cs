using UnityEngine;

public class RouteNavigator : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _wayPointHolder;
    
    private Transform[] _wayPoints;
    
    private int _currentWayPointIndex = 0;

    private void Awake()
    {
        _wayPoints = _wayPointHolder.GetComponentsInChildren<Transform>();
    }
    
    private void Update()
    {
        Vector3 currentWaypointPosition = _wayPoints[_currentWayPointIndex].position;
        float step = _speed * Time.deltaTime;
        
        transform.position = Vector3.MoveTowards(transform.position, currentWaypointPosition, step);

        if (transform.position == currentWaypointPosition)
            _currentWayPointIndex = ++_currentWayPointIndex % _wayPoints.Length;
    }
}