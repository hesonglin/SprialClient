using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Proxy;
//相当于Proxy
public class MyDataProxy : Proxy
{
    public const string proxyname = "MyData01";
    public MyData myData = null;
    public MyDataProxy():base(proxyname)
    {
        myData = new MyData();
    }
    //代理模块对数据的操作
    public void addValue()
    {
        myData.dataValue++;
        SendNotification("msg_add", myData);
    }

    public void subValue()
    {
        myData.dataValue--;
        SendNotification("msg_sub", myData);
    }
}
