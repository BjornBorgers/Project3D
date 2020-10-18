using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProblems
{
    void ToHeal();
    string Name();
    bool Give();
}

public class Breathing:IProblems
{
    public Breathing()
    { }

    public void ToHeal()
    {

    }

    public string Name()
    {
        return "breathing";
    }

    public bool Give()
    {
        return true;
    }
}

public class HeartStopped : IProblems
{
    public HeartStopped()
    { }

    public void ToHeal()
    {

    }

    public string Name()
    {
        return "heart";
    }

    public bool Give()
    {
        return true;
    }
}

public class BrokenLeg : IProblems
{
    public BrokenLeg()
    { }

    public void ToHeal()
    {

    }

    public string Name()
    {
        return "leg";
    }

    public bool Give()
    {
        return true;
    }
}

public class BrokenArm : IProblems
{
    public BrokenArm()
    { }

    public void ToHeal()
    {

    }

    public string Name()
    {
        return "arm";
    }

    public bool Give()
    {
        return true;
    }
}
