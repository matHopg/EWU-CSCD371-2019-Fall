using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public static class ActorExtensions
    {
        public static void Speak(this Actor actor, bool WomenArePresent)
        {
            //Had old lame switch statement but found elegant solution doing code review for jacob-berger
            string spoke;
            spoke = (actor switch
            {
                Penny penny => spoke = (new Penny().Speak()),
                Sheldon sheldon => spoke = (new Sheldon().Speak()),
                Raj raj when (WomenArePresent) => spoke = (new Raj().SpeakWithWomenPresent()),
                Raj raj when (!WomenArePresent) => spoke = (new Raj().SpeakWithoutWomenPresent()),
                { } => throw new NotSupportedException(),
                null => throw new NullReferenceException(),

            });
        }
    }
}
