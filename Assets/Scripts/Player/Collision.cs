using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class Collision : MonoBehaviour
{
    [SerializeField] private ParticleSystem _win, _lose;
    [SerializeField] Image _shield;
    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Target>()) StartCoroutine(Win());

        else if (other.GetComponent<DeadZone>()) StartCoroutine(Lose());
    }

    private IEnumerator Win()
    {
        _win.Play();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
    private IEnumerator Lose()
    {
        _lose.Play();
        yield return new WaitForSeconds(0.5f);
        _shield.fillAmount = 1;
        transform.position = _startPosition;
    }
}
