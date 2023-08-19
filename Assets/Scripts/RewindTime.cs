using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindTime : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isRewind = false;

    List<Vector3> positions;

    //Rigidbody rb;
    void Start()
    {
        positions = new List<Vector3>();
        //rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isRewind)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    void Record()
    {
        positions.Insert(0, transform.position);
    }
    void Rewind()
    {
        if(positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
        {
            stopRewind();
        }
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            startRewind();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            stopRewind();
        }
    }
    public void startRewind()
    {
        isRewind = true;
        //rb.isKinematic = true;
    }
    public void stopRewind()
    {
        isRewind = false;
    }
}
