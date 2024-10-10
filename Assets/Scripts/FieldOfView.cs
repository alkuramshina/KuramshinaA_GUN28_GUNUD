using System.Collections;
using System.Linq;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField, Range(0, 360)] private float angle;

    [SerializeField] private Player player;
    
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private LayerMask obstacleLayer;

    private bool _canSeePlayer;
    
    public bool CanSeePlayer => _canSeePlayer;
    public float Radius => radius;
    public float Angle => angle;
    public Vector3 PlayerPosition => player.transform.position;

    private void Start()
    {
        StartCoroutine(FovRoutine());
    }

    private IEnumerator FovRoutine()
    {
        var wait = new WaitForSeconds(0.2f);

        while (player is not null)
        {
            yield return wait;
            CheckFieldOfView();
        }
    }

    private void CheckFieldOfView()
    {
        var rangeChecks = Physics.OverlapSphere(transform.position, radius, targetLayer);
        if (rangeChecks.Any())
        {
            var target = rangeChecks[0].transform;
            var directionToTarget = (target.position - transform.position).normalized;

            var isInAngleOfView = Vector3.Angle(transform.forward, directionToTarget) < angle / 2;
            if (isInAngleOfView)
            {
                var distanceToTarget = Vector3.Distance(transform.position, target.position);
                
                _canSeePlayer = !Physics.Raycast(transform.position, directionToTarget, 
                    distanceToTarget, obstacleLayer);
            }
            else
            {
                _canSeePlayer = false;
            }
        }
        else
        {
            _canSeePlayer = false;
        }
    }
}
