using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private Image _pausePanel;

    public void PauseGame()
    {
        _pausePanel.gameObject.SetActive(true);
        _pausePanel.DOFade(1, 1.5f);
        SetTimeScale(0);
    }
    public void ContinueGame()
    {
        _pausePanel.DOFade(0, 1.5f);
        _pausePanel.gameObject.SetActive(false);
        SetTimeScale(1);
    }
    public void RestartGame() => SceneManager.LoadScene(0);

    private async void SetTimeScale(int scale)
    {
        await Task.Delay(500);
        Time.timeScale = scale;
    }
}
