using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float xLowerLimit;
    public float xUpperLimit;
    private float speed;
    private float lifeTime;
    private float direction = 1;
    private float heightModifier;
    private int color;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1; // random this
        heightModifier = Random.Range(1.0f, 5.0f);
        GameObject ballonBody = transform.Find("Balloon Body").gameObject;
        ballonBody.GetComponent<MeshRenderer>().material = GameObject.FindObjectOfType<ColorManager>().GetMaterial(color);
        lifeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;

        float height = Mathf.Sin(lifeTime) * heightModifier;
        transform.position = transform.position + new Vector3(1 * direction, height, 0) * speed * Time.deltaTime;

        if (transform.position.x < xLowerLimit || transform.position.x > xUpperLimit)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(int direction)
    {
        this.direction = direction;
    }

    public void SetColor(int color)
    {
        this.color = color;
    }

    public int GetColor()
    {
        return color;
    }

    public void GetHit()
    {
        Destroy(gameObject);
    }
}
