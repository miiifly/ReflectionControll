using System;
using UnityEngine;

namespace RECON.Gameplay.Player.Data
{
    [Serializable]
    public class PlayerLayerData
    {
        [SerializeField]
        private LayerMask _gorundLayer;
        [SerializeField]
        private LayerMask _ballLayer;

        private bool ContainsLayer(LayerMask layerMask,int layer)
        {
            return (1 << layer & layerMask) != 0;
        }

        public bool IsGroundLayer(int layer)
        {
            return ContainsLayer(_gorundLayer, layer);
        }

        public bool IsBallLayer(int layer)
        {
            return ContainsLayer(_ballLayer,layer);
        }

        public LayerMask GroundLayer => _gorundLayer;
        public LayerMask BallLayer => _ballLayer;
    }
}
