namespace FinalProject2026;

/// <summary>
/// Main class
/// </summary>
class Program
{
    static void Main(string[] args)
    { 
        /*
         * TODO: Restore ts to tis to make it work on windows
         * 
         * ﻿<Project Sdk="Microsoft.NET.Sdk">
           
               <PropertyGroup>
                   <OutputType>Exe</OutputType>
                   <TargetFramework>net9.0</TargetFramework>
                   <ImplicitUsings>enable</ImplicitUsings>
                   <Nullable>enable</Nullable>
               </PropertyGroup>
           
         </Project>
         */
        
        App app = new App(false);
        app.Run();
    }
}