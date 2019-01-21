using UnityEngine;

public class StartScreenOrientation : MonoBehaviour
{
    // Start in landscape mode
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
