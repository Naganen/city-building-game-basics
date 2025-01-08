using UnityEngine;

public class BasicCameraControl : MonoBehaviour
{
    [SerializeField]
    private float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.position += new Vector3(h * speed, 0, v * speed) * Time.deltaTime;
    }
}
