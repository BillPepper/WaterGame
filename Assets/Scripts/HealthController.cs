using UnityEngine;

public class HealthController : MonoBehaviour
{
    public PlayerController player;
    public float size;
    public float margin;
    public Sprite[] healthSprites;

    private int currentHealth;

    public void Start()
    {
        if (this.healthSprites.Length < 1)
        {
            Debug.LogError("No sprites to use for health bar");
            return;
        }

        this.currentHealth = this.player.getMaxHealth();
        Vector2 position = this.transform.position;

        for (int i = 0; i < player.getMaxHealth(); i++)
        {
            GameObject go = new GameObject("healthpoint_" + i);
            SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
            sr.sprite = this.healthSprites[this.getModuloIndex(i, this.healthSprites.Length)];
            sr.transform.localScale = new Vector2(this.size, this.size);
            sr.transform.Translate(new Vector2(position.x + i * this.margin, position.y));

            go.transform.parent = this.transform;
        }

       
    }

    public void Update()
    {
        if (this.currentHealth != player.GetHealth())
        {
            this.currentHealth = player.GetHealth();
            Destroy(GetComponent<Transform>().GetChild(this.currentHealth).gameObject);

        }
    }

    private int getModuloIndex(int value, int mod)
    {
        return value % mod;
    }
}
