using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public char color = 'a';

    void OnEnable()
    {
        string max = Params.TestImagesCount * 2 + "";
        Text text = GetComponent<Text>();

        string max2 = Params.TestImagesCount * 2 / 3 + "";


        if (color == 'a')
            text.text = RuntimeParams.Score + "/" + max;
        if (color == 'r')
            text.text = RuntimeParams.RedScore + "/" + max2;
        if (color == 'g')
            text.text = RuntimeParams.GreenScore + "/" + max2;
        if (color == 'b')
            text.text = RuntimeParams.BlueScore + "/" + max2;
    }
}