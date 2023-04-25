using UnityEngine;

public class CharacterSkinController : MonoBehaviour
{
    public int skinNr;
    public Skins[] skins;
    public int itemIndex = 0;

    private SpriteRenderer spriteRenderer;
    private string selectedSkinKey = "SelectedSkin";

    private void Start()
    {
        LoadSelectedSkin();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LoadSelectedSkin()
    {
        if (PlayerPrefs.HasKey(selectedSkinKey))
        {
            skinNr = PlayerPrefs.GetInt(selectedSkinKey);
        }
    }

    public void UpdateSkin()
    {
        if (spriteRenderer.sprite.name.Contains("Bebo"))
        {
            string spriteName = spriteRenderer.sprite.name;
            spriteName = spriteName.Replace("Bebo_", "");
            int spriteNr = int.Parse(spriteName);
            itemIndex = spriteNr;
            spriteRenderer.sprite = skins[skinNr].sprites[spriteNr];
        }
    }

    public void HideCharacter()
    {
        spriteRenderer.enabled = false;
    }
}

[System.Serializable]
public struct Skins
{
    public Sprite[] sprites;
}
