using Console.TestCSahrp11;
using static System.Console;

var testRequired = new RequiredFields
{
    Name = "Test",
    Age = 123
};

WriteLine($$"""
    Just Testing some features:
    Name: {{testRequired.Name}}
    Age: {{testRequired.Age}}
""");

//List patterns
int[] arr = { 1, 2, 3, 4, 5, 6 };
WriteLine(arr is [1, 2, 3, 4, 5, 6]);
WriteLine(arr is [_, _, 3, _, _, _]);
WriteLine(arr is [>= 1, 3, _, _, 6]);

if (arr is [.., var lastElement]) WriteLine(lastElement);

string json = $$"""
{
    "glossary": {
        "title": "example glossary",
		"GlossDiv": {
            "title": "S",
			"GlossList": {
                "GlossEntry": {
                    "ID": "SGML",
					"SortAs": "SGML",
					"GlossTerm": "Standard Generalized Markup Language",
					"Acronym": "SGML",
					"Abbrev": "ISO 8879:1986",
					"GlossDef": {
                        "para": "A meta-markup language, used to create markup languages such as DocBook.",
						"GlossSeeAlso": ["GML", "XML"]
                    },
					"GlossSee": "markup"
                }
            }
        }
    }
}
""";

WriteLine(json);