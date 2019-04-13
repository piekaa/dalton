using UnityEngine;
using UnityEngine.UI;

public class OffroadText : MonoBehaviour
{
    [SerializeField] private string goodScoreText;
    [SerializeField] private string badScoreText;

    [SerializeField] private char color = 'a';

    private void OnEnable()
    {
        var max = Params.TestImagesCount * 2;
        var text = GetComponent<Text>();

        if (RuntimeParams.Score * 2 >= max)
        {
            text.text = goodScoreText;
        }
        else
        {
            text.text = badScoreText;
        }
    }
}