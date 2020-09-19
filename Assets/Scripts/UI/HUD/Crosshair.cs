using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Crosshair : MonoBehaviour
{
    
    public float[] points;
    public RectTransform[] crosshairs;

    RectTransform canvasRect;

    private void Awake()
    {
        //first you need the RectTransform component of your canvas
        canvasRect = GetComponent<RectTransform>();
    }


    void Update()
    {
        
        for(int i=0; i<crosshairs.Length; i++)
        {
            Vector3 worldPoint = Player.Instance.crosshairRay.GetPoint(points[i]);


            //then you calculate the position of the UI element
            //0,0 for the canvas is at the center of the screen, whereas WorldToViewPortPoint treats the lower left corner as 0,0. Because of this, you need to subtract the height / width of the canvas * 0.5f to get the correct position.

            Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(worldPoint);
            Vector2 WorldObject_ScreenPosition = new Vector2(
                ((ViewportPosition.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f)),
                ((ViewportPosition.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)));

            Debug.Log($"screen position: {WorldObject_ScreenPosition}");
            //now you can set the position of the ui element
            crosshairs[i].anchoredPosition = WorldObject_ScreenPosition;
        }

    }
}
