using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ilandMover : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    private GameObject parent;
    private Vector3 parentPos;
    private float distanse = 0;
    public Vector3 targetToDie;
    public Vector3 ofset;

    void Start()
    {
        parent = this.gameObject.transform.parent.gameObject;
        distanse = Vector3.Distance(parent.gameObject.transform.position, this.transform.position);
        targetToDie = parent.gameObject.transform.position - this.transform.position - this.transform.position + ofset;
        this.transform.localPosition = this.transform.localPosition + ofset;
        transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
    }

    // Update is called once per frame
    void Update()
    {
        distanse = Vector3.Distance(targetToDie, this.transform.position);
        if (distanse >= 10)
        {
            float step = moveSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetToDie, step);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
