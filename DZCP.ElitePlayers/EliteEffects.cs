// DZCP.ElitePlayers/EliteEffects.cs
using DZCP.API.Models;
using UnityEngine;

public static class EliteEffects
{
    public static void ApplyEliteGlow(Player player)
    {
        if (player.HasPermission("elite"))
        {
            player.SendObjectivesList();
        }
    }

    private class EliteGlow : MonoBehaviour
    {
        private Light glowLight;

        void Start()
        {
            glowLight = gameObject.AddComponent<Light>();
            glowLight.color = new Color(1f, 0.8f, 0.2f);
            glowLight.intensity = 1.5f;
            glowLight.range = 3f;
        }

        void Update()
        {
            // تأثير نبض خفيف
            glowLight.intensity = 1.5f + Mathf.Sin(Time.time * 2f) * 0.3f;
        }
    }
}
