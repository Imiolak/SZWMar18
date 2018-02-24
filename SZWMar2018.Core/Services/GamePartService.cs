using System;
using System.Collections.Generic;
using SZWMar2018.Core.Models;

namespace SZWMar2018.Core.Services
{
    public class GamePartService : IGamePartService
    {
        public GamePart GetGamePart(int gamePartNo)
        {
            if (!_gameParts.ContainsKey(gamePartNo))
            { 
                throw new ArgumentException($"Game part with number {gamePartNo} doesn't exist");
            }

            return _gameParts[gamePartNo];
        }

        public int GetTotalNumberOfGameParts()
        {
            return _gameParts.Count;
        }

        #region Game Parts Hardcoded
        private readonly IDictionary<int, GamePart> _gameParts = new Dictionary<int, GamePart>
        {
            { 1, new GamePart
            {
                Steps = new List<GameStepBase>
                {
                    new TextGameStep
                    {
                        PlaceInGamePart = 1,
                        Text = @"22 czerwca 1944 r. Armia Czerwona rozpoczęła ofensywę, która doprowadziła do przesunięcia linii frontu nad rzekę Wisłę. Na zajętych obszarach między Wisłą a Bugiem Sowieci oddawali administrację w ręce zależnego od siebie Polskiego Komitetu Wyzwolenia Narodowego (PKWN), który oficjalnie powstał w Lublinie 22 lipca 1944 r. PKWN i siły jemu podporządkowane przy wsparciu radzieckim rozpoczęły prześladowanie żołnierzy Armii Krajowej, oskarżając ich o faszyzm i współpracę z Niemcami. Były to oczywiste kłamstwa, ale AK, która podlegała prawowitemu rządowi polskiemu w Londynie, mogła być przeszkodą na drodze do sowietyzacji Polski."
                    },
                    new TaskGameStep
                    {
                        PlaceInGamePart = 2,
                        TaskText = @"Odnajdź na Rynku plakat szkalujący Armię Krajową i napisz na plakacie ""PPR = Płatne pachołki Rosji"". Następnie skontaktuj sie z Łącznikiem 1 który znajduje się w okolicach Rynku. Pokaż Łącznikowi fotografię potwierdzającą wykonanie zadania.",
                        Locations = new List<LocationMarker>
                        {
                            new LocationMarker
                            {
                                Latitude = 49.969337,
                                Longitude = 20.4281672,
                                Tooltip = "Rynek"
                            }
                        },
                        Password = @"Piękną mamy dziś pogodę.",
                        Reply = @"Rzeczywiście, ale od wschodu zbiera się na burzę."
                    }
                }
            } },
            { 2, new GamePart
            {
                Steps = new List<GameStepBase>
                {
                    new TextGameStep
                    {
                        PlaceInGamePart = 1,
                        Text = @"19 stycznia 1945 r. gen. Leopold ""Niedźwiadek"" Okulicki wydał rozkaz, w którym rozwiązał Armię Krajową. Powodem tej decyzji była chęć uchronienia żołnierzy AK przed represjami i prześladowaniami ze strony NKWD i aparatu bezpieczeństwa komunistycznej władzy. W rozkazie padły jednak stwierdzenia, że wojna się nie skończyła, bo nie przyniosła wolności i że żołnierze dalej powinni prowadzić swą pracę w celu odzyskania pełnej niepodległości."
                    },
                    new TaskGameStep
                    {
                        PlaceInGamePart = 2,
                        TaskText = @"Odszukaj pomnik gen. Okulickiego (plac Okulickiego) i uzupełnij fragment rozkazu otrzymanego od Łącznika 1. Uzupełniony rozkaz dostarcz do Łącznika 2, który znajduje sie na Plantach w okolicach SP 2. W razie wątpliwości dotyczących treści rozkazu należy ustnie wyjaśnić motywy podjetej przez gen. ""Niedźwiadka"" decyzji.",
                        Locations = new List<LocationMarker>
                        {
                            new LocationMarker
                            {
                                Latitude = 49.970215,
                                Longitude = 20.429653,
                                Tooltip = "Plac Okulickiego"
                            },
                            new LocationMarker
                            {
                                Latitude = 49.970531,
                                Longitude = 20.424583,
                                Tooltip = "SP 2"
                            }
                        },
                        Password = "Przepraszam, szukam krawca.",
                        Reply = "Dobrze się składa, mój stryjek ma sporo rzeczy z demobilu."
                    }
                }
            } }
        };
        #endregion
    }
}
