using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroDirector : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string introEvent;
    public GameObject music;

    public Fader firstFader;
    public Fader secondFader;
    public Fader thirdFader;

    public float zeroTileDuration = 5f;
    public float firstTileDuration;
    public float secondTileDuration;
    public float thirdTileDuration;

    public SceneLoader loader;
    public GameObject introCanvas;

    private FMOD.Studio.EventInstance soundInstance;

    private IEnumerator ThirdScene()
    {
        thirdFader.FadeOut();
        yield return new WaitForSeconds(thirdTileDuration);
        loader.LoadLevel();
    }

    private IEnumerator SecondScene()
    {
        secondFader.FadeOut();
        yield return new WaitForSeconds(secondTileDuration);
        StartCoroutine(ThirdScene());
    }

    private IEnumerator FirstScene()
    {
        music.SetActive(false);
        introCanvas.SetActive(true);
        soundInstance = FMODUnity.RuntimeManager.CreateInstance(introEvent);
        soundInstance.start();
        yield return new WaitForSeconds(zeroTileDuration);
        firstFader.FadeOut();
        yield return new WaitForSeconds(firstTileDuration);
        StartCoroutine(SecondScene());
    }

    public void StopIntro()
    {
        StopAllCoroutines();
        soundInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        soundInstance.release();
    }

    public void StartIntro() => StartCoroutine(FirstScene());
}
