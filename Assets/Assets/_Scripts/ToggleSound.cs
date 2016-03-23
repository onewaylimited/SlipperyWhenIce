using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleSound : MonoBehaviour {
	Text text;
    bool sound = true;

	void Start()
	{
		text = gameObject.GetComponentInChildren<Text>();
		setSound(sound);
	}

	public void toggleSound()
    {
        sound = !sound;
		setSound(sound);
    }

	void setSound(bool soundOn)
	{
		if(sound)
		{
			text.text = "Sound: On";
			BackgroundMusic.Instance.gameObject.SetActive(true);
		}
		else
		{
			text.text = "Sound: Off";
			BackgroundMusic.Instance.gameObject.SetActive(false);
		}
	}
}
