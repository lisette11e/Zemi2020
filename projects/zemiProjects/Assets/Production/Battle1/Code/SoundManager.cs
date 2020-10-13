using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMonoBehaviour<SoundManager> {
    [SerializeField, Range (0, 1), Tooltip ("マスタ音量")]
    float volume = 1;
    [SerializeField, Range (0, 1), Tooltip ("SEの音量")]
    float seVolume = 1;

    AudioClip[] se;

    Dictionary<string, int> seIndex = new Dictionary<string, int> ();
    AudioSource seAudioSource;

    public float Volume {
        set {
            volume = Mathf.Clamp01 (value);
            seAudioSource.volume = seVolume * volume;
        }
        get {
            return volume;
        }
    }

    public float SeVolume {
        set {
            seVolume = Mathf.Clamp01 (value);
            seAudioSource.volume = seVolume * volume;
        }
        get {
            return seVolume;
        }
    }

    void Start () {
        if (this != Instance) {
            Destroy (gameObject);
            return;
        }

        DontDestroyOnLoad (gameObject);
        seAudioSource = gameObject.AddComponent<AudioSource> ();
        se = Resources.LoadAll<AudioClip> ("Audio/SE");
        for (int i = 0; i < se.Length; i++) {
            seIndex.Add (se[i].name, i);
        }
    }

    public int GetSeIndex (string name) {
        if (seIndex.ContainsKey (name)) {
            return seIndex[name];
        } else {
            Debug.LogError ("指定された名前のSEファイルが存在しません。");
            return 0;
        }
    }

    //SE再生
    public void PlaySe (int index) {
        index = Mathf.Clamp (index, 0, se.Length);

        seAudioSource.PlayOneShot (se[index], SeVolume * Volume);
    }

    public void PlaySeByName (string name) {
        PlaySe (GetSeIndex (name));
    }

    public void StopSe () {
        seAudioSource.Stop ();
        seAudioSource.clip = null;
    }

}