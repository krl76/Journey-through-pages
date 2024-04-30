using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using Slider = UnityEngine.UI.Slider;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private Animator _loadingScreen;
    [SerializeField] private Slider _progressSlider;
    [SerializeField] private bool _endAnim;
    [SerializeField] private GameObject _image;
    [SerializeField] private Canvas _thisCanvas;
    [SerializeField] private GameObject _thisCanvas2;

    private float progressValue;
    
    public void EndLoadingAnimation()    { _endAnim = false; }
    
    //public void Awake() { DontDestroyOnLoad(this); }
    
    public void SceneLoad(string nameScene)
    {
        _thisCanvas2.SetActive(true);
        _thisCanvas.sortingOrder = 100;
        _image.SetActive(true);
        Time.timeScale = 1f;
        _loadingScreen.SetTrigger("StartAnim");
        _endAnim = true;
        _progressSlider.value = 0;
        StartCoroutine(LoadSceneAsync(nameScene));
    }

    private IEnumerator LoadSceneAsync(string nameScene)
    {
        while (_endAnim)
        {
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(0.1f);

        AsyncOperation loading = SceneManager.LoadSceneAsync(nameScene);
        loading.allowSceneActivation = false;

        while (loading.progress < 0.9f)
        {
            _progressSlider.value = _progressSlider.value = Mathf.Clamp01(loading.progress / 0.9f);
            _image.SetActive(true);
            yield return null;
        }

        _progressSlider.value = _progressSlider.value = Mathf.Clamp01(loading.progress / 0.9f);
        yield return new WaitForSeconds(0.1f);
        loading.allowSceneActivation = true;
        _loadingScreen.SetTrigger("EndAnim");
    }
}