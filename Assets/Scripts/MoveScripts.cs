using UnityEngine;
using System.Collections;

public static class MoveScripts
{
    /**
     * Function for object1 to rotate to face object2
     * @param {GameObject} object1 the object that rotates
     * @param {GameObject} object2 the object to rotate to
     * @return {Quaternion} the rotation quad
     */
    public static Quaternion RotateToFace(Transform object1, Vector3 position)
    {
        Quaternion targetRotation = Quaternion.LookRotation(position - object1.position);
        var str = Mathf.Min(1 * Time.deltaTime, 1);
        return Quaternion.Lerp(object1.rotation, targetRotation, str);
    }

    public static void HideObject(GameObject obj, bool isHidden)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.enabled = !isHidden;
        }
    }
}
