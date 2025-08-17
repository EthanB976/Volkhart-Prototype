using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource footSteps;
    public AudioSource swordSwing;
    public AudioSource swordDamage;
    public AudioSource damagePlayer;
    public AudioSource damageAlien;
    public AudioSource craftingSound;
    public AudioSource gunShooting;
    public AudioSource alienGun;
    public AudioSource alienTalking;
    public AudioSource doorOpening;
    public AudioSource grenadeSlam;
    public AudioSource grenadeExplosion;
    public AudioSource itemPickUp;
    public AudioSource movingObjects;
    public AudioSource openInventory;
    public AudioSource plateClick;
    public AudioSource techSounds;
    public AudioSource woosh;


    public void Start()
    {
        
    }
    public void FootSteps()
    {
        footSteps.Play();
    }

    public void FootStepss()
    {
        footSteps.Stop();
    }

    public void SwordSwing()
    {
        swordSwing.Play();
    }

    public void SwordDamage()
    {
        swordDamage.Play();
    }

    public void DamagePlayer()
    {
        damagePlayer.Play();
    }

    public void DamageAlien()
    {
        damageAlien.Play();
    }

    public void CraftingSound()
    {
        craftingSound.Play();
    }

    public void Gun()
    {
        gunShooting.Play();
    }

    public void AlienGun()
    {
        alienGun.Play();
    }

    public void AlienTalking()
    {
        alienTalking.Play();
    }

    public void DoorOpening()
    {
        doorOpening.Play();
    }

    public void GranadeSlam()
    {
        grenadeSlam.Play();
    }

    public void GrenadeExplosion()
    {
        grenadeExplosion.Play();
    }

    public void ItemPickUp()
    {
        itemPickUp.Play();
    }

    public void MovingObjects()
    {
        movingObjects.Play();
    }

    public void MovingObjectss()
    {
        movingObjects.Stop();
    }

    public void OpenInventory()
    {
        openInventory.Play();
    }

    public void PlateClick()
    {
        plateClick.Play();
    }

    public void TechSounds()
    {
        techSounds.Play();
    }

    public void Woosh()
    {
        woosh.Play();
    }

}
