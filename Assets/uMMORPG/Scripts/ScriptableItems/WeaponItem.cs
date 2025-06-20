using System.Text;
using UnityEngine;

namespace uMMORPG
{

    [CreateAssetMenu(menuName = "uMMORPG Item/Weapon", order = 999)]
    public partial class WeaponItem : EquipmentItem
    {
        [Header("Weapon")]
        public AmmoItem requiredAmmo; // null if no ammo is required

        // tooltip
        public override string ToolTip()
        {
            StringBuilder tip = new StringBuilder(base.ToolTip());
            if (requiredAmmo != null)
                tip.Replace("{REQUIREDAMMO}", requiredAmmo.name);
            return tip.ToString();
        }
    }
}