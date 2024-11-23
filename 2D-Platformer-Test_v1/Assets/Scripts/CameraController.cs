using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public Transform farBG, middleBG;

    public float minHeight, maxHeight;


    private Vector2 lastposition;

    // Start is called before the first frame update
    void Start()
    {
        lastposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);

        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        Vector2 amountToMove = new Vector2(transform.position.x - lastposition.x, transform.position.y - lastposition.y);
        //float amounttoMoveX = transform.position.x - lastXposition;

        farBG.position = farBG.position + new Vector3 (amountToMove.x, amountToMove.y, 0f);
        middleBG.position += new Vector3(amountToMove.x, amountToMove.y, 0f)* 0.5f;

        lastposition = transform.position;
    }
}
