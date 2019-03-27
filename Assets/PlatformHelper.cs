using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;
using Oculus.Platform.Models;

public class PlatformHelper : MonoBehaviour {
    // 自身のinstanceを生成
    private static PlatformHelper s_instance = null;

    [SerializeField]private GameObject m_remoteHead;

    private VoipHelper m_voipHelper;

    private ulong m_myID;

    private string m_myOculusID;

    private void Awake()
    {
        if(s_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        s_instance = this;
        // ??? なんで？
        DontDestroyOnLoad(gameObject);

        Core.Initialize();
        // voipインスタンス生成
        Debug.Log("voipHelper instance");
        // m_voipHelper = new VoipHelper(m_remoteHead);
    }
    // Use this for initialization
    void Start () {
        Debug.Log("start");
        // ここでコールバックまで行かずに失敗するとき、つまりLogに何も表示されずに死ぬときは、OculusPlatformでのユーザーパスワードなどが間違っている
        Entitlements.IsUserEntitledToApplication().OnComplete(IsEntitledCallback);
    }
    void IsEntitledCallback(Message msg)
    {
        Debug.Log("EntitlementCheck");
        if (msg.IsError)
        {
            Debug.Log("EntitlementCheck fail");
            return;
        }
        Debug.Log("EntitlementCheck is ok");
        // Next get the identity of the user that launched the Application.
        Users.GetLoggedInUser().OnComplete(GetLoggedInUserCallback);
    }

    void GetLoggedInUserCallback(Message<User> msg)
    {
        if (msg.IsError)
        {
            Debug.Log("Login User Callback fail");
            return;
        }

        // 自身のidなどをログイン情報から取得
        m_myID = msg.Data.ID;
        Debug.Log(m_myID);
        m_myOculusID = msg.Data.OculusID;
        // m_roomManager.CheckForLaunchInvite();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ?? ulong の idを取得
            // m_voipHelper.ConnectTo();
        }
	}
}
