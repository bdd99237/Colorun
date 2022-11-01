using UnityEngine;
using System.Collections;

public class BGImage : MonoBehaviour 
{
    [SerializeField]
    float speed;
    Vector3 move;

	void Start () 
	{
        speed = GM.Instance.speed;
    }
	
	void Update () 
	{
        move = new Vector3(Time.deltaTime * speed, 0, 0);
        transform.position -= move;
	}
}
