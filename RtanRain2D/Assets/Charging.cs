using UnityEngine;
using UnityEngine.UI;
using RtanMetaverse;
namespace RtanMetaverse
{
    public class Charging : MonoBehaviour
    {
        private Image energeBar;
        private RtanSurf rtanSurf;
        private void Awake()
        {
            energeBar = GetComponent<Image>();
            rtanSurf = FindAnyObjectByType<RtanSurf>();
        }
        void Update()
        { energeBar.fillAmount = rtanSurf.RtanJumping / 8f; }
    }
}
