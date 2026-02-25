using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.Deterministic;

namespace Quantum
{
    public unsafe class MovementSystem : SystemMainThreadFilter<MovementSystem.Filter>, ISignalOnPlayerDataSet
    {
        public struct Filter
        {
            public EntityRef Entity;
            public CharacterController3D* CharacterController;
            public Transform3D* Transform3D;
            public PlayerLink* Link;
        }

        public override void Update(Frame f, ref Filter filter)
        {
            var input = f.GetPlayerInput(filter.Link->Player);

            var inputVector = new FPVector2((FP)input->DirectionX / 10, (FP)input->DirectionY / 10);

            //Anti cheat
            if (inputVector.SqrMagnitude > 1)
            {
                inputVector = inputVector.Normalized;
            }

            //Jump
            if (input->Jump.WasPressed)
            {
                filter.CharacterController->Jump(f);
            }

            //Move
            filter.CharacterController->Move(f, filter.Entity, inputVector.XOY);
        }

        public void OnPlayerDataSet(Frame f, PlayerRef player)
        {
            var data = f.GetPlayerData(player);

            // resolve the reference to the avatar prototype.
            var prototype = f.FindAsset<EntityPrototype>(data.CharacterPrototype.Id);
            var entity = f.Create(prototype);

            if (f.Unsafe.TryGetPointer<PlayerLink>(entity, out var playerLink))
            {
                playerLink->Player = player;
            }
            if (f.Unsafe.TryGetPointer<Transform3D>(entity, out var transform))
            {
                transform->Position = GetSpawnPosition(player);
            }
        }

        FPVector3 GetSpawnPosition(int playerNumber)
        {
            if (playerNumber == 0)
            {
                return new FPVector3(0, 1, 0);
            }
            else if (playerNumber == 1)
            {
                return new FPVector3(3, 1, 0);
            }
            else
            {
                return new FPVector3(-2, -2, 10);
            }
        }
    }
}
