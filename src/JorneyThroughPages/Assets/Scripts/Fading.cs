using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fading : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fadeText;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private string _name;
    private Tween fadeTween;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fadeText.text = _name;
            StartCoroutine(TestFade());
        }
    }

    public void FadeIn(float duration)
    {
        Fade(1f, duration, () =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        });
    }

    public void FadeOut(float duration)
    {
        Fade(0f, duration, () =>
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        });
    }

    private void Fade(float endValue, float duration, TweenCallback onEnd)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }

        fadeTween = canvasGroup.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }

    private IEnumerator TestFade()
    {
        FadeIn(2f);
        yield return new WaitForSeconds(2f);
        FadeOut(2f);
    }
}