using UnityEngine;
using System.Collections;

namespace SpaceShooter
{
    /// <summary>
    /// Gestisce la possibilità di sparare colpi singoli oppure a ripetizione
    /// </summary>
    public class AbilityShoot : AbstractAbility
    {
        [Header("Shoot Stats")]
        public ShootType shootType = ShootType.Single;

        [Tooltip("Intervallo di tempo tra un colpo e l'altro: utilizzato solo nel caso che la cadenza di fuoco sia settata su Auto")]
        public float fireInterval = .5f;

        public WeaponType weaponType = WeaponType.Primary;


        [Header("Spawn")]
        public Transform[] spawnPoints;

        public override void StartAbility()
        {
            if (!_isActive) return;
            
            switch(shootType)
            {
                case ShootType.Auto:
                    StartCoroutine("AutoFire");
                    break;
                default:
                    GenerateBullets();
                    break;
            }
        }

        public virtual IEnumerator AutoFire()
        {
            while(_isActive)
            {
                GenerateBullets();
                yield return new WaitForSeconds(fireInterval);
            }
        }

        protected virtual void GenerateBullets()
        {
            switch (weaponType)
            {
                case WeaponType.Primary:
                    foreach (var spawnPoint in spawnPoints)
                    {
                        if (spawnPoint.gameObject.activeInHierarchy)
                        {
                            Shoot(_data.PrimaryBullet, spawnPoint);
                        }
                    }
                    break;
                case WeaponType.Secondary:
                    foreach (var spawnPoint in spawnPoints)
                    {
                        if (spawnPoint.gameObject.activeInHierarchy)
                        {
                            Shoot(_data.SecondaryBullet, spawnPoint);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        protected virtual void Shoot(GameObject bullet, Transform spawnPoint)
        {
            bullet.transform.position = spawnPoint.position;
            bullet.transform.rotation = spawnPoint.rotation;
        }

        public override void EndAbility()
        {
            StopCoroutine("AutoFire");
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }

    public enum ShootType
    {
        Single,
        Auto
    }

    public enum WeaponType
    {
        Primary,
        Secondary
    }
}
