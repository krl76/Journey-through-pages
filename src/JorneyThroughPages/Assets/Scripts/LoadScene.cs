using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Slider = UnityEngine.UI.Slider;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Slider _progressSlider;
    
    private float progressValue;

    public void SceneLoad(string nameScene)
    {
        _canvas.SetActive(true);
        StartCoroutine(LoadSceneAsync(nameScene));
    }

    private IEnumerator LoadSceneAsync(string nameScene)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(nameScene);

        while (!loadOperation.isDone)
        {
            progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            _progressSlider.value = progressValue;
            yield return null;
        }
    }
}