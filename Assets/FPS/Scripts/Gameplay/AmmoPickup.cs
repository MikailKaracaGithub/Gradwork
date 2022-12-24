using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class AmmoPickup : Pickup
    {
        [Tooltip("Weapon those bullets are for")]
        public WeaponController Weapon;

        [Tooltip("Number of bullets the player gets")]
        public int BulletCount = 30;

        [Tooltip("1 = Blaster | 2 = Railgun | 3 = Shotgun")]
        public int WeaponIndex = 0;
        protected override void OnPicked(PlayerCharacterController byPlayer)
        {
            PlayerWeaponsManager playerWeaponsManager = byPlayer.GetComponent<PlayerWeaponsManager>();
            if (playerWeaponsManager)
            {
                WeaponController weapon = playerWeaponsManager.GetWeaponAtSlotIndex(WeaponIndex); // MKL 
                if (weapon != null)
                {
                    weapon.ReloadAmmo();//mkl

                    //weapon.AddCarriablePhysicalBullets(BulletCount);
                    AmmoPickupEvent evt = Events.AmmoPickupEvent;
                    evt.Weapon = weapon;
                    EventManager.Broadcast(evt);

                    PlayPickupFeedback();
                    Destroy(gameObject);
                }
            }
        }
    }
}
