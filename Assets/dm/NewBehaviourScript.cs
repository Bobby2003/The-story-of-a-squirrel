using System.Collections; // �����һ��
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color objectColor;

    // ���ڿ��ƽ����ʱ��
    public float fadeDuration = 8f;

    void Start()
    {
        // ��ȡ����� Renderer ���
        objectRenderer = GetComponent<Renderer>();
        // ��ȡ�������ɫ
        objectColor = objectRenderer.material.color;

        // ����Э��
        StartCoroutine(FadeInOutCoroutine());
    }

    private IEnumerator FadeInOutCoroutine()
    {
        while (true) // ѭ��
        {
            // ���䵽͸��
            yield return FadeTo(0f); // 0 ��ʾ��ȫ͸��

            // ���䵽��͸��
            yield return FadeTo(1f); // 1 ��ʾ��ȫ��͸��
        }
    }

    private IEnumerator FadeTo(float targetAlpha)
    {
        float startAlpha = objectColor.a; // ��ȡ��ǰ alpha ֵ
        float time = 0f;

        while (time < fadeDuration)
        {
            // �����µ� alpha ֵ
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            objectColor.a = newAlpha; // ����������ɫ�� alpha ֵ
            objectRenderer.material.color = objectColor; // Ӧ������ɫ

            time += Time.deltaTime; // ���Ӿ�����ʱ��
            yield return null; // �ȴ���һ֡
        }

        // ȷ������ alpha ֵ�ﵽĿ��
        objectColor.a = targetAlpha;
        objectRenderer.material.color = objectColor;
    }
}
