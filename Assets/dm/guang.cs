using System.Collections; // 确保添加这一行
using UnityEngine;

public class LightningEffect : MonoBehaviour
{
    public Light sceneLight; // 场景光源
    public float flashDuration = 0.1f; // 闪电持续时间
    public float brightIntensity = 8f; // 闪电时光源强度
    public float normalIntensity = 1f; // 正常光源强度

    void Start()
    {
        // 启动闪电协程
        StartCoroutine(FlashLightning());
    }

    private IEnumerator FlashLightning()
    {
        while (true) // 循环闪电
        {
            // 使光源变亮
            sceneLight.intensity = brightIntensity;
            yield return new WaitForSeconds(flashDuration);
            // 恢复正常强度
            sceneLight.intensity = normalIntensity;
            yield return new WaitForSeconds(10f); // 闪电间隔
        }
    }
}
