using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CharacterMovementHelper : MonoBehaviour
{
    private XRRig xrRig;
    private CharacterController characterController;
    private CharacterControllerDriver driver;

    private void Awake()
    {
        xrRig = GetComponent<XRRig>();
        characterController = GetComponent<CharacterController>();
        driver = GetComponent<CharacterControllerDriver>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharacterController();
    }

    /// <summary>
    /// Update the <see cref="CharacterController.height"/> and <see cref="CharacterController.center"/>
    /// based on the camera's position.
    /// </summary>
    protected virtual void UpdateCharacterController()
    {
        if (xrRig == null || characterController == null)
            return;

        var height = Mathf.Clamp(xrRig.cameraInRigSpaceHeight, driver.minHeight, driver.maxHeight);

        Vector3 center = xrRig.cameraInRigSpacePos;
        center.y = height / 2f + characterController.skinWidth;

        characterController.height = height;
        characterController.center = center;
    }
}
