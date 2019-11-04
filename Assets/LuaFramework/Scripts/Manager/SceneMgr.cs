using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LuaInterface;
//hsl - 2019-10-30添加场景控制模块
namespace LuaFramework
{
  
    public class SceneMgr : Manager
    {
        private LuaFunction LuaCallBack;
        private string currentScene; 
        //1、如果去掉public,则函数不会被导出，作为私有函数
        //2、仔细观察胶水代码，会发现此处只有一个参数，但是胶水函数有两个，因此
        //在调用的时候，有两者方式：a.f(a,param)和a:f(param)
        public void LoadSceneByName(string sceneName,LuaFunction callback)
        {
            LuaCallBack = callback;
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(sceneName);
        }

        private void OnSceneLoaded(Scene scene,LoadSceneMode mode)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            currentScene = scene.name;
            if(LuaCallBack != null)
            {
                LuaCallBack.Call(scene.name);
                LuaCallBack.Dispose();
            }
        }
    }
}
