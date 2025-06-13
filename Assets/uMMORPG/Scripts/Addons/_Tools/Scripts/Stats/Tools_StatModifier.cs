using UnityEngine;

namespace uMMORPG
{
    
    // STAT MODIFIER
    [System.Serializable]
    public class Tools_StatModifier
    {
    
    #if _iMMOATTRIBUTES
        [Header("[-=-[ ATTRIBUTE MODIFIERS ]-=-]")]
        public Tools_AttributeModifier[] AttributeModifiers = { };
    #endif
    #if _iMMOELEMENTS
        [Header("[-=-[ ELEMENTAL RESISTANCES ]-=-]")]
        public ElementModifier[] elementalResistances;
    #endif
    
        [Header("[-=-[ MAIN STAT MODIFIERS ]-=-]")]
        public int healthBonus;
        public int manaBonus;
    #if _iMMOSTAMINA
        public int staminaBonus;
    #endif
        public int damageBonus;
        public int defenseBonus;
    
        [Header("[-=-[ SECONDARY STAT MODIFIERS ]-=-]")]
        public float blockChanceBonus;
        public float criticalChanceBonus;
    #if _iMMOATTRIBUTES
        public float bonusBlockFactor;
        public float bonusCriticalFactor;
        public float bonusDrainHealthFactor;
        public float bonusDrainManaFactor;
        public float bonusReflectDamageFactor;
        public float bonusDefenseBreakFactor;
        public float bonusBlockBreakFactor;
        public float bonusCriticalEvasion;
        public float bonusAccuracy;
        public float bonusResistance;
        public float bonusAbsorbHealthFactor;
        public float bonusAbsorbManaFactor;
    #endif
    
        // -----------------------------------------------------------------------------------
        // hasModifier
        // -----------------------------------------------------------------------------------
        public bool hasModifier
        {
            get
            {
                return
                        (
    #if _iMMOATTRIBUTES
                        (AttributeModifiers != null && AttributeModifiers.Length > 0) ||
    #endif
    #if _iMMOELEMENTS
                        (elementalResistances != null && elementalResistances.Length > 0) ||
    #endif
    #if _iMMOATTRIBUTES
                        bonusBlockFactor != 0 ||
                        bonusCriticalFactor != 0 ||
                        bonusDrainHealthFactor != 0 ||
                        bonusDrainManaFactor != 0 ||
                        bonusReflectDamageFactor != 0 ||
                        bonusDefenseBreakFactor != 0 ||
                        bonusBlockBreakFactor != 0 ||
                        bonusCriticalEvasion != 0 ||
                        bonusAccuracy != 0 ||
                        bonusResistance != 0 ||
                        bonusAbsorbHealthFactor != 0 ||
                        bonusAbsorbManaFactor != 0 ||
    #endif
                        healthBonus != 0 ||
                        manaBonus != 0 ||
    #if _iMMOSTAMINA
                        staminaBonus != 0 ||
    #endif
                        damageBonus != 0 ||
                        defenseBonus != 0 ||
                        blockChanceBonus != 0 ||
                        criticalChanceBonus != 0
                        );
            }
        }
    
        // -----------------------------------------------------------------------------------
    }
    
}
