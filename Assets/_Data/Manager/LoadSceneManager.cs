using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MySingleton<LoadSceneManager>
{
    public enum Scene
    {
        MenuScene,
        LoadingScene,
        GameScene
    }
    private Scene _nextScene;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene("LoadingScene");
        this._nextScene = scene;
        Invoke(nameof(this.Callback), 1f);
        this.Callback();
    }
    private void Callback()
    {
       SceneManager.LoadScene(_nextScene.ToString());
    }
}
