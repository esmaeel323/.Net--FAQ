using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAQ.Models
{
    public static class DBInit
    {
        public static void Initialize(FAQContext context)
        {
            context.Database.EnsureCreated();
            if (context.FAQs.Any())
            {
                return;
            }
            var faqs = new FAQs[]
            {
            new FAQs { question = "Hva er reisekort?",
                       answer = " Med reisekort reiser du med elektronisk billett hos Vy og Ruter, som samarbeider om kortsystemet elektronisk reisekort. Reisekortet gjelder i Oslo og Akershus. Du kan kjøpe reisekort fra kundeservice eller på betjent stasjon.",like = 2, dislike = 1 },
            new FAQs { question=" Hvor finner jeg informasjon om stasjonene?",
                       answer="Se åpningstider og adresser for våre betjente stasjoner. For øvrig informasjon om stasjoner, se stasjonsoversikten på banenor.no.",like = 5, dislike = 2},
            new FAQs { question="Hvor lenge før avreise kan jeg kjøpe togbillett?",
                       answer="Billetter legges ut for salg 90 dager før avgang. Det kan være kortere salgsperiode ved planlagte arbeider på strekningen eller i forbindelse med ruteendringer i juni og desember.",like = 3, dislike = 3},
            new FAQs { question="Hva skjer hvis jeg ikke rekker toget?",
                       answer="Enkeltbilletter er gyldig til angitt avgang, det vil si at du ikke kan benytte billetten på andre avganger. Du må dermed kjøpe en ny billett hvis du vil reise med neste avgang. Dersom du bruker Vy-appen til å kjøpe Ruter-billett, er det Ruters bestemmelser for gyldighetstid som gjelder.",like = 4, dislike = 1},
            new FAQs { question="Kan jeg reservere sete om bord?",
                       answer="På lange regiontog, Raumabanen og Rørosbanen er setereservasjon inkludert i prisen. Når du bestiller billetten på nett eller i appen er det et steg der du velger hvor i toget du ønsker å sitte.I slike tog kan du reservere en ledig plass ved siden av deg mot prisen av en ordinær voksenbillett eller Miniprisbillett.",like = 2, dislike = 0},
            new FAQs { question="Jeg vil reise rundt i Norge i ferien. Finnes det en billett for dette?",
                       answer="Vi tilbyr ikke en fleksibel billett som kan brukes på flere avganger rundt omkring i Norge. men du kan se om noen av turene til vår samarbeidspartner, Fjord Tours, passer deg.",like = 6, dislike = 3},
            new FAQs { question="Hvordan henter jeg billetter kjøpt på vy.no?",
                       answer="Det enkleste er å hente ut billetten via appen. Den kan også lastes ned som PDF eller hentes ut om bord, på billettautomat, på betjent stasjon og hos enkelte Narvesen-kiosker.",like = 2, dislike = 1},
            new FAQs { question="Kan jeg reise på en annen avgang enn den som står på billetten?",
                       answer="Nei. Billetten gir rett til reise på bestemt avgang. Ved reise med enkeltbillett må påstigning skje på den holdeplassen som fremgår av billetten.",like = 6, dislike = 3},
            new FAQs { question="Reisen min påvirkes av arbeider – hvor finner jeg mer informasjon?",
                       answer="Se informasjon om planlagte arbeider. Informasjon om planlagte arbeider finnes også i reiseplanleggeren og i appen når du søker opp en avgang.",like = 4, dislike = 0},
            new FAQs { question="Det står at det er utsolgt. Kan jeg bli med likevel?",
                       answer="Det er ikke mulig å kjøpe billetter til utsolgte tog. Du kan møte opp og ta sjansen på at det er kapasitet. Konduktøren gjør da en vurdering rett før avgang. Dersom det ikke er kapasitet om bord vil du ikke kunne bli med toget.",like = 8, dislike = 3}

         };

            foreach (var item in faqs)
            {
                context.FAQs.Add(item);
            }

            

            context.SaveChanges();
        }
    }
}
