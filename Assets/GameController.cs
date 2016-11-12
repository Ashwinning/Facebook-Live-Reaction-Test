using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject poop;
    public GameObject cookie;
    public GameObject player;
    private SnakeController snakeController;
    public Camera camera;

    //Edges
    private Vector3 bottomLeft;
    private Vector3 bottomRight;
    private Vector3 topLeft;
    private Vector3 topRight;

    // Use this for initialization
    void Start () {
        snakeController = player.GetComponent<SnakeController>();
        GetEdges();
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetEdges();
        KeyboardControls();
        Teleporter();
    }

    private void KeyboardControls()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            snakeController.TurnLeft();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            snakeController.TurnRight();
        }
    }

    void GetEdges()
    {
       bottomLeft = RaycastToWorld(0, 0);
       bottomRight = RaycastToWorld(camera.pixelWidth, 0);
       topLeft = RaycastToWorld(0, camera.pixelHeight);
       topRight = RaycastToWorld(camera.pixelWidth, camera.pixelHeight);
    }

    //Teleports snake head to the other side when player hits the edge
    void Teleporter()
    {
        //Top Edge
        if (player.transform.position.z > topLeft.z && player.transform.forward == transform.forward)
        {
            //Send to bottom
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, bottomRight.z)
        }
        //Bottom Edge
        if (player.transform.position.z < bottomLeft.z && player.transform.forward == -transform.forward)
        {
            //Send to top
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, topRight.z);
        }
        //Left Edge
        if (player.transform.position.x < bottomLeft.x && player.transform.forward == -transform.right)
        {
            //Send to right
            player.transform.position = new Vector3(bottomRight.x, player.transform.position.y, player.transform.position.z);
        }
        //Right Edge
        if (player.transform.position.x > bottomRight.x && player.transform.forward == transform.right)
        {
            //Send to left
            player.transform.position = new Vector3(bottomLeft.x, player.transform.position.y, player.transform.position.z);
        }
    }


    Vector3 RaycastToWorld(float x, float y)
    {
        return camera.ScreenToWorldPoint(new Vector3(x, y, camera.transform.position.y));
    }
}
