using UnityEngine;

public class RouteNavigator : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _wayPointsHolder;
    
    private Transform[] _wayPoints;
    private int _currentWayPointIndex = 0;
    
    private void Start()
    {
        _wayPoints = _wayPointsHolder.GetComponentsInChildren<Transform>();
    }
    
    private void Update()
    {
        var currentWaypointPosition = _wayPoints[_currentWayPointIndex].position;
        var step = _speed * Time.deltaTime;
        transform.position   =  Vector3.MoveTowards(transform.position , currentWaypointPosition, step);

        if (transform.position == currentWaypointPosition)
            _currentWayPointIndex = ++_currentWayPointIndex % _wayPoints.Length;
    }
}