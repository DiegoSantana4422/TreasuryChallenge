using System.Collections.Generic;
using System.IO;
using System.Linq;
using TreasuryChallenge.Contracts.Services;
using TreasuryChallenge.Model;
using TreasuryChallenge.utils;

namespace TreasuryChallenge.Services
{
    public class MarketingCampaignService : IMarketingCampaignService
    {
        public void CreateCodeFile(TemplateFile templateFile)
        {
            string fileName = $@"{templateFile.NameFile}.txt";

            var lista = GenerateCodeList(templateFile.NumberLines);

            using (StreamWriter write = new StreamWriter(fileName))
            {
                write.Write(lista.First());
                foreach (var item in lista.Skip(1))
                {
                    write.Write("\n" + item);
                }
            };
        }
        private List<string> GenerateCodeList(int inputValue)
        {
            var lista = new List<string>();
            var linhas = true;
            var contador = 0;

            while (linhas)
            {
                var cod = TreasuryUtils.GenerateCode();
                lista.Add(cod);
                contador++;

                if (contador == inputValue)
                {
                    lista = TreasuryUtils.RemoveDuplicates(lista);

                    if (lista.Count == inputValue)
                    {
                        linhas = false;
                    }
                    else
                    {
                        contador = lista.Count;
                    }
                }
            }
            return lista;
        }
        
    }
}
