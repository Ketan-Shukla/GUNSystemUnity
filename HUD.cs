using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    [Header("Weapon HUD")]
    [SerializeField] private TextMeshProUGUI weaponNameText, weaponAmmoText;
    [SerializeField] private Image weaponThumbnail;

    public static HUD instance;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateWeaponHUD(Weapon weapon)
    {
        weaponNameText.text = weapon.weaponName;
        weaponAmmoText.text = string.Format("{0:00}/{1:00}", weapon.currentAmmo, weapon.totalAmmo);
        weaponThumbnail.sprite = weapon.weaponThumbnail;
    }

    public void UpdateAmmo(int currentAmmo, int totalAmmo)
    {
        weaponAmmoText.text = string.Format("{0:00}/{1:00}", currentAmmo, totalAmmo);
    }
}
