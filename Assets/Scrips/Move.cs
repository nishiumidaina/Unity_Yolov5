using UnityEngine;

public class Move : MonoBehaviour
{
    /// <summary>
    /// X軸を基点に回転する速さ
    /// </summary>
    [SerializeField]
    private float rotAngleX = 2.0f;

    /// <summary>
    /// Y軸を基点に回転する速さ
    /// </summary>
    [SerializeField]
    private float rotAngleY = 2.0f;

    /// <summary>
    /// Z軸を基点に回転する速さ
    /// </summary>
    [SerializeField]
    private float rotAngleZ = 2.0f;

    // Update is called once per frame
    void Update()
    {
        // フレームごとに回転させる
        transform.Rotate(rotAngleX, rotAngleY, rotAngleZ);
    }
}
