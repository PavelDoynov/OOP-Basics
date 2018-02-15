using System;

public class Tyres
{
    double tyrePressure1;
    int tyreAge1;
    double tyrePressure2;
    int tyreAge2;
    double tyrePressure3;
    int tyreAge3;
    double tyrePressure4;
    int tyreAge4;

    public void GetTyres (string tp1, string ta1, string tp2, string ta2, string tp3
                          , string ta3, string tp4, string ta4)
    {
        this.TyrePressure1 = double.Parse(tp1);
        this.TyreAge1 = int.Parse(ta1);
        this.TyrePressure2 = double.Parse(tp2);
        this.TyreAge2 = int.Parse(ta2);
        this.TyrePressure3 = double.Parse(tp3);
        this.TyreAge3 = int.Parse(ta3);
        this.TyrePressure4 = double.Parse(tp4);
        this.tyreAge4 = int.Parse(ta4);
    }

    public double TyrePressure1
    {
        get { return tyrePressure1; }
        set { tyrePressure1 = value; }
    }

    public double TyrePressure2
    {
        get { return tyrePressure2; }
        set { tyrePressure2 = value; }
    }

    public double TyrePressure3
    {
        get { return tyrePressure3; }
        set { tyrePressure3 = value; }
    }

    public double TyrePressure4
    {
        get { return tyrePressure4; }
        set { tyrePressure4 = value; }
    }

    public int TyreAge1
    {
        get { return tyreAge1; }
        set { tyreAge1 = value; }
    }

    public int TyreAge2
    {
        get { return tyreAge2; }
        set { tyreAge2 = value; }
    }

    public int TyreAge3
    {
        get { return tyreAge3; }
        set { tyreAge3 = value; }
    }

    public int TyreAge4
    {
        get { return tyreAge4; }
        set { tyreAge4 = value; }
    }
}
