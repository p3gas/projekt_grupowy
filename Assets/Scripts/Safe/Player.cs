using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Safe
{
    public class Player : MonoBehaviour
    {
        public Safe safe;
        private Ray ray;
        private RaycastHit hit;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "SafeButton")
                    {
                        char buttonDigit = hit.transform.name[hit.transform.name.Length - 1];
                        if (buttonDigit == 'D')
                        {
                            safe.RemoveLastDigit();
                        }
                        else
                        {
                            safe.AddDigit(buttonDigit.ToString());
                        }
                    }
                }
            }
        }
    }
}
