using UnityEngine;

public class RtePivotTools
{
    public static void SetPivotPosition(RectTransform transform, Vector2 newPivotPos, bool alsoMoveRect = false)
    {
        if(alsoMoveRect)
        {
            transform.pivot = newPivotPos;
            return;
        }

        // This gives support to scaling, this is important when working with the pivot.
        Vector2 pivotDelta  = newPivotPos - transform.pivot;
        pivotDelta.x       /= transform.localScale.x; 
        pivotDelta.y       /= transform.localScale.y; 
        pivotDelta          = pivotDelta.FixNaN();

        // Unity moves the rect to the pivot target position when moving the pivot with 
        // code, also does strange things when the anchors are not joinded, so with this 
        // we calculate ourselves the position that should have the rect to correct these issues.
        Vector2 correctPosition = GetRectCoordinatesFromPivotPosition(transform, newPivotPos);
        transform.pivot        += pivotDelta;
        RteRectTools.SetPositionIgnoringAnchors(transform, correctPosition);
    }

    /// <summary>
    /// Convert pivot coordinates (values between 0 and 1) into rect coordinates.
    /// </summary>
    public static Vector2 GetPivotPositionFromRectCoordinatesIgnoringAnchors(RectTransform tr, Vector2 rectCoordinates)
    {
        rectCoordinates -= RteRectTools.GetPositionIgnoringAnchorsAndPivot(tr);
        return new Vector2(rectCoordinates.x / tr.rect.size.x, rectCoordinates.y / tr.rect.size.y).FixNaN();
    }

    /// <summary>
    /// Convert rect coordinates into pivot coordinates (values between 0 and 1).
    /// </summary>
    public static Vector2 GetRectCoordinatesFromPivotPosition(RectTransform tr, Vector2 pivotPosition)
    {
        Vector2 pivotPosInLocalRectCoord = new Vector2(pivotPosition.x * tr.rect.size.x, pivotPosition.y * tr.rect.size.y);
        Vector2 rectPos                  = RteRectTools.GetPositionIgnoringAnchorsAndPivot(tr);
        return pivotPosInLocalRectCoord + rectPos;
    }

    public static Vector2 GetCanvasPositionFromLocalPosition(RectTransform tr, Vector2 pivotPosition)
    {
        Vector2 size     = RteRectTools.GetSizeIgnoringAnchors(tr);
        Vector2 position = RteRectTools.GetPositionIgnoringAnchorsAndPivot(tr);
        size.x  *= pivotPosition.x;
        size.y  *= pivotPosition.y;
        size    += position;
        return RteAnchorTools.GetCanvasAnchorCoordinateNormalizedFromRectCoordinate(tr, size);
    }

    public static Vector2 GetLocalPositionFromCanvasPosition(RectTransform transform, Vector2 canvasPosition)
    {
        Vector2 rectCoordinate = RteAnchorTools.GetRectCoordinateFromCanvasAnchorCoordinateNormalized(transform, canvasPosition);
        Vector2 position       = RteRectTools.GetPositionIgnoringAnchorsAndPivot(transform);
        Vector2 size           = RteRectTools.GetSizeIgnoringAnchors(transform);
        rectCoordinate        -= position;
        rectCoordinate.x      /= size.x;
        rectCoordinate.y      /= size.y;
        rectCoordinate.FixNaN();
        return rectCoordinate;
    }
}
