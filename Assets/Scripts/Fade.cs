using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField]
    public Image whiteFade;
    // Start is called before the first frame update
    void Start()
    {
        whiteFade.canvasRenderer.SetAlpha(1.0f);

        FadeOut();
    }

    public void FadeIn()
    {
        whiteFade.CrossFadeAlpha(1, 2, false);
    }

    public void FadeOut()
    {
        whiteFade.CrossFadeAlpha(0, 2, false);
    }
}
