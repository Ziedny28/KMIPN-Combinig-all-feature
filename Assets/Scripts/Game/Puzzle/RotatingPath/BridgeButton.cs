using UnityEngine;
using UnityEngine.UI;

public class BridgeButton : MonoBehaviour {
    public enum RotationDirection { Left, Right };
    public RotationDirection direction;

    public void rotateBridge() {
        BridgeController bridge = FindObjectOfType<BridgeController>();
        if (bridge != null) {
            if (direction == RotationDirection.Left) {
                bridge.RotateBridgeLeft();
            }
            else if (direction == RotationDirection.Right) {
                bridge.RotateBridgeRight();
            }
        }
    }
}