using UnityEngine;

public class ExtendedMonoBehaviour : MonoBehaviour {
 protected TextMesh[] InitiateIntel(int textIntelCount, TextMesh[] textIntels)
    {
        float uiScale = 0.2f;

        GameObject go = new GameObject();
        go.name = "Intel";
        go.transform.position = transform.position;

        textIntels = new TextMesh[textIntelCount];

        for (int i = 0; i < textIntels.Length; i++)
        {
            textIntels[i] = new GameObject().AddComponent<TextMesh>();
            textIntels[i].gameObject.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
            textIntels[i].gameObject.transform.position = gameObject.transform.position + Vector3.up * uiScale + Vector3.down * uiScale * i + Vector3.left * uiScale;
            textIntels[i].gameObject.transform.parent = go.transform;
        }

        go.transform.parent = transform;
        
        return textIntels;
    }
}
