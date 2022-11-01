using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBox : HitObject {
    bool rotation_Effect = false;
    float scaleSize = 1;
    float rotationSize = 1;

    int randomNum;
    int colorSelect;
    GameObject obj;

    void Update()
    {
        if(rotation_Effect)
        {
            rotationSize += 1000f * Time.deltaTime;

            if (scaleSize > 0)
            {
                scaleSize -= 0.5f * Time.deltaTime;
            }

            transform.rotation = Quaternion.Euler(0, 0, rotationSize);
            transform.localScale = new Vector3(scaleSize, scaleSize, 1f);
        }
    }

    public override void Action()
    {
        Effect();
        BuffRandom();
        Destroy(gameObject, 1.0f);
    }

    public override void Effect()
    {
        GetComponent<AudioSource>().Play();
        rotation_Effect = true;
    }

    void BuffRandom()
    {
        randomNum = Random.Range(0, 5);
        Debug.Log(randomNum);
        switch (randomNum)
        {
            case 0:
                GameObject.FindWithTag("Player").GetComponent<Player>().HP -= 15;
                break;
            case 1:
                GM.Instance.ColorSetting();
                break;
            case 2:
                GM.Instance.score += 2;
                break;
            case 3:
                BubbleSplash();
                break;
            case 4:
                GM.Instance.burningState = true;
                break;
        }
    }

    void BubbleSplash()
    {
        for (int i = 0; i < 5; i++)
        {
            int num = Random.Range(0, 2);
            switch (num)
            {
                case 0:
                    colorSelect = GM.Instance.left_Button;
                    break;

                case 1:
                    colorSelect = GM.Instance.right_Button;
                    break;
            }
            
            if (i < 3)
            {
                obj = Instantiate(Resources.Load<GameObject>("Bubble"), transform.position += new Vector3(-0.3f, 1, 0), transform.rotation = Quaternion.Euler(0, 0, 0)) as GameObject;
            }
            else {
                obj = Instantiate(Resources.Load<GameObject>("Bubble"), transform.position += new Vector3(-0.3f, -1, 0), transform.rotation = Quaternion.Euler(0, 0, 0)) as GameObject;
            }

            obj.GetComponent<Bubble>().colorNum = colorSelect;
        }
    }
}
