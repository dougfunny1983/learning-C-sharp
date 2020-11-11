using System;
using System.Linq;

public enum Allergen
{
    Eggs,
    Peanuts,
    Shellfish,
    Strawberries,
    Tomatoes,
    Chocolate,
    Pollen,
    Cats
}

public class Allergies
{
    private readonly int mask;
    public Allergies(int mask) => this.mask = mask;

    private int PowAllergen(int number) => 1 << number;

    public bool IsAllergicTo(Allergen allergen) => (mask & PowAllergen((int)allergen)) >= 1;

    public Allergen[] List() => Enum.GetValues(typeof(Allergen))
        .Cast<Allergen>()
        .Select(allergen => allergen)
        .Where(all => IsAllergicTo(all))
        .ToArray();

}
