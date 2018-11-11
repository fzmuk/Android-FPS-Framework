using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Helpers;

public class RotationClampTest
{

    [Test]
    public void ClampAngle()
    {
        float delta = 0.0005f;
        float angle;

        angle = RotationClamp.ClampAngle(20f, 40f, 50f);
        Assert.AreEqual(angle, 20f, delta, "Lower clamp angle stays the same");

        angle = RotationClamp.ClampAngle(340f, 40f, 50f);
        Assert.AreEqual(angle, 340f, delta, "Upper clamp angle stays the same");

        angle = RotationClamp.ClampAngle(60f, 40f, 50f);
        Assert.AreEqual(angle, 40f, delta, "Angle is lower than limit");

        angle = RotationClamp.ClampAngle(300f, 40f, 50f);
        Assert.AreEqual(angle, 310f, delta, "Angle is higher than limit");

        angle = RotationClamp.ClampAngle(190f, 160f, 50f);
        Assert.AreEqual(angle, 160f, delta, "Correct middle angle");
    }
}
