# EasierUI

This an old Unity 3D asset is meant to simplify the UI development. Currently is not maintained but it should work, PRs are welcome.

# ⚠ Important:

You can add the Rect Transform Extended component to any UI GameObject to practice and understand what this tool can do, but don't reference it from code and don't use it in production, because it's slow.

Yur final code should use the following methods that will be added to the RectTransform (extension methods):

```csharp
yourRectTransform.GetPosition()
yourRectTransform.SetPosition()

yourRectTransform.GetAnchorsPosition()
yourRectTransform.SetAnchorsPosition()

yourRectTransform.SetPositionX()
yourRectTransform.SetPositionY()

yourRectTransform.SetWidth()
yourRectTransform.SetHeight()

yourRectTransform.SetAnchorsPositionX()
yourRectTransform.SetAnchorsPositionY()

yourRectTransform.SetAnchorsWidth()
yourRectTransform.SetAnchorsHeight()

yourRectTransform.GetPivotPosition()
yourRectTransform.SetPivotPosition()
```

Also 4 options are added to the Tools menu in the Unity UI:

    - UI Anchors To Corners
    - UI Corners To Anchors
    - UI Center Rect
    - UI Center Anchors

# Usange example:

```csharp
RectTransfrom myRectTransform = transform as RectTransform;
Vector2 size = myRectTransform.GetSize(CoordinateSystem.IgnoreAnchorsAndPivot);
```

If you need a more advanced usage converting coordinates instead of setting and getting, use the methods of the static classes:

`RteRectTools` and `RteAnchorTools`
Also these static classes contains some extra coordinate conversion methods.
