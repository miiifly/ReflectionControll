using UnityEngine;

namespace RECON.Gameplay.Player.Data
{
    [CreateAssetMenu(fileName = "Player", menuName = "RECON/Characters/Player")]
    public class PlayerSO : ScriptableObject
    {
        [SerializeField] private PlayerGroundedData _groundedData;
        [SerializeField] private PlayerAirborneData _airborneData;

        public PlayerGroundedData GroundedData => _groundedData;
        public PlayerAirborneData AirborneData => _airborneData;
    }
}

