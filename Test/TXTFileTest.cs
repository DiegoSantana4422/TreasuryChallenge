using System.Collections.Generic;
using TreasuryChallenge.Model;
using TreasuryChallenge.Services;
using TreasuryChallenge.utils;
using Xunit;

namespace TreasuryChallenge
{
    public class TXTFileTest
    {
        [Fact]
        public void RemoveDuplicates_QuandoEnviadoItensDuplicados_DeveManterApenasUm()
        {
            //arrange 
            var lista = new List<string>
            {
                "ASDFGHJ",
                "ASDMGHJ",
                "ASDFGHJ"
            };
            var expected = 2;
            //act
            lista = TreasuryUtils.RemoveDuplicates(lista);
            //assert
            Assert.Equal(expected, lista.Count);
        }       
        
        [Fact]
        public void GenerateCode_QuandoChamado_DeveRetornarUmaStringDe7Digitos()
        {
            //arrange            
            var expected = 7;
            //act
            var result =  TreasuryUtils.GenerateCode();
            //assert
            Assert.Equal(expected, result.Length);
        }

        [Fact]
        public void CreateCodeFile_QuandoChamado_DeveCriarUmArquivoComONomeEQuanditadeDeLinhasInformado()
        {
            //arrange            
            TemplateFile templateFile = new TemplateFile
            {
                NameFile = "teste01",
                NumberLines = 10
            };
            try
            {
                //act
                var marketingCampaignService = new MarketingCampaignService();
                marketingCampaignService.CreateCodeFile(templateFile);
                //assert
                Assert.True(true);
            }
            catch (System.Exception)
            {
                //assert
                Assert.True(false);
            }          
        }      
    }
}
