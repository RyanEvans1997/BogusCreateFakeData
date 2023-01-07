using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateFakeData
{
    public enum PropertyType
    {
        Detached,
        SemiDetached,
        Terraced,
        Flat,
        Bungalow,
        StudentHalls
    }

    public enum FurnishedType
    {
        Furnished,
        PartFurnished,
        Unfurnished
    }

    public enum LetType
    {
        ShortTerm,
        LongTerm,
    }

    public class Property
    {
        public int Id { get; set; }

        private static int _userId = 1;

        public PropertyType TypeOfProperty { get; set; }

        public string? FullAddress { get; set; }

        public int MonthlyRent { get; set; }

        public DateTime LetAvailableDate { get; set; }

        public int MinimumTenancy { get; set; }

        public FurnishedType TypeOfFurnished { get; set; }

        public double Deposit { get; set; }

        public LetType TypeOfLet { get; set; }

        public int NumberOfBedrooms { get; set; }

        public string? PropertyDescription { get; set; }

        /// <summary>Gets the fake data.</summary>
        /// <value>The fake data.</value>
        public static Faker<Property> FakeData { get; } =
            new Faker<Property>()
                .RuleFor(p => p.Id, f => _userId++)
                .RuleFor(p => p.TypeOfProperty, f => f.PickRandom<PropertyType>())
                .RuleFor(p => p.FullAddress, f => f.Address.FullAddress())
                .RuleFor(p => p.MonthlyRent, f => f.Random.Int())
                .RuleFor(p => p.LetAvailableDate, f => f.Date.Future())
                .RuleFor(p => p.MinimumTenancy, f => f.Random.Int(1, 12))
                .RuleFor(p => p.TypeOfFurnished, f => f.PickRandom<FurnishedType>())
                .RuleFor(p => p.Deposit, f => f.Random.Double())
                .RuleFor(p => p.TypeOfLet, f => f.PickRandom<LetType>())
                .RuleFor(p => p.NumberOfBedrooms, f => f.Random.Int(1, 4))
                .RuleFor(p => p.PropertyDescription, f => f.Lorem.Paragraphs());
    }
}
