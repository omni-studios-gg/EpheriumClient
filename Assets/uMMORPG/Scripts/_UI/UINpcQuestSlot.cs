﻿// Attach to the prefab for easier component access by the UI Scripts.
// Otherwise we would need slot.GetChild(0).GetComponentInChildren<Text> etc.
using UnityEngine;
using UnityEngine.UI;

namespace uMMORPG
{
    public class UINpcQuestSlot : MonoBehaviour
    {
        public Text descriptionText;
        public Button actionButton;
    }
}