using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGStart : MonoBehaviour
{

    public Button bt;

    public GameObject caremObject;
    public GameObject animationCG;
    public GameObject cg;
    private void Start()
    {
        if(bt != null)
        {
            bt.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                caremObject.GetComponent<Animator>().enabled = true;
                animationCG.SetActive(true);
                cg.SetActive(true);
            });
        }

    }

}
