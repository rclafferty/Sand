using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{

    [SerializeField]
    private RectTransform healthBarRect;

    [SerializeField]
    private Text healthText;

    void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {

        if (healthBarRect == null)
        {
            Debug.LogError("Status indicator: no bar");
        }


        if (healthText == null)
        {
            Debug.LogError("Status indicator: no text");
        }


    }


    public void SetHealth(int _cur, int _max)
    {
        float _value = _cur / _max;

        healthBarRect.localScale = new Vector3(_value, healthBarRect.localScale.y, healthBarRect.localScale.z);
        healthText.text = _cur + "/" + _max + " HP";
    }
    // Update is called once per frame
    void Update()
    {

    }
}
