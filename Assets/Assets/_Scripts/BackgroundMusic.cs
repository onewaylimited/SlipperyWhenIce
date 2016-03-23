using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {

    private static BackgroundMusic instance = null;

	public static BackgroundMusic Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null)
        {
            if (this.GetComponent<AudioSource>().clip == instance.GetComponent<AudioSource>().clip)
            {
                Destroy(this.gameObject);
                return;
            }
            else
            {
                Destroy(instance.gameObject);
                instance = this;
            }
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
