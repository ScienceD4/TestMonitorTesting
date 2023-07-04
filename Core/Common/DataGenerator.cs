using Bogus;

namespace Core.Common;

public static class DataGenerator
{
    public static string GetRandomFirstName() => new Faker().Name.FirstName();

    public static string GetRandomFullName() => new Faker().Name.FullName();

    public static string GetRandomLastName() => new Faker().Name.LastName();

    public static string GetRandomPhone() => new Faker().Phone.PhoneNumber("+79#########");
}