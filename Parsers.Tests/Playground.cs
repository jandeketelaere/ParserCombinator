namespace Parsers.Tests
{
    public class Playground
    {
        [Fact]
        public void Test()
        {
            //var parser = Dsl.Character('a')
            //    .Then(charA => Dsl.Character('b')
            //    .Then(charB => Dsl.Whitespace
            //    .Then(whiteSpace => Dsl.Character('c')
            //    .End()
            //    .Select(charC => $"{charA}{charB}{whiteSpace}{charC}")
            //    )));

            var text = "abc";

            var parser =
                from charA in Dsl.Character('a')
                from charB in Dsl.Character('b')
                from charC in Dsl.Character('c')
                .End()
                select "sqdf";

            var (result, value) = parser.Parse(text);
        }
    }
}