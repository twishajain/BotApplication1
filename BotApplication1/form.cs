using System;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
namespace HelloFormFlowBot
{
    [Serializable]
    public class form
    {
        [Prompt("What is your name? {||}")]
        public string Name;
        [Prompt("What would you like your icecream in? {||}")]
        public Holder Holder;
        [Prompt("how many scoops do you want? {||}")]
        public Scoops Scoops;
        [Prompt("What flavour do you want? {||}")]
        public Flavour Flavour;
        public static IForm<form> BuildForm()
        {
            return new FormBuilder<form>().Message("Welcome to the icecream bot!").OnCompletion(async (context, profileForm) => {
                await context.PostAsync("Your order is complete. Enjoy your icecream");
            }).Build();
        }
    }
    [Serializable]
    public enum Flavour
    {
        Chocolate = 1, Vanilla = 2, Butterscotch=3, Strawberry=4
    };
    public enum Holder
    {
        Cup=1, Normal_Cone=2, Waffle_Cone=3
    };
    public enum Scoops
    {
        Single=1, Double = 2
    };
}