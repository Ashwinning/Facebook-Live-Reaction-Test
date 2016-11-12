using UnityEngine;
using System.Collections;

public static class Utilities : MonoBehaviour {

    /// <summary>
    /// Returns a random vector3 between min and max. (Inclusive)
    /// </summary>
    /// <returns>The <see cref="UnityEngine.Vector3"/>.</returns>
    /// <param name="min">Minimum.</param>
    /// <param name="max">Max.</param>
    /// https://gist.github.com/Ashwinning/269f79bef5b1d6ee1f83
    static public Vector3 GetRandomVector3Between(Vector3 min, Vector3 max)
    {
        return min + Random.Range(0, 1) * (max - min);
    }

    /// <summary>
    /// Gets the random vector3 between the min and max points provided.
    /// Also uses minPadding and maxPadding (in metres).
    /// maxPadding is the padding amount to be added on the other Vector3's side.
    /// Setting minPadding and maxPadding to 0 will make it return inclusive values.
    /// </summary>
    /// <returns>The <see cref="UnityEngine.Vector3"/>.</returns>
    /// <param name="min">Minimum.</param>
    /// <param name="max">Max.</param>
    /// <param name="minPadding">Minimum padding.</param>
    /// <param name="maxPadding">Max padding.</param>
    /// https://gist.github.com/Ashwinning/269f79bef5b1d6ee1f83
    static public Vector3 GetRandomVector3Between(Vector3 min, Vector3 max, float minPadding, float maxPadding)
    {
        //minpadding as a value between 0 and 1
        float distance = Vector3.Distance(min, max);
        float minFactor;
        float maxFactor;


        if (minPadding < distance)
        {
            minFactor = minPadding / distance;
        }
        else
        {
            throw new UnityException("The minPadding value provided for GetRandomVector3Between() is greater than the distance between the two vectors.");
        }

        if (maxPadding < distance)
        {
            maxFactor = maxPadding / distance;
        }
        else
        {
            throw new UnityException("The maxPadding value provided for GetRandomVector3Between() is greater than the distance between the two vectors.");
        }

        Vector3 point1 = min + minFactor * (max - min);
        Vector3 point2 = min + maxFactor * (max - min);
        return GetRandomVector3Between(point1, point2);
    }


}
