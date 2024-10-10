using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        var fov = (FieldOfView)target;
        
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.PointOfView, Vector3.up, Vector3.forward, 360, fov.Radius);

        var viewAngleLeft = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.Angle / 2);
        var viewAngleRight = DirectionFromAngle(fov.transform.eulerAngles.y, fov.Angle / 2);
        
        Handles.color = Color.yellow;
        Handles.DrawLine(fov.PointOfView, fov.PointOfView + viewAngleLeft * fov.Radius);
        Handles.DrawLine(fov.PointOfView, fov.PointOfView + viewAngleRight * fov.Radius);
        
        if (fov.CanSeePlayer)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fov.PointOfView, fov.PlayerPosition);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        var angle = angleInDegrees + eulerY;
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 
            0,
            Mathf.Cos(angle * Mathf.Deg2Rad));
    }
}