using System.Collections; // ȷ�������һ��
using UnityEngine;

public class LightningEffect : MonoBehaviour
{
    public Light sceneLight; // ������Դ
    public float flashDuration = 0.1f; // �������ʱ��
    public float brightIntensity = 8f; // ����ʱ��Դǿ��
    public float normalIntensity = 1f; // ������Դǿ��

    void Start()
    {
        // ��������Э��
        StartCoroutine(FlashLightning());
    }

    private IEnumerator FlashLightning()
    {
        while (true) // ѭ������
        {
            // ʹ��Դ����
            sceneLight.intensity = brightIntensity;
            yield return new WaitForSeconds(flashDuration);
            // �ָ�����ǿ��
            sceneLight.intensity = normalIntensity;
            yield return new WaitForSeconds(10f); // ������
        }
    }
}
