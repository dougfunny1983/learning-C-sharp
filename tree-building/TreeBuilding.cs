using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public List<Tree> Children { get; set; }

    public bool IsLeaf => Children.Count == 0;
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        TreeBuildingRecord[] ordered = OrderId(records);

        Tree[] nodes = new Tree[ordered.Length];
        for (int i = 0; i < ordered.Length; i++)
        {
            TreeBuildingRecord record = ordered[i];
            nodes[i] = new Tree { Id = record.RecordId, ParentId = record.ParentId, Children = new List<Tree>() };

            if (record.RecordId == 0)
                continue;

            Tree parentNode = nodes[record.ParentId];
            parentNode.Children.Add(nodes[i]);
        }

        return nodes[0];
    }

    private static readonly SystemException Err = new ArgumentException();

    private static TreeBuildingRecord[] OrderId(IEnumerable<TreeBuildingRecord> records)
    {
        if (!records.Any())
            throw Err;

        TreeBuildingRecord[] ordered = new TreeBuildingRecord[records.Count()];

        foreach (TreeBuildingRecord rec in records)
        {
            if (rec.RecordId >= ordered.Length)
                throw Err;

            if (rec.RecordId != 0 && rec.RecordId <= rec.ParentId)
                throw Err;

            if (rec.RecordId == 0 && rec.ParentId != 0)
                throw Err;

            ordered[rec.RecordId] = rec;
        }

        return ordered;
    }
}