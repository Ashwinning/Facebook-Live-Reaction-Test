using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeController : MonoBehaviour {

    public GameObject prefab;
    List<GameObject> bodyParts = new List<GameObject>();
    List<Vector3> bodyPartLastPositions = new List<Vector3>();
    float speed = 1; //In Seconds. Reduce this.

	// Use this for initialization
	void Start () {
        StartCoroutine(Ticker());
	}
	
	// Update is called once per frame
	void Update () {
	
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
        GameObject obj = Instantiate(prefab, bodyParts[bodyParts.Count].transform.forward * -0.1f, Quaternion.identity) as GameObject;
        bodyParts.Add(obj);
    }

    void Move()
    {
        Debug.Log("move");
        //Save body part positions
        for (int i = 0; i < bodyParts.Count; i++)
        {
            bodyPartLastPositions[i] = bodyParts[i].transform.position;
        }
        this.transform.position += this.transform.forward * 0.1f; //Move this forward
        //Move all the body parts to the last position of the ones ahead of them.
        for (int i = 1; i < bodyParts.Count; i++)
        {
            //Starts at the second
            bodyParts[i].transform.position = bodyPartLastPositions[i - 1];
        } 
    }
}
