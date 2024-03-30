using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private PlayerInfo[] AllPlayerInfo;

    private void OnEnable()
    {

        Invoke(nameof(AddNewPlayers),1); //This should not be an invoke, consider a better way of deploying these objects so that it happens at the correct time.

    }

    private void AddNewPlayers()
    {

        for(int i = 0; i < AllPlayerInfo.Length; i++)
        {

            //We need to instantiate a player for its ID instead of simply sending off the player info here I think...
            Actions.OnAddNewPlayer.InvokeAction(AllPlayerInfo[i]);

        }

    }

}
