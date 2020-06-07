using System.Collections.Generic;
using Newtonsoft.Json;

namespace APICore.Models
{
    public class Speciality
    {
        private readonly List<string> Specialities = new List<string> {
            "NENHUMA",
            "ACUPUNTURA",
            "ALERGIA E IMUNOLOGIA",
            "ANESTESIOLOGIA",
            "ANGIOLOGIA",
            "CARDIOLOGIA",
            "CIRURGIA CARDIOVASCULAR",
            "CIRURGIA DA MÃO",
            "CIRURGIA DE CABEÇA E PESCOÇO",
            "CIRURGIA DO APARELHO DIGESTIVO",
            "CIRURGIA GERAL",
            "CIRURGIA ONCOLÓGICA",
            "CIRURGIA PEDIÁTRICA",
            "CIRURGIA PLÁSTICA",
            "CIRURGIA TORÁCICA",
            "CIRURGIA VASCULAR",
            "CLÍNICA MÉDICA",
            "COLOPROCTOLOGIA",
            "DERMATOLOGIA",
            "ENDOCRINOLOGIA E METABOLOGIA",
            "ENDOSCOPIA",
            "GASTROENTEROLOGIA",
            "GENÉTICA MÉDICA",
            "GERIATRIA",
            "GINECOLOGIA E OBSTETRÍCIA",
            "HEMATOLOGIA E HEMOTERAPIA",
            "HOMEOPATIA",
            "INFECTOLOGIA",
            "MASTOLOGIA",
            "MEDICINA DE EMERGÊNCIA",
            "MEDICINA DE FAMÍLIA E COMUNIDADE",
            "MEDICINA DO TRABALHO",
            "MEDICINA DE TRÁFEGO",
            "MEDICINA ESPORTIVA",
            "MEDICINA FÍSICA E REABILITAÇÃO",
            "MEDICINA INTENSIVA",
            "MEDICINA LEGAL E PERÍCIA MÉDICA",
            "MEDICINA NUCLEAR",
            "MEDICINA PREVENTIVA E SOCIAL",
            "NEFROLOGIA",
            "NEUROCIRURGIA",
            "NEUROLOGIA",
            "NUTROLOGIA",
            "OFTALMOLOGIA",
            "ONCOLOGIA CLÍNICA",
            "ORTOPEDIA E TRAUMATOLOGIA",
            "OTORRINOLARINGOLOGIA",
            "PATOLOGIA",
            "PATOLOGIA CLÍNICA/MEDICINA LABORATORIAL",
            "PEDIATRIA",
            "PNEUMOLOGIA",
            "PSIQUIATRIA",
            "RADIOLOGIA E DIAGNÓSTICO POR IMAGEM",
            "RADIOTERAPIA",
            "REUMATOLOGIA",
            "UROLOGIA"
        };

        public string GetSpecialitiesSerialized() {
            var specialities = new { specialities = Specialities };
            return JsonConvert.SerializeObject(specialities);
        }
    }
}
