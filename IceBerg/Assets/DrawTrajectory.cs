using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectory : MonoBehaviour
{
    [SerializeField]private LineRenderer line;
    [SerializeField][Range(3, 30)]private int _lineSegmentCount;
    [SerializeField][Range(10, 100)]private int _showPorcentage;
    [SerializeField]private int _linePointCount;
    private List<Vector3> _linePoints = new List<Vector3>();


    #region Singleton
    public static DrawTrajectory Instance;

    private void Awake(){
        Instance = this;
        Debug.Log(Instance);
    }

    #endregion


    private void Start(){
        _linePointCount = (int)(_lineSegmentCount*(_showPorcentage/100f));
        HideLine();
    }

    public void UpdateLine(Vector3 force, Rigidbody rb, Vector3 StartingPoint){
        Vector3 velocity = (force/rb.mass)* Time.fixedDeltaTime;
        //Debug.Log(velocity);
        float fligthDuration = (2*velocity.y)/Physics.gravity.y;
        float stepTime = fligthDuration/_lineSegmentCount;


        _linePoints.Clear();
        _linePoints.Add(StartingPoint);


        //for (int i = 1; i < _linePointsCount; i++)
        for (int i = 1; i < _lineSegmentCount; i++)
        {
            float stepTimePassed = stepTime *i;
            Vector3 movementVector = new Vector3(
                x: velocity.x * stepTimePassed,
                y: velocity.y * stepTimePassed - 0.5f * Physics.gravity.y* stepTimePassed*stepTimePassed,
                z: velocity.z * stepTimePassed
            );

            Vector3 NewPointOnLine= -movementVector+StartingPoint;

            RaycastHit hit;
            if(Physics.Raycast(_linePoints[i-1], NewPointOnLine, out hit, (NewPointOnLine-_linePoints[i-1]).magnitude)){
                _linePoints.Add(hit.point);
                break;
            }

            //Debug.DrawLine(_linePoints[i-1], NewPointOnLine,Color.magenta, 0f, true);

            _linePoints.Add(NewPointOnLine);
        }

        line.positionCount = _linePoints.Count;
        line.SetPositions(_linePoints.ToArray());
    }

    public void HideLine(){
        line.positionCount=0;
    }
}
