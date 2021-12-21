using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Material Light, Dark;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LightWindows(int numberOfWindows)
    {
        List<int> windowIds = new List<int>();
        for (int i = 0; i < numberOfWindows; i++)
        {
            bool next = false;
            while (!next)
            {
                int id = Random.Range(1, 10);
                if (!windowIds.Contains(id))
                {
                    windowIds.Add(id);
                    next = true;
                }
            }
        }

        foreach (var windowId in windowIds)
        {
            GameObject window = transform.Find("Window" + windowId).gameObject;
            window.GetComponent<MeshRenderer>().material = Light;
        }
    }
}
