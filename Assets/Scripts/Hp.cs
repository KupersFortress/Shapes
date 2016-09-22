using UnityEngine;
using System.Collections;

public class Hp : MonoBehaviour
{
    public static Hp hpComponent;
    [SerializeField]
    GameObject hpImagePrefab;
    [SerializeField]
    int baseHp;
    int hp;
    GameObject[] hpImage;
    int tos;

    void Awake()
    {
        hpComponent = this;
        hp = baseHp;
    }

    void Start()
    {
        hpImage = new GameObject[baseHp];
        tos = baseHp-1;
        for (int i = 0; i < baseHp; i++)
        {
            hpImage[i]=(GameObject)Instantiate(hpImagePrefab);
            hpImage[i].transform.SetParent(transform);
        }
    }

    public void LoseHp()
    {
        if (hp > 0)
        {
            hpImage[tos].SetActive(false);
            hp--;
            tos--;
        }
        if (hp<=0)
        {
            MainController.mainController.LoseGame();
        }
    }
}
