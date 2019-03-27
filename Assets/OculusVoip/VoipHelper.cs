using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Oculus.Platform;
using Oculus.Platform.Models;

public class VoipHelper {
    // voipを接続したいユーザーのID
    private ulong m_remoteId;

    // voipの接続状態
    private PeerConnectionState m_state = PeerConnectionState.Unknown;

    private readonly GameObject m_remoteHead;

    public VoipHelper(GameObject remoteHead)
    {
        m_remoteHead = remoteHead;

        Voip.SetVoipConnectRequestCallback(VoipConnectRequestCallback);
        Voip.SetVoipStateChangeCallback(VoipStateChangeCallback);
    }

    void VoipConnectRequestCallback(Message<NetworkingPeer> message)
    {
        // message.Data.ID : Voip.Startなどで接続要求してきたID
        // m_remoteId : ？？どこで代入している？
        Debug.LogFormat("Voip request from {0}, authorized is {1}", message.Data.ID, m_remoteId);

        if(message.Data.ID == m_remoteId)
        {
            // Voipの接続要求を承認する
            Voip.Accept(message.Data.ID);
        }
    }

    // Voipの接続要求を出すメソッド
    public void ConnectTo(ulong userId)
    {
        m_remoteId = userId;
        
        // m_remoteHeadにVoipAudioSourceHitLevelをアタッチ
        var audioSource = m_remoteHead.AddComponent<VoipAudioSourceHiLevel>();

        // 接続したいユーザーのIDをsenderIDとして登録
        audioSource.senderID = userId;

        // 自分のIDと異なる事を確認
        if (PlatformManager.MyID < m_remoteId)
        {
            Voip.Start(userId);
        }
    }

    // 接続状態が変わった時に発火されるコールバック
    void VoipStateChangeCallback(Message<NetworkingPeer> message)
    {

    }
}
