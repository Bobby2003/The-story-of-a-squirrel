using System.Collections; // 添加这一行
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color objectColor;

    // 用于控制渐变的时间
    public float fadeDuration = 8f;

    void Start()
    {
        // 获取物体的 Renderer 组件
        objectRenderer = GetComponent<Renderer>();
        // 获取物体的颜色
        objectColor = objectRenderer.material.color;

        // 启动协程
        StartCoroutine(FadeInOutCoroutine());
    }

    private IEnumerator FadeInOutCoroutine()
    {
        while (true) // 循环
        {
            // 渐变到透明
            yield return FadeTo(0f); // 0 表示完全透明

            // 渐变到不透明
            yield return FadeTo(1f); // 1 表示完全不透明
        }
    }

    private IEnumerator FadeTo(float targetAlpha)
    {
        float startAlpha = objectColor.a; // 获取当前 alpha 值
        float time = 0f;

        while (time < fadeDuration)
        {
            // 计算新的 alpha 值
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            objectColor.a = newAlpha; // 更新物体颜色的 alpha 值
            objectRenderer.material.color = objectColor; // 应用新颜色

            time += Time.deltaTime; // 增加经过的时间
            yield return null; // 等待下一帧
        }

        // 确保最终 alpha 值达到目标
        objectColor.a = targetAlpha;
        objectRenderer.material.color = objectColor;
    }
}
