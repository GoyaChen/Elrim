using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbarController : MonoBehaviour
{
    public Scrollbar HP_bar;
    public GameObject unitBattler;
    public float xOffset, yOffset;

    private Vector2 player2DPosition;
    private float HP;
    private float Max_HP;
    private BattleController battleController;
    // Start is called before the first frame update
    void Start()
    {
        HP_bar.size = 1;
        battleController = unitBattler.GetComponent<BattleController>();
    }

    // Update is called once per frame
    void Update()
    {
        Max_HP = battleController.Max_HP;
        HP = battleController.HP;
        player2DPosition = Camera.main.WorldToScreenPoint(transform.position);
        HP_bar.transform.position = player2DPosition + new Vector2(xOffset, xOffset);
        HP_bar.size = (HP <= 0 ? 0 : HP) / Max_HP;
    }
}
