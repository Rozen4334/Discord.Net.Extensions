// This project is intended as a way to test the extensions build out of the box.

using Discord.Extensions;

var mb = new MessageBuilder();

mb.AddHeader("My code", HeaderFormat.H1);

mb.AddCodeBlock("public class Test { }", CodeLanguage.CSharp);

mb.AddPlainText("This is a test").AddBoldText("with bold letters");

mb.AddQuote(new MultiLineBuilder().AddLine("This is pretty cool").AddLine("I can add multiple lines!"));

mb.AddStrikeThroughText("This is strikethrough text").AddPlainText("with some cool added letters");

mb.AddSpoiler("spoil me", false);

Console.WriteLine(mb.Build());
