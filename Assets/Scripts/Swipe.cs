using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    // Diger scriptten cagırmak icin videonun basına bak
    private bool _Tap, _RightSwipe, _LeftSwipe, _UpSwipe, _DownSwipe;
    private bool _isDraging = false;
    private Vector2 _StartTouch, _SwipeDelta;

    private void Update() {
        _Tap=_DownSwipe=_LeftSwipe=_RightSwipe=_UpSwipe = false;

        #region Standalone Inputs
        if(Input.GetMouseButtonDown(0))
        {
            _Tap = true;
            _isDraging = true;
            _StartTouch = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            _isDraging = false;
            Reset();
        }
        #endregion
        #region Mobile Inputs
        if(Input.touches.Length != 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                _Tap = true;
                _isDraging = true;
                _StartTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                _isDraging = false;
                Reset();
            }
        }
        #endregion
        _SwipeDelta = Vector2.zero;
        if(_isDraging)
        {
            if(Input.touches.Length > 0)
            _SwipeDelta = Input.touches[0].position - _StartTouch;
            else if(Input.GetMouseButton(0))
            _SwipeDelta = (Vector2)Input.mousePosition - _StartTouch;
            
        }
        if(_SwipeDelta.magnitude > 125)
        {
            float x = _SwipeDelta.x;
            float y = _SwipeDelta.y;

            if(Mathf.Abs(x)> Mathf.Abs(y))
            {
                if(x<0)
                _LeftSwipe = true;
                else
                _RightSwipe = true;
            }else
            {
                if(y < 0 )
                _DownSwipe = true;
                else
                _UpSwipe = true;
            }


            Reset();
        }
    } 
    private void Reset() {
        _StartTouch = _SwipeDelta = Vector2.zero;
        _isDraging = false;
    }
    public Vector2 SwipeDelta { get {return _SwipeDelta;}}
    public bool LeftSwipe {get{return _LeftSwipe;}}
    public bool RightSwipe {get{return _RightSwipe;}}
    public bool UpSwipe {get{return _UpSwipe;}}
    public bool DownSwipe {get{return _DownSwipe;}}

    


    
}
