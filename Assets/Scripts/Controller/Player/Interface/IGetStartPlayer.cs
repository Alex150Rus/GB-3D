using SpaceJailRunner.Data;
using UnityEngine;

namespace SpaceJailRunner.Controller.Player.Interface
{
    internal interface IGetStartPlayer
    {
        public Transform GetPlayer(PlayerData playerData, int sceneNumber);
    }
}