using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpon : MonoBehaviour {

    public GameObject[] air;
    public GameObject[] floor;
    public GameObject crayon;
    public GameObject bubble;

   public float airTime;
    public float airTimeSave;
    public float floorTime;
    public float floorTimeSave;
    public float crayonTime;
    public float crayonTimeSave;
    public float bubbleTime;
    public float bubbleTimeSave;

    private void Start()
    {
        airTime = 3.0f;
        airTimeSave = 0f;
        floorTime = 5.0f;
        floorTimeSave = 0f;
        crayonTime = 1.0f;
        crayonTimeSave = 0f;
        bubbleTime = 1.0f;
        bubbleTimeSave = 0f;


        air = Resources.LoadAll<GameObject>("Air");
        floor = Resources.LoadAll<GameObject>("Floor");
        crayon = Resources.Load<GameObject>("Crayon");
        bubble = Resources.Load<GameObject>("Bubble");
    }

    private void Update()
    {
        airTimeSave += Time.deltaTime * (GM.Instance.speed * 0.25f);
        floorTimeSave += Time.deltaTime * (GM.Instance.speed * 0.25f);
        crayonTimeSave += Time.deltaTime * (GM.Instance.speed * 0.25f);
        bubbleTimeSave += Time.deltaTime * (GM.Instance.speed * 0.25f);

        CreateAir();
        CreateFloor();
        CreateCrayon();
        CreateBubble();
    }

    void CreateAir()
    {
        if(airTimeSave >= airTime)
        {
            airTimeSave = 0f;
            airTime = Random.Range(2.0f, 3.0f);
            int modelRandom = Random.Range(0, air.Length);
            Instantiate(air[modelRandom], new Vector2(Random.Range(3.0f, 7.0f), Random.Range(4.5f, 7.0f)), Quaternion.identity);
        }
    }

    void CreateFloor()
    {
        if (floorTimeSave >= floorTime)
        {
            floorTimeSave = 0f;
            floorTime = Random.Range(3.5f, 5.0f);
            int modelRandom = Random.Range(0, floor.Length);
            Instantiate(floor[modelRandom], new Vector2(Random.Range(3.0f, 7.0f), 3.1f), Quaternion.identity);
        }
    }

    void CreateCrayon()
    {
        if (crayonTimeSave >= crayonTime)
        {
            crayonTimeSave = 0f;
            crayonTime = Random.Range(1.0f, 3.0f);
            GameObject obj = Instantiate(crayon, new Vector2(Random.Range(3.0f, 7.0f), 3.1f), Quaternion.identity);
            obj.GetComponent<Crayon>().colorNum = ColorSelect();
        }
    }

    void CreateBubble()
    {
        if (bubbleTimeSave >= bubbleTime)
        {
            bubbleTimeSave = 0f;
            bubbleTime = Random.Range(5.0f, 7.0f);
            GameObject obj = Instantiate(bubble, new Vector2(Random.Range(3.0f, 7.0f), Random.Range(4.5f, 7.0f)), Quaternion.identity);
            obj.GetComponent<Bubble>().colorNum = ColorSelect();
        }
    }

    int ColorSelect()
    {
        int returnColor;

        int colorRandom = Random.Range(0, 2);
        if(colorRandom == 0)
        {
            returnColor = GM.Instance.left_Button;
        }
        else
        {
            returnColor = GM.Instance.right_Button;
        }

        return returnColor;
    }
}
