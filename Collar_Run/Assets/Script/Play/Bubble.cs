using UnityEngine;
using UnityEngine.UI;

public class Bubble : HitObject
{
    public int colorNum;
    GameObject player;
    public string colorName;

    void Start()
    {
        ChangeColor();
        player = GM.Instance.player;
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
            ChangeColor();
        }
    }

    public override void Action()
    {
        if (player.GetComponent<Player>().playerState == 10 || 
            player.GetComponent<Player>().playerState == colorNum)
        {
            Effect();
            player.GetComponent<Player>().HP += 20;
            Destroy(gameObject, 0.3f);
        }
    }

    public override void Effect()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    void ChangeColor()
    {
        switch (colorNum)
        {
            case 0:
                colorName = "Red";
                break;

            case 1:
                colorName = "Blue";
                break;

            case 2:
                colorName = "Yellow";
                break;

            case 3:
                colorName = "Green";
                break;
        }
        transform.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(colorName + "_" + "Bubble");
    }

}
