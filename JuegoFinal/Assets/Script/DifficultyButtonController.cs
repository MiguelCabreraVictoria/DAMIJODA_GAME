using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonController : MonoBehaviour
{
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    public Sprite easyColor;
    public Sprite mediumColor;
    public Sprite hardColor;

    public Sprite easyGrayscale;
    public Sprite mediumGrayscale;
    public Sprite hardGrayscale;

    private void Start()
    {
        // Carga la dificultad almacenada en PlayerPrefs, si no existe, utiliza "Medium" como valor predeterminado
        // string selectedDifficulty = PlayerPrefs.GetString("Difficulty", "Medium");

        // Establece la dificultad y actualiza la apariencia de los botones
        SetDifficulty("");
    }

    public void SetDifficulty(string difficulty)
    {
        PlayerPrefs.SetString("Difficulty", difficulty);
        UpdateButtonAppearance(difficulty);
    }

    private void UpdateButtonAppearance(string selectedDifficulty)
    {
        easyButton.image.sprite = selectedDifficulty == "Easy" ? easyColor : easyGrayscale;
        mediumButton.image.sprite = selectedDifficulty == "Medium" ? mediumColor : mediumGrayscale;
        hardButton.image.sprite = selectedDifficulty == "Hard" ? hardColor : hardGrayscale;
    }
}
