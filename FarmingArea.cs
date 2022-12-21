using UnityEngine;

public class FarmingArea : MonoBehaviour
{
    public GameObject[] cropPrefabs; // Array of crop prefabs that can be grown in the farming area
    public GameObject placementIndicatorPrefab; // Prefab for the visual indicator showing where the crop will be placed

    private GameObject placementIndicator; // Reference to the currently displayed placement indicator
    private int selectedCropIndex = -1; // Index of the currently selected crop (initialized to -1 to indicate no selection)

    void Update()
    {
        // Use raycasting to detect where the player is aiming and whether they are attempting to place a crop
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the hit point is within the bounds of the farming area collider
            if (hit.collider == GetComponent<Collider>())
            {
                // Display a visual indicator showing where the crop will be placed
                ShowPlacementIndicator(hit.point);

                // If the player is attempting to place a crop (i.e. they left-clicked), instantiate a new game object using the selected crop prefab
                if (Input.GetMouseButtonDown(0))
                {
                    int index = GetSelectedCropIndex(); // Get the index of the selected crop
                    // Instantiate a new game object using the selected crop prefab and add it to the farming area
                    GameObject crop = Instantiate(cropPrefabs[index]);
                    crop.transform.position = hit.point;
                    crop.transform.parent = transform;

                    // Add additional logic to handle crop placement, such as rotating or deleting the placed crop
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        // Check if the player is attempting to place a crop
        if (Input.GetMouseButton(0))
        {
            // Use raycasting to detect where the player is aiming and whether the hit point is within the farming area
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit point is within the bounds of the farming area collider
                if (hit.collider == GetComponent<Collider>())
                {
                    // Display a visual indicator showing where the crop will be placed
                    ShowPlacementIndicator(hit.point);
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // If the player leaves the farming area, hide the placement indicator
        HidePlacementIndicator();
    }

    // Method for displaying the placement indicator at a specific position
    void ShowPlacementIndicator(Vector3 position)
    {
        // If the placement indicator does not exist, instantiate a new one
        if (placementIndicator == null)
        {
            placementIndicator = Instantiate(placementIndicatorPrefab, position, Quaternion.identity);
        }
        // Otherwise, just move the existing placement indicator to the new position
        else
        {
            placementIndicator.transform.position = position;
        }
    }

    // Method for hiding the placement indicator
    void HidePlacementIndicator()
    {
        if (placementIndicator != null)
        {
            Destroy(placementIndicator);
            placementIndicator = null;
        }
    }

    // Method for getting the index of the currently selected crop
    int GetSelectedCropIndex()
    {
        // Add logic here to determine the selected crop index based on player input or UI selection
        return selectedCropIndex;
    }
}
