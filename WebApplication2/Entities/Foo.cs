namespace WebApplication2.Entities
{
    public class Foo : EntityBase
    {
        public string Name { get; set; }
        public int? ManId { get; set; }
        public Man Man { get; set; }
    }

    public class Man : EntityBase
    {
        public string Type { get; set; }
        public int? ChuId { get; set; }
        public Chu Chu { get; set; }
    }

    public class Chu : EntityBase
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
    }

    public class EntityBase
    {
        public int Id { get; set; }
    }
}