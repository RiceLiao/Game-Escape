using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBoss : MonoBehaviour {

    public Animator anim;

    public BossState state = BossState.Normal;

    public GameObject bulletTemp;

	void Start () {
		
	}
	
	void Update () {
        int t = (int)(Time.time*1000);
        if ((t % 200) == 0)
        {
            CreateBullet();
        }
	}

    [ContextMenu("CreateBullet")]
    public void CreateBullet()
    {
        Bullet bulletGo = GameObject.Instantiate(bulletTemp).GetComponent<Bullet>();
        bulletGo.gameObject.SetActive(true);
        bulletGo.transform.position = bulletTemp.transform.position;

    }
}
