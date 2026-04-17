using UnityEngine;

public class FogTile : MonoBehaviour
{
    public bool revealed = false;
    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Reveal()
    {
        if (revealed) return;

        revealed = true;
        gameObject.SetActive(false); // hoặc fade nếu muốn đẹp hơn
    }
}