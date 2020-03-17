﻿using Natasha.Reverser;
using Natasha.Reverser.Model;
using System.Reflection;

namespace Natasha.Template
{
    public class OnceMethodModifierTemplate<T>: OnceMethodAccessTemplate<T> where T : OnceMethodModifierTemplate<T>, new()
    {

        public string OnceModifierScript;
        public T MethodModifier(MethodInfo modifier)
        {

            OnceModifierScript = ModifierReverser.GetModifier(modifier);
            return Link;

        }




        public T MethodModifier(Modifiers modifier)
        {

            OnceModifierScript = ModifierReverser.GetModifier(modifier);
            return Link;

        }




        public T StaticMember
        {
            get { OnceModifierScript = "static "; return Link; }
        }
        public T AbstractMember
        {
            get { OnceModifierScript = "abstract "; return Link; }
        }
        public T NewMember
        {
            get { OnceModifierScript = "new "; return Link; }
        }
        public T VirtualMember
        {
            get { OnceModifierScript = "virtual "; return Link; }
        }
        public T OverrideMember
        {
            get { OnceModifierScript = "override "; return Link; }
        }




        public T MethodModifier(string modifier)
        {

            OnceModifierScript = modifier;
            if (OnceAccessScript.EndsWith(" "))
            {
                OnceAccessScript += " ";
            }
            return Link;

        }




        public T Override()
        {

            MethodModifier(Modifiers.Override);
            return Link;

        }




        public T NewHidden()
        {

            MethodModifier(Modifiers.New);
            return Link;

        }




        public override T Builder()
        {

            OnceBuilder.Insert(0, OnceModifierScript);
            return base.Builder();

        }

    }

}
