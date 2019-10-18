using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Mediator;
using PureMVC.Interfaces;
using UnityEngine.UI;

public class MyMediator : Mediator
{
    public const string mediatorname = "myMediator";
    public Text txtNumber;
    public Button btnAdd;
    public Button btnSub;
    public MyMediator(GameObject root) : base(mediatorname)
    {
        txtNumber = root.transform.Find("Text").GetComponent<Text>();
        btnAdd = root.transform.Find("Add").GetComponent<Button>();
        btnSub = root.transform.Find("Sub").GetComponent<Button>();

        btnAdd.onClick.AddListener(addBtn);
        btnSub.onClick.AddListener(subBtn);


    }

    //这个函数，会在mediator被注册的时候，进行调用
    //接受到什么消息
    public override string[] ListNotificationInterests()
    {
        string[] list = new string[2];
        list[0] = "msg_add";
        list[1] = "msg_sub";
        return list;
    }
    //怎么处理消息
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case "msg_add":
                display(notification.Body as MyData);
                break;
            case "msg_sub":
                display(notification.Body as MyData);
                break;
            default:break;
        }
    }

    public void display(MyData mydata)
    {
        txtNumber.text = mydata.dataValue.ToString();
    }
    public void addBtn()
    {
        SendNotification("cmd_add");
    }

    public void subBtn()
    {
        SendNotification("cmd_sub");

    }
}
