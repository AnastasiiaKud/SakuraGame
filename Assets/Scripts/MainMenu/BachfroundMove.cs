using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private RectTransform back_RectTransform;
    private float back_Size;

    void Start()
    {
        back_RectTransform = GetComponent<RectTransform>();
        back_Size = GetComponent<RectTransform>().sizeDelta.x;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float back_pos = back_RectTransform.anchoredPosition.x;
        back_pos += speed * Time.fixedDeltaTime;
        back_pos = Mathf.Repeat(back_pos, back_Size);
        back_RectTransform.anchoredPosition = new Vector2(back_pos, back_RectTransform.anchoredPosition.y);
    }
}





