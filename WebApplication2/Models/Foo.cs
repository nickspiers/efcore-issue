namespace WebApplication2.Models
{
    public class Foo : ModelBase
    {
        public string Name { get; set; }
        public int? ManId { get; set; }
        public Man Man { get; set; }
    }

    public class Man : ModelBase
    {
        public string Type { get; set; }
        public int? ChuId { get; set; }
        public Chu Chu { get; set; }
    }

    public class Chu : ModelBase
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
    }

    public class ModelBase
    {
        public int Id { get; set; }
    }
}