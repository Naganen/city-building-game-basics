using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    //Arrays about objects
    [SerializeField]
    private GameObject[] buildableObjects; // GameObjects of buildable objects
    [SerializeField]
    private int[] prices; // Prices of buildable objects (Must be in same index with GameObjects)
    [SerializeField]
    private int[] currencyTypes; // Currency type of buildable objects (Must be in same index with GameObjects)

    public bool buildMode; // Toggle build mode

    public int selectedBuild; // Selected building ID from GameObjects

    [SerializeField]
    private int rotation; // Build rotation

    [SerializeField]
    EconomySystem economy; // Attach Economy script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (buildMode)
        {
            if (selectedBuild >= 0)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    // If selected building is in array lenght and greater than 0 build selected building
                    Build(buildableObjects[selectedBuild < buildableObjects.Length && selectedBuild >= 0 ? selectedBuild : -1]);
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    // Rotate the building before build with R
                    rotation += 90;

                    if (rotation > 360) { rotation = 0; }
                }
            }
            else if (selectedBuild == -1) {
                if (Input.GetButtonDown("Fire1"))
                {
                    // Click to building with "Object" to destroy
                    DestroyTarget();
                }
            }
        }

    }

    public void Build(GameObject structure)
    {
        // Find mouse position in world with ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Check if mouse clicking to object with "Terrain" tag
            if (hit.collider.tag == "Terrain")
            {
                // Decrease the price amount from specified currency with Economy script
                economy.RemoveCurrency(currency: currencyTypes[selectedBuild], amount: prices[selectedBuild]);
                // Build the object with 1x1 grid and rotation decided
                Instantiate(structure, new Vector3(Mathf.Round(hit.point.x), Mathf.Ceil(hit.point.y), Mathf.Round(hit.point.z)), Quaternion.Euler(0, rotation, 0));
            }
        }
    }

    private void DestroyTarget()
    {
        // Find mouse position in world with ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the object your clicking has "Object" tag
            if (hit.collider.tag == "Object")
            {
                // Destroy the object you clicking
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
