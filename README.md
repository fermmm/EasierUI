# EasierUI

This is a Unity3D asset meant to simplify the UI development by providing more position and size values like in CSS where you have for example: 100px, 100vw, 100cqi, etc.
Currently is not maintained but it should work, PRs are welcome.

This tool is very visual so it's better to learn what it does with a video:

https://www.youtube.com/watch?v=IIUTFeXQ4Uc

Here I did the video again with a more updated version that has more values:

https://www.youtube.com/watch?v=qY2Qi8aBkv8

# ⚠ Important:

You can add the Rect Transform Extended component to any UI GameObject to practice and understand what this tool can do, but don't reference it from code and don't use it in production, because it's slow.

Your final code should use the following methods that are added to the RectTransform (extension methods):

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

# Current limitations:
UI elements that are rotated and scaled are not supported, size and position values may be wrong for those elements. I don't have more time to spend in this library but a PR to fix this is welcome.

# License:
[LGPL](https://en.wikipedia.org/wiki/GNU_Lesser_General_Public_License) It means you can use this library in a proprietary or commercial project but the library itself or modifications of it should be open source and free.
