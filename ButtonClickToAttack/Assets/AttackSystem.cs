using UnityEngine;
using UnityEngine.UI;

public class AttackSystem : MonoBehaviour
{
    [Header("連擊間隔時間"), Range(0, 3)]
    public float interval = 1;

    private Text textCount;
    private Text textInterval;
    private Button btnAttack;
    private int count;
    private bool canAddCount = true;
    private float timer;

    private void Awake()
    {
        textCount = GameObject.Find("連擊次數").GetComponent<Text>();
        textInterval = GameObject.Find("連擊時間").GetComponent<Text>();
        btnAttack = GameObject.Find("攻擊").GetComponent<Button>();
        btnAttack.onClick.AddListener(Attack);
    }

    private void Update()
    {
        CountTime();
    }

    private void Attack()
    {
        if (canAddCount && count < 3)
        {
            timer = 0;
            count++;
            textCount.text = "連擊段數：" + count;
        }
    }

    private void CountTime()
    {
        if (count >= 0)
        {
            if (timer <= interval)
            {
                timer += Time.deltaTime;
                canAddCount = true;
            }
            else
            {
                timer = 0;
                count = 0;
                canAddCount = false;
                textCount.text = "連擊段數：" + count;
            }

            textInterval.text = "連擊時間：" + timer.ToString("F2");
        }
    }
}
