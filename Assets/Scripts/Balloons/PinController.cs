using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour
{
    public int color;
    private Ray ray;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 8f;
        Vector3 nextPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = nextPosition;
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Balloon")
                {
                    Balloon balloonHit = hit.transform.gameObject.GetComponent<Balloon>();
                    if (balloonHit.GetColor() == this.color)
                    {
                        GameObject.FindObjectOfType<LevelManager>().NotifyAboutCorrectHit();
                    }
                    else
                    {
                        GameObject.FindObjectOfType<LevelManager>().NotifyAboutIncorrectHit();
                    }
                    balloonHit.GetHit();
                }
            }
        }
    }

    public void SetColor(int color)
    {
        this.color = color;
        GameObject pinModel = transform.Find("Pin Body").gameObject.transform.Find("Cylinder.001").gameObject;
        pinModel.GetComponent<MeshRenderer>().material = GameObject.FindObjectOfType<ColorManager>().GetMaterial(color);
    }
}
