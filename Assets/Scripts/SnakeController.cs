using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeController : MonoBehaviour {

    public GameObject prefab;
    List<GameObject> bodyParts = new List<GameObject>();
    Vector3[] bodyPartLastPositions = new Vector3[0];
    float speed = 0.1f; //In Seconds. Reduce this.

	// Use this for initialization
	void Start () {
        bodyParts.Add(this.gameObject);
        StartCoroutine(Ticker());
	}
	
    IEnumerator Ticker()
    {
        while (true)
        {
            yield return new WaitForSeconds(speed);
            Move();
            
        }
    }
    
    void Append()
    {
        GameObject obj = Instantiate(prefab, bodyPartLastPositions[bodyPartLastPositions.Length - 1], Quaternion.identity) as GameObject;
        bodyParts.Add(obj);
    }

    void Move()
    {
        if (bodyPartLastPositions.Length != bodyParts.Count)
        {
            System.Array.Resize<Vector3>(ref bodyPartLastPositions, bodyParts.Count);
        }
        //Save body part positions
        for (int i = 0; i < bodyParts.Count; i++)
        {
            bodyPartLastPositions[i] = bodyParts[i].transform.position;
        }
        this.transform.position += this.transform.forward * 0.1f; //Move this forward
        //Move all the body parts to the last position of the ones ahead of them.
        for (int i = 1; i < bodyParts.Count - 1; i++)
        {
            //Starts at the second
            bodyParts[i].transform.position = bodyPartLastPositions[i-1];
        }
    }

    public void TurnLeft()
    {
        this.transform.Rotate(new Vector3(0, -90, 0));
    }

    public void TurnRight()
    {
        this.transform.Rotate(new Vector3(0, 90, 0));
    }
}
