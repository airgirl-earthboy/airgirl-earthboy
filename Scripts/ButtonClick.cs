using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public AudioClip clickSound; // click_sound_1.mp3

    public void PlayClick()
    {
        AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position, 1f);
    }
}
