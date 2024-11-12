using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WooblyText : MonoBehaviour
{
    public TMP_Text textCoponent; //text component là chữ cần làm chuyển động
    void Update()
    {
        textCoponent.ForceMeshUpdate();
        var textInfo = textCoponent.textInfo;
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            var charInfo = textInfo.characterInfo[i];
            if (!charInfo.isVisible)
            {
                continue;
            }
            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;
            for (int j = 0; j < 4; j++)
            {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * 10f + orig.x * 0.01f) * 10f, 0); //Time.time*___f: thay đổi tốc độ nhanh chậm + orig.x*___f: thay đổi khoảng cách giữa các chữ
            }
        }
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            textCoponent.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
