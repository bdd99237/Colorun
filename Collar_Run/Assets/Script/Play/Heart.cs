using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : HitObject
{

    public override void Action()
    {
        Effect();
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().HP = player.GetComponent<Player>().maxHP;
        Destroy(gameObject, 0.5f);
    }

    public override void Effect()
    {
        GetComponent<Animator>().SetBool("touch_on", true);
        GetComponent<AudioSource>().Play();
    }
}
