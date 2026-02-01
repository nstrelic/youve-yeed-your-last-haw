using UnityEngine;

public class MaskRenderer : MonoBehaviour
{
    public LineRenderer line;
    public Transform mask;
    public Transform faceAnchor;
    public float snapCompleteDistance = 0.01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mask == null || faceAnchor == null || line == null)
            return;

        // Always draw the line between face and mask
        line.positionCount = 2;
        line.SetPosition(0, faceAnchor.position);
        line.SetPosition(1, mask.position);

        // When mask reaches the face, clear the line
        float dist = Vector3.Distance(mask.position, faceAnchor.position);

        if (dist <= snapCompleteDistance)
        {
            line.positionCount = 0;
        }

    }
}
