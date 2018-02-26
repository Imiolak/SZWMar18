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
            {
                1, new GamePart
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
                                    Latitude = 49.9692934,
                                    Longitude = 20.4282733,
                                    Tooltip = "Rynek"
                                }
                            },
                            Password = @"Piękną mamy dziś pogodę.",
                            Reply = @"Rzeczywiście, ale od wschodu zbiera się na burzę."
                        }
                    }
                }
            },
            {
                2, new GamePart
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
                }
            },
            {
                3, new GamePart
                {
                    Steps = new List<GameStepBase>
                    {
                        new TextGameStep
                        {
                            PlaceInGamePart = 1,
                            Text = @"20 stycznia 1945 r. Niemcy wycofali się z Bochni, a kolejnego dnia do miasta wkroczyły pierwsze oddziały sowieckie. Początkowo mieszkańcom Bochni mogło sie wydawać, że oznacza to wyzwolenie."
                        },
                        new TaskGameStep
                        {
                            PlaceInGamePart = 2,
                            TaskText = @"Odszukaj na cmentarzu przy ul. Orackiej zbiorową mogiłę żołnierzy radzieckich i przepisz napis umieszczony na pomniku. Następnie nawiąż kontakt z Łącznikiem 3, który znajduje się w okolicach dworca kolejowego.",
                            Locations = new List<LocationMarker>
                            {
                                new LocationMarker
                                {
                                    Latitude = 49.973407,
                                    Longitude = 20.425047,
                                    Tooltip = "Cmentarz"
                                },
                                new LocationMarker
                                {
                                    Latitude = 49.977112,
                                    Longitude = 20.431333,
                                    Tooltip = "Dworzec Kolejowy"
                                }
                            },
                            Password = @"Przepraszam, nie wie pani gdzie mógłbym zjeść pierogi?",
                            Reply = @"Naprzeciwko, ale nie polecam bo tam mają tylko ruskie."
                        }
                    }
                }
            },
            {
                4, new GamePart
                {
                    Steps = new List<GameStepBase>
                    {
                        new TextGameStep
                        {
                            PlaceInGamePart = 1,
                            Text = @"Po wkroczeniu Armii Czerwonej do Bochni radzieccy żołnierze zachowywali się tak, jak gdyby znajdowali sie na terytorium wroga. W Bochni mnożyły się napady, grabieże i samowole dokonywane przez radzieckich sołdatów. 31 sierpnia 1945 r. radzieccy żołnierze zastrzelili w pobliżu stacji Kłaj dwóch pasażerów pociągu jadącego do Krakowa, we wrześniu 1945 r. spowodowali groźny pożar na posesji przy ul. Wiśnickiej w Bochni, zdewastowali też koszary przy ul. Kazimierza Wielkiego. Jedną z ofiar „wyzwolicieli” był też znany bocheński malarz Marcin Samlicki.
Zachowanie Armii Czerwonej i przyniesienie przez nią na bagnetach nowej komunistycznej władzy budziło oczywiście chęć oporu. Po rozwiązaniu AK główną organizacją podziemia stało się Zrzeszenie Wolność i Niezawisłość (WIN) utworzone w Warszawie 2 września 1945 r. Celem organizacji, która stawiała początkowo na polityczne metody działania, było odsunięcie komunistów od władzy i zerwanie z zależnością Polski od ZSRR. Kierownictwo WIN-u liczyło na szybki wybuch III wojny światowej, która po pokonaniu ZSRR przez USA miała przynieść Polsce wymarzoną wolność.
Jednym z członków kierownictwa WIN-u był były mieszkaniec Bochni, nauczyciel bocheńskiego gimnazjum, a przede wszystkim wybitny pływak z okresu 20-lecia międzywojennego - Jan Kot. Kot odpowiadał w WIN-ie za zbieranie informacji wywiadowczych i to w dużej mierze w wyniku jego oraz jego podwładnych pracy powstał ""Memoriał polskiego ruchu oporu do Rady Bezpieczeństwa ONZ"" zawierający informacje o zbrodniach popełnianych przed ZSRR i polskich komunistów na Polakach. W sierpniu 1946 r. Jan Kot został aresztowany w Krakowie i po ciężkim śledztwie, w czasie którego był torturowany, został skazany na trzykrotną karę śmierci, którą zamieniono później na dożywotnie więzienie. W marcu 1957 r. po amnestii spowodowanej tzw. przełomem październikowym Kot odzyskał wolność, jednak bezpieka interesowała się nim jeszcze przez długie lata."
                        },
                        new TaskGameStep
                        {
                            PlaceInGamePart = 2,
                            TaskText = @"Udaj się do Krytej Pływalni w Bochni i odnajdź na tablicy poświęconej Janowi Kotowi informację dotyczącą miejsc, w których więziony był Kot. Na podstawie informacji od Łącznika 3 napisz raport (i podpisz kryptonimem drużyny) na temat wydarzeń, które rozegrały się 31 sieprnia 1945 r. na trasie kolejowej między Bochnią a Kłajem. Skontaktować się z Łącznikiem 4, który znajduje się w okolicach Krytej Pływalni. Przekaż mu sporządzony raport oraz pieniądze na działalność konspiracyjną.",
                            Locations = new List<LocationMarker>
                            {
                                new LocationMarker
                                {
                                    Latitude = 49.976425,
                                    Longitude = 20.433853,
                                    Tooltip = @"Basen"
                                }
                            },
                            Password = @"Przepraszam, która godzina?",
                            Reply = @"Niestety nie mam zegarka od stycznia obecnego roku."
                        }
                    }
                }
            },
            {
                5, new GamePart
                {
                    Steps = new List<GameStepBase>
                    {
                        new TaskGameStep
                        {
                            PlaceInGamePart = 1,
                            TaskText = @"Od Łącznika 4 odbierz ""Memoriał polskiego ruchu oporu do Rady Bezpieczeństwa ONZ"". Po dalsze instrukcje zgłoś się do Łącznika 5, który znajduje się przy skrzyżowaniu ulic: Solna Góra i Niecała.",
                            Locations = new List<LocationMarker>
                            {
                                new LocationMarker
                                {
                                    Latitude = 49.972147,
                                    Longitude = 20.430147,
                                    Tooltip = @"Solna Góra x Niecała"
                                }
                            },
                            Password = @"Przepraszam, skąd odjeżdża pociąg do Krakowa?",
                            Reply = @"Dziś prędzej to można pojechać do Moskwy."
                        }
                    }
                }
            },
            {
                6, new GamePart
                {
                    Steps = new List<GameStepBase>
                    {
                        new TextGameStep
                        {
                            PlaceInGamePart = 1,
                            Text = @"W lutym 1946 r. powstały w Bochni pierwsze struktury WiN-u. Jego twórcą był zatrudniony w bocheńskich zakładach naczyń kamionkowych na stanowisku buchaltera Feliks ""Lis"" Kornaś. Głównym zadaniem organizacji było zdobywanie informacji o działaniach komunistów oraz udzielanie pomocy PSL w przygotowaniach do referendum ludowego, a później wyborów. Pod koniec 1946 r. działania bocheńskich winowców zamarły, a Lis w 1948 r. przeniósł sie do Wrocławia. W sierpniu 1948 r. Kornaś został aresztowany i po brutalnym śledztwie skazany w 1949 r. na karę 8 lat pozbawienia wolności. W 1956 r. na mocy amnestii niewielka część kary została Lisowi darowana i odzyskal wolność. Bocheńskie komórki WiN-u podlegały bezpośrednio dowództwu w Krakowie, które co najmniej dwa razy dokonało wizyty w Bochni."
                        },
                        new TaskGameStep
                        {
                            PlaceInGamePart = 2,
                            TaskText = @"Udaj się do budynku drukarni przy ul. Konstytucji 3 Maja. W budynku weź udział w wizytacji i odprawie, którą przeprowadzi Łącznik 6. Łacznikowi 6 przekazać ""Memoriał polskiego ruchu oporu do Rady Bezpieczeństwa ONZ"".",
                            Locations = new List<LocationMarker>
                            {
                                new LocationMarker
                                {
                                    Latitude = 49.972747,
                                    Longitude = 20.427785,
                                    Tooltip = @"Drukarnia"
                                }
                            },
                            Password = @"Przepraszam, szukam szewca.",
                            Reply = @"Dobrze się składa, mój stryjek naprawia buty."
                        }
                    }
                }
            },
            {
                7, new GamePart
                {
                    Steps = new List<GameStepBase>
                    {
                        new TaskGameStep
                        {
                            PlaceInGamePart = 1,
                            TaskText = @"Zapal znicze na grobach Jana Kota i Feliksa Kornasia na cmentarzu przy ul. Orackiej. Zapalenie zniczy udokumentuj fotografią. Następnie wróć do budynku ZS nr 1 w Bochni.",
                            Locations = new List<LocationMarker>
                            {
                                new LocationMarker
                                {
                                    Latitude = 49.973407,
                                    Longitude = 20.425047,
                                    Tooltip = "Cmentarz"
                                },
                                new LocationMarker
                                {
                                    Latitude = 49.9666957,
                                    Longitude = 20.4165351,
                                    Tooltip = @"ZS 1"
                                }
                            }
                        }
                    }
                }
            }
        };
        #endregion
    }
}
