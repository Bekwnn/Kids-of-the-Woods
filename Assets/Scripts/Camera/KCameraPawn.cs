using UnityEngine;
using System.Collections;

[RequireComponent (typeof (KCameraMovementComponent))]
[RequireComponent(typeof (KCameraSelectionComponent))]

/*
 * Management component for various camera pawn systems
 */

public class KCameraPawn : MonoBehaviour
{
    // reference to owning player:
    public KPlayerState owningPlayer;

    // required CameraPawn components:
    public KCameraMovementComponent movementComponent;
    public KCameraSelectionComponent selectionComponent;

    // optional CameraPawnComponents:
    public KCameraOrderComponent orderComponent;
}
