using UnityEngine;
using UnityEngine.UI;

public class PlayButton: MonoBehaviour {
    
    public bool rightButton;
	public int state;
    
    string direction;
    string myColor;

	void Update () {
        
        if(rightButton)
        {
            state = GM.Instance.right_Button;
            direction = "Right";
        }
        else
        {
            state = GM.Instance.left_Button;
            direction = "Left";
        }

        switch(state)
        {
            case 0:
                myColor = "Red";
                break;

            case 1:
                myColor = "Blue";
                break;

            case 2:
                myColor = "Yellow";
                break;

            case 3:
                myColor = "Green";
                break;
        }

        transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(direction + "_" + myColor);
    }

    public void button_Click()
    {
        GM.Instance.player.GetComponent<Player>().playerState = state;
        GM.Instance.player.GetComponent<Player>().ImageLoad();
    }
}
