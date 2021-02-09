// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.0.0.0
//      SpecFlow Generator Version:3.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SimpleIdServer.OAuth.Host.Acceptance.Tests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class RegisterFeature : Xunit.IClassFixture<RegisterFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Register.feature"
#line hidden
        
        public RegisterFeature(RegisterFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Register", "\tCheck registration endpoint", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void ScenarioTearDown()
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
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Create minimalist client")]
        [Xunit.TraitAttribute("FeatureTitle", "Register")]
        [Xunit.TraitAttribute("Description", "Create minimalist client")]
        public virtual void CreateMinimalistClient()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create minimalist client", null, ((string[])(null)));
#line 4
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table15.AddRow(new string[] {
                        "redirect_uris",
                        "[http://localhost]"});
#line 5
 testRunner.When("execute HTTP POST JSON request \'http://localhost/register\'", ((string)(null)), table15, "When ");
#line 9
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.Then("HTTP status code equals to \'201\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
 testRunner.Then("JSON exists \'client_id\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
 testRunner.Then("JSON exists \'client_secret\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.Then("JSON exists \'client_id_issued_at\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.Then("JSON exists \'grant_types\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
 testRunner.Then("JSON exists \'redirect_uris\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
 testRunner.Then("JSON exists \'token_endpoint_auth_method\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
 testRunner.Then("JSON exists \'response_types\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
 testRunner.Then("JSON exists \'client_name\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Create client")]
        [Xunit.TraitAttribute("FeatureTitle", "Register")]
        [Xunit.TraitAttribute("Description", "Create client")]
        public virtual void CreateClient()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create client", null, ((string[])(null)));
#line 21
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table16.AddRow(new string[] {
                        "redirect_uris",
                        "[http://localhost]"});
            table16.AddRow(new string[] {
                        "response_types",
                        "[token]"});
            table16.AddRow(new string[] {
                        "grant_types",
                        "[implicit]"});
            table16.AddRow(new string[] {
                        "client_name",
                        "name"});
            table16.AddRow(new string[] {
                        "client_name#fr",
                        "nom"});
            table16.AddRow(new string[] {
                        "client_name#en",
                        "name"});
            table16.AddRow(new string[] {
                        "client_uri",
                        "http://localhost"});
            table16.AddRow(new string[] {
                        "client_uri#fr",
                        "http://localhost/fr"});
            table16.AddRow(new string[] {
                        "logo_uri",
                        "http://localhost/1.png"});
            table16.AddRow(new string[] {
                        "logo_uri#fr",
                        "http://localhost/fr/1.png"});
            table16.AddRow(new string[] {
                        "software_id",
                        "software"});
            table16.AddRow(new string[] {
                        "software_version",
                        "1.0"});
            table16.AddRow(new string[] {
                        "token_endpoint_auth_method",
                        "client_secret_basic"});
            table16.AddRow(new string[] {
                        "scope",
                        "scope1"});
            table16.AddRow(new string[] {
                        "contacts",
                        "[addr1,addr2]"});
            table16.AddRow(new string[] {
                        "tos_uri",
                        "http://localhost/tos"});
            table16.AddRow(new string[] {
                        "policy_uri",
                        "http://localhost/policy"});
            table16.AddRow(new string[] {
                        "jwks_uri",
                        "http://localhost/jwks"});
#line 22
 testRunner.When("execute HTTP POST JSON request \'http://localhost/register\'", ((string)(null)), table16, "When ");
#line 43
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.Then("HTTP status code equals to \'201\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
 testRunner.Then("JSON exists \'client_id\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
 testRunner.Then("JSON exists \'client_secret\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
 testRunner.Then("JSON exists \'client_id_issued_at\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
 testRunner.Then("JSON exists \'grant_types\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
 testRunner.Then("JSON exists \'redirect_uris\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
 testRunner.Then("JSON exists \'response_types\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
 testRunner.Then("JSON exists \'contacts\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 53
 testRunner.Then("JSON \'token_endpoint_auth_method\'=\'client_secret_basic\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
 testRunner.Then("JSON \'client_uri\'=\'http://localhost\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 55
 testRunner.Then("JSON \'client_uri#fr\'=\'http://localhost/fr\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
 testRunner.Then("JSON \'logo_uri\'=\'http://localhost/1.png\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
 testRunner.Then("JSON \'logo_uri#fr\'=\'http://localhost/fr/1.png\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
 testRunner.Then("JSON \'scope\'=\'scope1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
 testRunner.Then("JSON \'tos_uri\'=\'http://localhost/tos\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
 testRunner.Then("JSON \'policy_uri\'=\'http://localhost/policy\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
 testRunner.Then("JSON \'jwks_uri\'=\'http://localhost/jwks\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 62
 testRunner.Then("JSON \'client_name\'=\'name\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 63
 testRunner.Then("JSON \'client_name#fr\'=\'nom\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
 testRunner.Then("JSON \'client_name#en\'=\'name\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
 testRunner.Then("JSON \'software_id\'=\'software\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
 testRunner.Then("JSON \'software_version\'=\'1.0\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Use software_statement parameter to create a client")]
        [Xunit.TraitAttribute("FeatureTitle", "Register")]
        [Xunit.TraitAttribute("Description", "Use software_statement parameter to create a client")]
        public virtual void UseSoftware_StatementParameterToCreateAClient()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Use software_statement parameter to create a client", null, ((string[])(null)));
#line 68
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table17.AddRow(new string[] {
                        "iss",
                        "iss"});
            table17.AddRow(new string[] {
                        "redirect_uris",
                        "[http://localhost]"});
#line 69
 testRunner.When("build software statement", ((string)(null)), table17, "When ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table18.AddRow(new string[] {
                        "software_statement",
                        "$softwareStatement$"});
#line 74
 testRunner.When("execute HTTP POST JSON request \'http://localhost/register\'", ((string)(null)), table18, "When ");
#line 78
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.Then("HTTP status code equals to \'201\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 81
 testRunner.Then("JSON exists \'client_id\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 82
 testRunner.Then("JSON exists \'client_secret\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 83
 testRunner.Then("JSON exists \'client_id_issued_at\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 84
 testRunner.Then("JSON exists \'grant_types\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 85
 testRunner.Then("JSON exists \'redirect_uris\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 86
 testRunner.Then("JSON exists \'token_endpoint_auth_method\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 87
 testRunner.Then("JSON exists \'response_types\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 88
 testRunner.Then("JSON exists \'client_name\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Get client")]
        [Xunit.TraitAttribute("FeatureTitle", "Register")]
        [Xunit.TraitAttribute("Description", "Get client")]
        public virtual void GetClient()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get client", null, ((string[])(null)));
#line 90
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table19.AddRow(new string[] {
                        "redirect_uris",
                        "[http://localhost]"});
            table19.AddRow(new string[] {
                        "response_types",
                        "[token]"});
            table19.AddRow(new string[] {
                        "grant_types",
                        "[implicit]"});
            table19.AddRow(new string[] {
                        "client_name",
                        "name"});
            table19.AddRow(new string[] {
                        "client_name#fr",
                        "nom"});
            table19.AddRow(new string[] {
                        "client_name#en",
                        "name"});
            table19.AddRow(new string[] {
                        "client_uri",
                        "http://localhost"});
            table19.AddRow(new string[] {
                        "client_uri#fr",
                        "http://localhost/fr"});
            table19.AddRow(new string[] {
                        "logo_uri",
                        "http://localhost/1.png"});
            table19.AddRow(new string[] {
                        "logo_uri#fr",
                        "http://localhost/fr/1.png"});
            table19.AddRow(new string[] {
                        "software_id",
                        "software"});
            table19.AddRow(new string[] {
                        "software_version",
                        "1.0"});
            table19.AddRow(new string[] {
                        "token_endpoint_auth_method",
                        "client_secret_basic"});
            table19.AddRow(new string[] {
                        "scope",
                        "scope1"});
            table19.AddRow(new string[] {
                        "contacts",
                        "[addr1,addr2]"});
            table19.AddRow(new string[] {
                        "tos_uri",
                        "http://localhost/tos"});
            table19.AddRow(new string[] {
                        "policy_uri",
                        "http://localhost/policy"});
            table19.AddRow(new string[] {
                        "jwks_uri",
                        "http://localhost/jwks"});
#line 91
 testRunner.When("execute HTTP POST JSON request \'http://localhost/register\'", ((string)(null)), table19, "When ");
#line 112
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
 testRunner.And("extract parameter \'client_id\' from JSON body into \'clientId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
 testRunner.And("extract parameter \'registration_access_token\' from JSON body into \'registrationAc" +
                    "cessToken\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table20.AddRow(new string[] {
                        "Authorization",
                        "$registrationAccessToken$"});
#line 115
 testRunner.And("execute HTTP GET request \'http://localhost/register/$clientId$\'", ((string)(null)), table20, "And ");
#line 119
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 122
 testRunner.Then("JSON exists \'client_id\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 123
 testRunner.Then("JSON exists \'client_secret\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 124
 testRunner.Then("JSON exists \'client_id_issued_at\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 125
 testRunner.Then("JSON exists \'grant_types\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 126
 testRunner.Then("JSON exists \'redirect_uris\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 127
 testRunner.Then("JSON exists \'response_types\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 128
 testRunner.Then("JSON exists \'contacts\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 129
 testRunner.Then("JSON \'client_secret_expires_at\'=\'0\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
 testRunner.Then("JSON \'token_endpoint_auth_method\'=\'client_secret_basic\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 131
 testRunner.Then("JSON \'client_uri\'=\'http://localhost\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 132
 testRunner.Then("JSON \'client_uri#fr\'=\'http://localhost/fr\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 133
 testRunner.Then("JSON \'logo_uri\'=\'http://localhost/1.png\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 134
 testRunner.Then("JSON \'logo_uri#fr\'=\'http://localhost/fr/1.png\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 135
 testRunner.Then("JSON \'scope\'=\'scope1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 136
 testRunner.Then("JSON \'tos_uri\'=\'http://localhost/tos\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 137
 testRunner.Then("JSON \'policy_uri\'=\'http://localhost/policy\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 138
 testRunner.Then("JSON \'jwks_uri\'=\'http://localhost/jwks\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 139
 testRunner.Then("JSON \'client_name\'=\'name\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 140
 testRunner.Then("JSON \'client_name#fr\'=\'nom\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 141
 testRunner.Then("JSON \'client_name#en\'=\'name\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 142
 testRunner.Then("JSON \'software_id\'=\'software\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 143
 testRunner.Then("JSON \'software_version\'=\'1.0\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Update client")]
        [Xunit.TraitAttribute("FeatureTitle", "Register")]
        [Xunit.TraitAttribute("Description", "Update client")]
        public virtual void UpdateClient()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update client", null, ((string[])(null)));
#line 145
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table21.AddRow(new string[] {
                        "redirect_uris",
                        "[http://localhost]"});
            table21.AddRow(new string[] {
                        "response_types",
                        "[token]"});
            table21.AddRow(new string[] {
                        "grant_types",
                        "[implicit]"});
            table21.AddRow(new string[] {
                        "client_name",
                        "name"});
            table21.AddRow(new string[] {
                        "client_name#fr",
                        "nom"});
            table21.AddRow(new string[] {
                        "client_name#en",
                        "name"});
            table21.AddRow(new string[] {
                        "client_uri",
                        "http://localhost"});
            table21.AddRow(new string[] {
                        "client_uri#fr",
                        "http://localhost/fr"});
            table21.AddRow(new string[] {
                        "logo_uri",
                        "http://localhost/1.png"});
            table21.AddRow(new string[] {
                        "logo_uri#fr",
                        "http://localhost/fr/1.png"});
            table21.AddRow(new string[] {
                        "software_id",
                        "software"});
            table21.AddRow(new string[] {
                        "software_version",
                        "1.0"});
            table21.AddRow(new string[] {
                        "token_endpoint_auth_method",
                        "client_secret_basic"});
            table21.AddRow(new string[] {
                        "scope",
                        "scope1"});
            table21.AddRow(new string[] {
                        "contacts",
                        "[addr1,addr2]"});
            table21.AddRow(new string[] {
                        "tos_uri",
                        "http://localhost/tos"});
            table21.AddRow(new string[] {
                        "policy_uri",
                        "http://localhost/policy"});
            table21.AddRow(new string[] {
                        "jwks_uri",
                        "http://localhost/jwks"});
#line 146
 testRunner.When("execute HTTP POST JSON request \'http://localhost/register\'", ((string)(null)), table21, "When ");
#line 167
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 168
 testRunner.And("extract parameter \'client_id\' from JSON body into \'clientId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 169
 testRunner.And("extract parameter \'registration_access_token\' from JSON body into \'registrationAc" +
                    "cessToken\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table22.AddRow(new string[] {
                        "Authorization",
                        "$registrationAccessToken$"});
            table22.AddRow(new string[] {
                        "client_id",
                        "$clientId$"});
            table22.AddRow(new string[] {
                        "redirect_uris",
                        "[http://localhost]"});
            table22.AddRow(new string[] {
                        "response_types",
                        "[token]"});
            table22.AddRow(new string[] {
                        "grant_types",
                        "[implicit]"});
            table22.AddRow(new string[] {
                        "client_name",
                        "name"});
            table22.AddRow(new string[] {
                        "client_name#fr",
                        "nom"});
            table22.AddRow(new string[] {
                        "client_name#en",
                        "name"});
            table22.AddRow(new string[] {
                        "client_uri",
                        "http://clienturi"});
            table22.AddRow(new string[] {
                        "client_uri#fr",
                        "http://clienturi/fr"});
            table22.AddRow(new string[] {
                        "logo_uri",
                        "http://logouri/1.png"});
            table22.AddRow(new string[] {
                        "logo_uri#fr",
                        "http://logouri/fr/1.png"});
            table22.AddRow(new string[] {
                        "software_id",
                        "software"});
            table22.AddRow(new string[] {
                        "software_version",
                        "1.0"});
            table22.AddRow(new string[] {
                        "token_endpoint_auth_method",
                        "client_secret_basic"});
            table22.AddRow(new string[] {
                        "scope",
                        "scope1"});
            table22.AddRow(new string[] {
                        "contacts",
                        "[addr1,addr2]"});
            table22.AddRow(new string[] {
                        "tos_uri",
                        "http://tosuri/tos"});
            table22.AddRow(new string[] {
                        "policy_uri",
                        "http://policyuri/policy"});
            table22.AddRow(new string[] {
                        "jwks_uri",
                        "http://jwksuri/jwks"});
#line 171
 testRunner.And("execute HTTP PUT JSON request \'http://localhost/register/$clientId$\'", ((string)(null)), table22, "And ");
#line hidden
            TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table23.AddRow(new string[] {
                        "Authorization",
                        "$registrationAccessToken$"});
#line 194
 testRunner.And("execute HTTP GET request \'http://localhost/register/$clientId$\'", ((string)(null)), table23, "And ");
#line 198
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 200
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 201
 testRunner.Then("JSON exists \'client_id\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 202
 testRunner.Then("JSON exists \'client_secret\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 203
 testRunner.Then("JSON exists \'client_id_issued_at\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 204
 testRunner.Then("JSON exists \'grant_types\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 205
 testRunner.Then("JSON exists \'redirect_uris\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 206
 testRunner.Then("JSON exists \'response_types\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 207
 testRunner.Then("JSON exists \'contacts\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 208
 testRunner.Then("JSON \'client_secret_expires_at\'=\'0\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 209
 testRunner.Then("JSON \'token_endpoint_auth_method\'=\'client_secret_basic\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 210
 testRunner.Then("JSON \'client_uri\'=\'http://clienturi\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 211
 testRunner.Then("JSON \'client_uri#fr\'=\'http://clienturi/fr\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 212
 testRunner.Then("JSON \'logo_uri\'=\'http://logouri/1.png\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 213
 testRunner.Then("JSON \'logo_uri#fr\'=\'http://logouri/fr/1.png\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 214
 testRunner.Then("JSON \'scope\'=\'scope1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 215
 testRunner.Then("JSON \'tos_uri\'=\'http://tosuri/tos\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 216
 testRunner.Then("JSON \'policy_uri\'=\'http://policyuri/policy\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 217
 testRunner.Then("JSON \'jwks_uri\'=\'http://jwksuri/jwks\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 218
 testRunner.Then("JSON \'client_name\'=\'name\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 219
 testRunner.Then("JSON \'client_name#fr\'=\'nom\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 220
 testRunner.Then("JSON \'client_name#en\'=\'name\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 221
 testRunner.Then("JSON \'software_id\'=\'software\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 222
 testRunner.Then("JSON \'software_version\'=\'1.0\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Delete client")]
        [Xunit.TraitAttribute("FeatureTitle", "Register")]
        [Xunit.TraitAttribute("Description", "Delete client")]
        public virtual void DeleteClient()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete client", null, ((string[])(null)));
#line 225
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table24.AddRow(new string[] {
                        "redirect_uris",
                        "[http://localhost]"});
            table24.AddRow(new string[] {
                        "response_types",
                        "[token]"});
            table24.AddRow(new string[] {
                        "grant_types",
                        "[implicit]"});
            table24.AddRow(new string[] {
                        "client_name",
                        "name"});
            table24.AddRow(new string[] {
                        "client_name#fr",
                        "nom"});
            table24.AddRow(new string[] {
                        "client_name#en",
                        "name"});
            table24.AddRow(new string[] {
                        "client_uri",
                        "http://localhost"});
            table24.AddRow(new string[] {
                        "client_uri#fr",
                        "http://localhost/fr"});
            table24.AddRow(new string[] {
                        "logo_uri",
                        "http://localhost/1.png"});
            table24.AddRow(new string[] {
                        "logo_uri#fr",
                        "http://localhost/fr/1.png"});
            table24.AddRow(new string[] {
                        "software_id",
                        "software"});
            table24.AddRow(new string[] {
                        "software_version",
                        "1.0"});
            table24.AddRow(new string[] {
                        "token_endpoint_auth_method",
                        "client_secret_basic"});
            table24.AddRow(new string[] {
                        "scope",
                        "scope1"});
            table24.AddRow(new string[] {
                        "contacts",
                        "[addr1,addr2]"});
            table24.AddRow(new string[] {
                        "tos_uri",
                        "http://localhost/tos"});
            table24.AddRow(new string[] {
                        "policy_uri",
                        "http://localhost/policy"});
            table24.AddRow(new string[] {
                        "jwks_uri",
                        "http://localhost/jwks"});
#line 226
 testRunner.When("execute HTTP POST JSON request \'http://localhost/register\'", ((string)(null)), table24, "When ");
#line 247
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 248
 testRunner.And("extract parameter \'client_id\' from JSON body into \'clientId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 249
 testRunner.And("extract parameter \'registration_access_token\' from JSON body into \'registrationAc" +
                    "cessToken\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table25.AddRow(new string[] {
                        "Authorization",
                        "$registrationAccessToken$"});
#line 251
 testRunner.And("execute HTTP DELETE request \'http://localhost/register/$clientId$\'", ((string)(null)), table25, "And ");
#line hidden
            TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table26.AddRow(new string[] {
                        "Authorization",
                        "$registrationAccessToken$"});
#line 256
 testRunner.And("execute HTTP GET request \'http://localhost/register/$clientId$\'", ((string)(null)), table26, "And ");
#line 260
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 262
 testRunner.Then("HTTP status code equals to \'401\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 263
 testRunner.Then("JSON \'error\'=\'invalid_token\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 264
 testRunner.Then("JSON \'error_description\'=\'access token is not correct\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                RegisterFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                RegisterFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
