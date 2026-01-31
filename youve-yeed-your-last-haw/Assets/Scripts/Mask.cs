using UnityEngine;

public class Mask : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    public void pullMaskAway()
    {
        if (player.GetComponent<Player>().getPlayerNumber() == 1)
        {
            this.transform.position += new Vector3(1, 0, 0);
        }
        else
        {
            this.transform.position += new Vector3(-1, 0, 0);
        }
    }

    public void pullMaskTowards()
    {
        if (player.GetComponent<Player>().getPlayerNumber() == 1)
        {
            this.transform.position += new Vector3(-1, 0, 0);
        }
        else
        {
            this.transform.position += new Vector3(1, 0, 0);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
