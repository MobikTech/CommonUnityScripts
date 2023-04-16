﻿namespace Mobik.Common.Utilities.UIFramework
{
    public interface IOptions
    {
        public static readonly IOptions NoneOptions = new NoneOptions();
        public bool IsNone => false;
    }
    
    public class NoneOptions : IOptions
    {
        public bool IsNone => true;
    }
}