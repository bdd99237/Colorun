using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crayon : HitObject {
    GameObject player;
    bool touch;
    public int colorNum;

    int aniNum;
    string aniString;
    List<Sprite> crayonImage = new List<Sprite>();

    float deleteTime;
    float saveTime;

    private void Start()
    {
        player = GM.Instance.player;
        touch = false;
        aniNum = 0;

        deleteTime = 0.5f;
        saveTime = 0;

        SettingColor();
    }

    private void Update()
    {
        if (colorNum != GM.Instance.left_Button && colorNum != GM.Instance.right_Button)
        {
            int colorSet = Random.Range(0, 2);
            switch (colorSet)
            {
                case 0:
                    colorNum = GM.Instance.left_Button;
                    break;
                case 1:
                    colorNum = GM.Instance.right_Button;
                    break;
            }
            SettingColor();
        }

        if (touch)
        {
            Boom();
        }
    }

    public override void Action()
    {
        if (player.GetComponent<Player>().playerState == 10 ||
            player.GetComponent<Player>().playerState == colorNum)
        {
            Effect();
            touch = true;
            GM.Instance.speed += 0.2f;
            if (GM.Instance.burningNum < 5)
            {
                GM.Instance.burningNum += 1;
            }
        }
        else
        {
            GM.Instance.speed -= 0.1f;
            if(player.GetComponent<Player>().HP > 0)
            {
                player.GetComponent<Player>().HP -= 10;
            }
        }
    }

    public override void Effect()
    {
        transform.GetComponent<AudioSource>().Play();
    }

    void SettingColor()
    {
        switch (colorNum)
        {
            case 0:
                aniString = "Red";
                break;

            case 1:
                aniString = "Blue";
                break;

            case 2:
                aniString = "Yellow";
                break;

            case 3:
                aniString = "Green";
                break;
        }

        Sprite[] imageLoad = Resources.LoadAll<Sprite>("Crayon_" + aniString);
        crayonImage.Clear();
        crayonImage.AddRange(imageLoad);
        transform.GetComponent<SpriteRenderer>().sprite = crayonImage[aniNum];
    }

    void Boom()
    {
        saveTime += Time.deltaTime;

        if(saveTime > deleteTime/crayonImage.Count)
        {
            saveTime = 0;
            aniNum += 1;
            transform.GetComponent<SpriteRenderer>().sprite = crayonImage[aniNum];
        }

        if(aniNum >= crayonImage.Count-1)
        {
            Destroy(gameObject);
        }
    }
}
