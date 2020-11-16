using System;
using System.Collections.Generic;
using System.Text;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public enum Children
{
    Alice,
    Bob,
    Charlie,
    David,
    Eva,
    Fred,
    Ginny,
    Harriet,
    Ileana,
    Joseph,
    Kincaid,
    Larry
}

public class KindergartenGarden
{
    private readonly string[] diagram;

    public KindergartenGarden(string diagram) => this.diagram = diagram.Split('\n');

    private string VasePlantChildren(string[] diagram, Children children)
    {
        StringBuilder answer = new StringBuilder();
        int index = Convert.ToInt32(children);
        foreach (var d in diagram)
            answer.Append($"{d[index * 2]}{d[(index * 2) + 1]}");

        return answer.ToString();
    }

    public IEnumerable<Plant> Plants(string student)
    {

        Children ChildrenName = (Children)Enum.Parse(typeof(Children), student);

        List<Plant> plants = new List<Plant>();

        foreach (char diagram in VasePlantChildren(diagram, ChildrenName))
        {
            foreach (Plant v in Enum.GetValues(typeof(Plant)))
            {
                string comp = v.ToString();

                if (diagram == comp[0])
                {
                    plants.Add(v);
                }
            }

        }

        return plants.ToArray();
    }
}