using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

public class Main : MonoBehaviour
{
    private LuaState lua = null;

    private LuaFunction luaFunc = null;
    // Start is called before the first frame update
    void Start()
    {
        new LuaResLoader();
        lua = new LuaState();
        lua.Start();
        LuaBinder.Bind(lua);
        lua.DoFile("Controller.lua");

        CallLuaFunc("Controller.start");
    }

    // Update is called once per frame
    void Update()
    {
        CallLuaFunc("Controller.update");
    }

    private void CallLuaFunc(string func)
    {
        luaFunc = lua.GetFunction(func);
        luaFunc.Call();

    }
}
