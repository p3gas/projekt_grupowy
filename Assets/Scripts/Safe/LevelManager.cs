using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Safe
{
    public class LevelManager : MonoBehaviour
    {
        public string correctCode;
        public int numberOfDigits = 4;
        public Block[] blocks;

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < numberOfDigits; i++)
            {
                int digit = Random.Range(0, 10);
                correctCode += digit;
                blocks[i].LightWindows(digit);
            }

            Safe safe = GameObject.FindObjectOfType<Safe>();
            safe.SetCorrectCode(correctCode);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}