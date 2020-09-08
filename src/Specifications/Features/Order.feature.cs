﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.3.0.0
//      SpecFlow Generator Version:3.1.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Specifications.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class KortingToepassenBijMeerdereProduktenFeature : object, Xunit.IClassFixture<KortingToepassenBijMeerdereProduktenFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Order.feature"
#line hidden
        
        public KortingToepassenBijMeerdereProduktenFeature(KortingToepassenBijMeerdereProduktenFeature.FixtureData fixtureData, Specifications_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("nl-NL"), "Korting toepassen bij meerdere produkten", "Als klant wil ik 5% korting hebben op de aankoop als ik 10 of meer produkten afne" +
                    "em.", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 4
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Klant identificatie"});
            table1.AddRow(new string[] {
                        "KL123"});
#line 5
    testRunner.Given("de volgende klanten", ((string)(null)), table1, "Gegeven ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Produkt identificatie",
                        "Prijs"});
            table2.AddRow(new string[] {
                        "Appel",
                        "0.58"});
            table2.AddRow(new string[] {
                        "Banaan",
                        "0.98"});
#line 8
    testRunner.And("de volgende produkten", ((string)(null)), table2, "En ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Bij afname van minder dan 10 produkten wordt er geen korting gegeven")]
        [Xunit.TraitAttribute("FeatureTitle", "Korting toepassen bij meerdere produkten")]
        [Xunit.TraitAttribute("Description", "Bij afname van minder dan 10 produkten wordt er geen korting gegeven")]
        public virtual void BijAfnameVanMinderDan10ProduktenWordtErGeenKortingGegeven()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Bij afname van minder dan 10 produkten wordt er geen korting gegeven", null, tagsOfScenario, argumentsOfScenario);
#line 13
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 14
 testRunner.Given("klant \'KL123\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Gegeven ");
#line hidden
#line 15
    testRunner.When("ik \'9\' aantal van het produkt \'Appel\' bestel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Als ");
#line hidden
#line 16
    testRunner.Then("wordt het totaalbedrag \'5.22\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dan ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Bij afname van meer dan 10 produkten wordt er 5 procent korting gegeven")]
        [Xunit.TraitAttribute("FeatureTitle", "Korting toepassen bij meerdere produkten")]
        [Xunit.TraitAttribute("Description", "Bij afname van meer dan 10 produkten wordt er 5 procent korting gegeven")]
        public virtual void BijAfnameVanMeerDan10ProduktenWordtEr5ProcentKortingGegeven()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Bij afname van meer dan 10 produkten wordt er 5 procent korting gegeven", null, tagsOfScenario, argumentsOfScenario);
#line 18
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 19
 testRunner.Given("klant \'KL123\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Gegeven ");
#line hidden
#line 20
    testRunner.When("ik \'10\' aantal van het produkt \'Appel\' bestel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Als ");
#line hidden
#line 21
    testRunner.Then("wordt het totaalbedrag \'5.51\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dan ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.3.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                KortingToepassenBijMeerdereProduktenFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                KortingToepassenBijMeerdereProduktenFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
