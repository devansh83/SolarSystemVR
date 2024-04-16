using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GazeSystem : MonoBehaviour
{
    public GameObject reticle;
    public Color inactiveReticleColor = Color.gray;
    public Color activeReticleColor = Color.green;


    private GazeableObject currentGazeObject;
    private GazeableObject currentSelectedObject;
    private RaycastHit lastHit;

    private float gazeDuration = 0f;
    private float requiredGazeDuration = 0.5f; // Adjust as needed

    private void Start()
    {
        SetReticleColor(inactiveReticleColor);
    }

    private void Update()
    {
        ProcessGaze();
        CheckForInput(lastHit);
    }

    private void ProcessGaze()
    {
        Ray raycastRay = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        Debug.DrawRay(raycastRay.origin, raycastRay.direction * 100);

        if (Physics.Raycast(raycastRay, out hitInfo))
        {
            GameObject hitObj = hitInfo.collider.gameObject;
            GazeableObject gazeObj = hitObj.GetComponent<GazeableObject>();

            if (gazeObj != null)
            {
                if (gazeObj != currentGazeObject)
                {
                    ClearCurrentObject();
                    currentGazeObject = gazeObj;
                    currentGazeObject.OnGazeEnter(hitInfo);
                    SetReticleColor(activeReticleColor);
                    gazeDuration = 0f; // Reset gaze duration
                }
                else
                {
                    gazeDuration += Time.deltaTime; // Increment gaze duration

                    if (gazeDuration >= requiredGazeDuration)
                    {
                        //MovePlayerToFrontOfTarget(currentGazeObject.planet);
                        SwitchScene(currentGazeObject.sceneName);
                    }

                    currentGazeObject.OnGaze(hitInfo);
                }

                lastHit = hitInfo;
            }
            else
            {
                ClearCurrentObject();
            }
        }
        else
        {
            ClearCurrentObject();
        }
    }

    private void CheckForInput(RaycastHit hitinfo)
    {
        // No need to check for input in this implementation
    }

    private void SetReticleColor(Color reticleColor)
    {
        reticle.GetComponent<Renderer>().material.SetColor("_Color", reticleColor);
    }

    private void ClearCurrentObject()
    {
        if (currentGazeObject != null)
        {
            currentGazeObject.OnGazeExit();
            SetReticleColor(inactiveReticleColor);
            currentGazeObject = null;
            gazeDuration = 0f; // Reset gaze duration when leaving the object
        }
    }

    private void MovePlayerToFrontOfTarget(GameObject target)
    {
        // Get the player GameObject (which is the parent of the main camera)
        GameObject player = transform.parent.gameObject;

        // Calculate the direction from the player to the target object
        Vector3 directionToTarget = target.transform.position - player.transform.position;

        // Calculate the desired distance from the target (adjust as needed)
        float distanceFromTarget = 2f;

        // Calculate the target position in front of the object
        Vector3 targetPosition = target.transform.position - directionToTarget.normalized * distanceFromTarget;

        // Update the player's position to the target position
        player.transform.position = targetPosition;

        // Ensure the player continues to move with the object
        player.transform.parent = target.transform;
    }

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}