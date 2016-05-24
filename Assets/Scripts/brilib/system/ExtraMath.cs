using UnityEngine;

public static class ExtraMath
{
    // Get the progress of 'input' from 'min' towards 'max'. Results are
    // unbounded.
    public static float Ratio(float input, float min, float max)
    {
        float numerator = input - min;
        float denominator = max - min;
        return numerator / denominator;
    }

    // Get the progress of 'input' from 'min' towards 'max' as a percentage in
    // [0,1].
    public static float ProgressBoundAsPercent(float input, float min, float max)
    {
        return Mathf.Clamp01(Ratio(input, min, max));
    }

    // Get the progress of 'input' from 0 towards 'max' as an offset in
    // [-1,1].
    public static float ProgressBoundAroundZero(float input, float max)
    {
        // Get progress in [0,1].
        float progress = Ratio(input, -max, max);
        // Translate into [-1,1].
        progress = (progress * 2.0f) - 1.0f;
        return Mathf.Clamp(progress, -1.0f, 1.0f);
    }

}
