# Triage-HCP

Triage-HCP to system do zarządzania pacjentami w Szpitalnym Oddziale Ratunkowym, który został uruchomiony i wdrożony
w połowie kwietnia 2023 roku w Centrum Medycznym HCP w Poznaniu. 
Celem programu jest skrócenie czasu oczekiwania na rozpoczęcie diagnostyki przez lekarza poprzez efektywne wykonywanie
czynności "triage" przez ratownika medycznego (czyli nadanie pacjentowi priorytetu), monitorowanie obsługi pacjenta
i generowanie dokumentacji medycznej w formie papierowej.

Główne funkcjonalności:
- Ratownik medyczny przeprowadza triaż pacjentów, przydzielając im priorytet pilności według schematu Triage Manchester.
- Pacjenci wyświetlają się na monitorach w poszczególnych gabinetach, salach intensywnego nadzoru i dyżurkach lekarskich
  Oddziału Ratunkowego.
- Lekarze przypisują sobie pacjentów i rozpoczynają diagnostykę.
- System informuje o przekroczeniu czasu oczekiwania na diagnostykę, poprzez migające kolory na monitorach.
- Po zakończonej obsłudze, pacjenci są wypisywani z systemu i ich dane przechodzą do archiwum.
- System generuje dokumentację medyczną dla każdego pacjenta, która jest drukowana, a po zakończonej obsłudze przechowywana
  w archiwum szpitalnym.

Technologie:
- Aplikacja została napisana w technologii ASP.NET Core MVC.
- Wykorzystuje Entity Framework Core i Microsoft SQL Server jako bazę danych.

Dzięki Triage-HCP personel medyczny może efektywnie zarządzać pacjentami, skracać czas oczekiwania na lekarza,
monitorować i analizować dane związane z obsługą pacjentów, a także generować dokumentację medyczną gotową do wydruku.
<hr/>

<h3>Chronologia zmian</h3>

Data: 29.03.2023, wersja 2.0.0

1. Wprowadzono możliwość wyboru lekarza z poziomu listy.
2. Utworzono nowy widok pod nazwą "CompletedList" i przeniesiono tam pacjentów z zakończoną obsługą w SOR.
3. Dodano możliwość wydrukowania karty wzmożonego nadzoru z poziomu szczegółów pacjenta.
4. Poprawiono widok strony tytułowej poprzez przesunięcie w dół o 100px kontenera z informacją o stronie.
5. Wyrównano do tej samej wysokości kontener logowania użytkownika, zmieniono okna formularzy na stylowanie z biblioteki Bootstrap.
6. Stworzono listę przykładowych lekarzy
7. Dla pacjentów koloru czerwonego i pomarańczowego bez przypisanego lekarza zastosowano animację w postaci mrugającej ramki, imienia, nazwiska i czasu wykonania triage. Dla pacjentów innych kolorów mruga tylko data i czas wykonania triage.
8. Usunięto możliwość przejścia do szczegółów pacjenta z listy łóżek. Rozszerzono wyświetlanie imienia i nazwizka pacjentów w sekcji korytarz, poczekalnia i dekontaminacja.
9. Poprawiono widok strony "Lista pacjentów".
10. Utworzono nowy widok "Przypisz lekarza" dla pacjentów bez przypisanego lekarza. Usunięto epikryzę i możliwość zakończenia obsługi jeśli brak wybranego lekarza.
<hr/>

Data: 30.03.2023

1. Wprowadzono walidację pól w forlumarzu TRIAGE.
2. Poprawiono wyświetlanie daty i czasu wykonania triage.
<hr/>

Data: 01.04.2023

1. Wprowadzono sortowanie (wyświetlanie) listy pacjentów według priorytetu pilności: najpierw pacjent kolor czerwony -> pomarańczowy -> żółty -> zielony -> niebieski.
2. Zabezpieczono możwiwość dodania nowego użytkownika blokując wyświetlanie formularzy rejestracji stylowaniem "display: none".
<hr/>

Data: 02.04.2023

1. Do strony Lista pacjentów dodano js skrypt odświeżający listę pacjentów co 60 sekund.
<hr/>

Data 04.04.2023

1. Dodano Kontroler Modify do modyfikacji i usuwania danych pacjentów.
2. Zmieniono nazwę widoku Edit na Details.
3. Usunięto widok do usuwania pacjentów z kontrolera Triage.
<hr/>

Data 05.04.2023

1. Usunięto błąd uniemożliwiający edycje danych dla pacjentów bez lekarza i zakończonych.
<hr/>

Data 06.04.2023

1. Utworzono nową bazę danych.
2. Dodano możliwość edycji danych o pacjencie z widoku listy łóżek.
3. Utworzono migrację nowych właściwości kolumn.
4. Dodano listę lekarzy.
<hr/>

Data 10.04.2023

1. Dla strony "Lista zakończonych" stworzono algorytm wyświetlający zakończonych pacjentów z aktualnego dyżuru.
2. Utworzono widok "Lista zakończonych" z aktualnego dyżuru.
3. Listę zakończonych pacjentów posortowano według daty malejąco.
4. Zaktualizowano listę lekarzy.
<hr/>

Data 11.04.2023

1. Do bazy danych dodano nową kolumnę "TriageDate" i uwzględniono ją w formularzu Triage.
2. Utworzono stronę "Statystyki"
<hr/>

Data 13.04.2023

1. Dodano nowego lekarza.
2. Opublikowano aplikacje na serwerze szpitala.
<hr/>

Data 16.04.2023

1. Usunięto wymagane minimum znaków przy nr PESEL i Objawach pacjenta, które powodowały błąd w późniejszej
	aktualizacji informacji o pacjencie.
2. Dodano wymóg określenia "Jakie decyzje?" w widoku "Szczegóły pacjenta" jeśli chcemy zatwierdzić zmiany.
<hr/>

Data 17.04.2023

1. Dodano możliwość wybrania opcji "Zgon? w zakładce "Jakie decyzje".
2. Wprowadzono wybór "Do kogo pacjent: INTERNISTA lub CHIRURG" dla ratownika w sekcji Triage.
<hr/>

Data 20.04.2023

1. Zlikwidowano błąd powodująy usuwanie informacji "Do kogo pacjent" po każdorazowej aktualizacji informacji o pacjencie.
2. Zmieniono lokalizację przycisku "DRUKUJ DOKUMENTY" dla widoków "Szczegóły" i "Przypisz lekarza".
3. Dodano możliwość zmiany "Do kogo pacjent" z widoku "Szczegóły".
4. Zmieniono kolejność wyświetlania danych na liście pacjentów (najpierw nazwisko, następnie imię).
<hr/>

Data 26.04.2023

1. Poprawiono widok strony Lista pacjentów.
2. Dodano liczniki określające ile jest pacjentów z danej kategorii.
3. Utworzono dodatkową kategorię: "Pacjenci z ustalonym przyjęciem ...".
4. Usunięto możliwość wartości null dla wartości Co dalej z Pacjentem.
5. Poprawiono czytelność Listy zakończonych grupując dane w kolumnach.
6. Przeniesiono odwoładnie do skryptu css na początek stron z listami pacjentów.
7. Poprawiono czytelność strony Lista pacjentów (zgrupowano informacje o pacjentach w trzech kolumnach).
<hr/>

Data 01.05.2023

1. Dodano nowego lekarza do systemu.
2. Poprawiono wyświetlanie przycisków nawigacyjnych.
<hr/>

Data 03.05.2023

1. Zmieniono wygląd i funkcjonalność stron Details i WithoutDoctor.
2. Dodano możliwość edycji danych pacjenta w nowym widoku EditPatientData.
3. Przeniesiono przycisk "Statystyki" do panelu na nawigacyjnego.
4. Dodano jasny gradient tagu "body".
<hr/>

Data 04.05.2023

1. Utworzono właściwość "EndTime" do modelu Pacjent.cs, w celu przechowywania informacji o dacie zakończenia obsługi w SOR.
2. Utworzono migrację "EndTime" i przeprowadzono update-database.
3. Poprawiono wygląd i funkcjonalność stron Details, WithoutDoctor i Done.
4. W liscie zakończonych pacjntów umieszczono informację o dacie zakończenia obsługi w SOR.
5. Poprawiono wygląd i funkcjonalność strony Index i Edit w kontrolerze MODIFY.
6. Usunięto błąd przy aktualizacji danych pacjenta z widoku WithoutDoctor.
<hr/>

Data 05.05.2023

1. Zwiększono czcionkę wyboru lekarza na stronie Lista pacjentów.
2. Dodano nr Id pacjenta w Liście zakończonych z poprzednich dyżurów.
3. Poprawiono wygląd i funkcjonalność stron Lista wszystkich pacjentów i Lista zakończonych.
4. Dodano licznik pokazujący ilość pacjentów od początku funkcjonowania programu.
<hr/>

Data 07.05.2023

1. Na stronie Lista pacjentów dodano funkcję, która z numeru PESEL wyciąga informacje o płci pacjenta i wyświetla ją na ekranie.
2. Usunięto konieczność wybierania płci w sekcji Triage.
<hr/>

Data 08.05.2023

1. Na stronach Details, Done, EditPatientData i WithoutDoctor wprowadzono algorytmy wyciągające wiek i płeć pacjenta z nr PESEL.
2. Wprowadzono animacje (mruganie danych pacjenta naprzemiennie czerowny - czarny) jeśli czas bez przypisanego lekarza
	przekroczy dopuszczalny czas dla danego koloru według systemu Triage Manchester.
3. Usunięto konieczność podawania wieku pacjenta w sekcji Triage.
<hr/>

Data 10.05.2023

1. Przeniesiono ConnectionString do pliku appsettings.json, który wyłączono ze śledzenia w repezytorium GitHib.
<hr/>

Data 13.05.2023

1. ConnectionString przeniesiono z powrotem do pliku Program.cs.
2. Na stronie Details zmieniono formatowanie zmiennej EndTime do formatu DD-MM-RRRR GG-MM.
<hr/>

Data 14.05.2023

1. Algorytmy, które pobierają wiek i płeć z numeru PESEL pacjenta uzupełniono o funckję zapisania tej informacji z bazie danych.
2. Na stronie WithoutDoctor wprowadzono licznik czasu oczekiwania na lekarza i animację według schematu Triage Manchester.
3. Zmienne DateTime sformatowano funkcją ToString("g").
<hr/>

Data 15.05.2023

1. Utworzono dwie nowe kolumny dla tabeli Patients: WaitingTime i TotalTime. Przeprowadzono migrację i update bazy danych.
2. Na stronie Details utworzono przycisk "Wypisz pacjenta"
<hr/>

Data 19.05.2023

1. Utworzono okno dialogowe (modal) na stronie Detailas, gdzie trzeba podać jaką podjęło się decyzje przy wypisaniu pacjenta.
2. Modal ze strony Details przesunięto na środek dzięki czemu poprawiono czytelność.
<hr/>
Data 22.05.2023

1. Usunięto możliwość edycji danych pacjenta z widoku WithoutDoctor, usunięto przycisk Drukuj dokumenty.
2. Poprawiono czytelność strony WithoutDoctor.
3. W liście zakończonych z dzisiejszego dyżuru i liście wszystkich pacjentów zmieniono kolejność wyświetlania -> najpierw nazwisko.
4. Usunięto błąd powodujący kasowanie informacj o czasie oczekiwania za lekarzem.
<hr/>

Data 23.05.2023

1. Z listy do kogo pacjent usunięto wybór ORTOPEDA i NEUROLOG.
2. Przyciski na stronie Details połączono w jedną grupę.
<h3> Opublikowano wersję 4.2.0. </h3>
<hr/>

Data 24.05.2023

1. Usunięto możliwość wypisania pacjenta bez określenia do jakiego lekarza pacjent należy.
2. Przy liście lóżek zastosotwano algorytm (animacja nazwiska i imienia) przypominający o przekroczonym czasie na rozpoczęcie
   diagnostyki dla danego pacjenta.
3. Odzielono poszczególne lokalizacje SOR znakiem lini.
<h3> Opublikowano wersję 4.3.0. </h3>
<hr/>

Data 13.05.2023

1. Dodano nowego lekarza do systemu.
<hr/>
Data 28.06.2023

1. Dodano nowych lekarzy do systemu.
2. Zmieniono akcję w kontrolerze "Triage", która przekierowuje do dokumentów pacjenta po zakończeniu czynności triage.
<h3> Opublikowano wersję 4.4.0. </h3>
<hr/>

Data 30.06.2023

1. W kontrolerze TriageController utworzono metody, które generują plik ".docx" z danymi pacjenta po wykonaniu czynności triage.
2. W widoku "Lista pacjentów" utworzono link, po którym następuje pobranie wygenerowanego dokumentu klikając na pacjenta bez przypisanego lekarza.
3. W widoku "Szczegóły pacjenta" utworzono odnośnik do pobrania dokumentów.
4. Usunięto widok "Pacjent bez lekarza".
<h3> Opublikowano wersję 5.0.0. </h3>
<hr/>

Data 01.07.2023

1. Dodano metodę DELETE dla kontrolera ModifyPatientData
2. Poprawiono formularz TRIAGE o pobranie aktualnego czasu do bazy danych w momencie wysłania formularza.
3. Zmieniono przekierowanie po wykonaniu triażu na stronę "Lista pacjentów".
4. Do modelu Pacjent dodano pola takie jak: alergie na leki, ciśnienie tętnicze, puls, saturacja, temperatura, skala GCS.
5. Stworzono odpowiednie pola w formularzu Triage, aby pobrać te dane.
6. Przeprowadzono migrację i aktualizację bazy danych o nowe pola.
<h3> Opublikowano wersję 5.1.0. </h3>
<hr/>

Data.02.07.2023

1. Usunięto błąd, który uniemożliwiał dostęp do dokumentów pacjenta z widoku "Details".
2. Usunięto błąd, który wymazywał parametry pacjenta po przypisaniu mu lekarza.
<hr/>

Data 05.07.2023

1. Do kontrolera EditController przywrócono metodę WithoutDoctor, która odpowiada z widok szczegółów pacjenta bez przypisanego lekarza.
2. W metodzie Triage zmieniono nazwę przekazywanego parametru z "body" na "pacjent".
3. Z widoku "Details" do kontrolera "EditController" przeniesiono logikę, która oblicza łączny czas przebywania pacjenta w SOR
   i zapisuje ten czas w bazie danych.
<hr/>

Data 06.07.2023

1. Zmieniono wygląd przycisków nawigacyjnych, dodano do nich ikony i tzw. tooltip-y.
2. Przycisk "WYLOGUJ" ma zmienioną nazwę na zalogowanego użytkownika z zachowaną funkcjonalnością tego przycisku.
3. Zmieniono metodę generowania dokumentacji pacjenta - jest gotowa do druku bezpośrednio po wykonaniu triażu.
4. Przywrócono widok "WithoutDoctor" dla pacjentów bez lekarza i dodano w nim możliwość drukowania dokumentów pacjenta.
5. W formularzu "Triage" określono jako wymagane wybranie "Do kogo pacjent".
<h3> Opublikowano wersję 5.2.0. </h3>
<hr/>

Data 08.07.2023

1. Zwiększono długość łańcucha znaków dla pola "BodyTemperature" o 1 znak, dzięki czemu można podać wartość po przecinku.
2. Utworzono klasę DocumentService, która dziedziczy po interfejsie IDocumentService. Przeniesiono do niej, z kontrolera 
   TriageController, metody: GeneratePatientDocument(), ReplaceKeywordsInDocx() i SetDocumentAsReadOnly().
3. Przeprowadzono refaktoryzację klasy TriageService i interfejsu ITriageService.
<hr/>

Data 09.07.2023

1. Zmieniono nazwę akcji "Triage" w kontrolerze TriageController na "AddNewPacjent" i zmieniono ją na metodę asynchroniczną.
2. Metodę GeneratePatientDocument() zmieniono na asynchroniczną.
3. PatientController zmieniono na ListsOfPatientsController, zmieniono nazwy widoków w tym kontrolerze.
4. Usunięto widok "Lista wszystkich pacjentów".
5. ConnectionString przeniesiono do pliku appsetings.json.
6. Stworzono wyszukiwarkę pacjentów. Utworzono SearchController, PatientSearchViewModel, ISearchPatientService i klasę
   SearchPatientService. Wyszukiwarkę pacjentów umieszczono po prawej stronie paska nawigacyjnego.
7. Poprawiono opisy z tzw. tooltip.
8. Metody, które uzyskują płeć i wiek z numeru pesel przeniesiono do osobnego serwisu - PeselService. Utworzono interfejs
   IPeselService i wstrzyknięto zależność do kontrolera TriageController.
9. Poprawiono kod w związku z ostrzeżeniami o możliwej wartości null.
<hr/>

Data 10.07.2023

1. Utworzono DocumentationControler i przeniesiono do niego metodę GeneratePatientDocument() z kontrolera TriageController
   zgodnie z zasadami SOLID (z zasadą pojedynczej odpowiedzialności i zasadą segregacji interfejsu).
2. W klasie PeselService utworzono metodę SetAgeAndGender(), która korzysta z algorytmów wyciągających wiek i płeć z nr pesel
   (IsPeselCorrect(), CalculateAge(), DetermineGender()) i przypisuje je do bazy danych dla konkretnego pacjenta.
3. W klasie TriageService utworzono metodę SetDefaultPatientFields(), która nowemu pacjentowi przypisuje domyślne wartości
   dla określonych pól.
<hr/>

Data 11.07.2023

<h3> Opublikowano wersję 5.3.0. </h3>
<hr/>

Data 12.07.2023

1. Utworzono klasę DeleteService w której zadeklarowano asynchroniczoną metodę DeletePatientAsync(). Utworzono interfejs 
   IDeleteServis i kontroler DeleteController, który odpowiada za usuwanie pacjentów z bazy danych
2. Utworzono klasę DetailsService z metodami: GetAsync(), UpdatePacjentAsync() i CalculateTotalPatientTime().
   Metody te są przekazywane za pośrednictwem interfejsu IDetailsService do kontrolera DetailsController.
3. Utworzono klasę ListService z asynchroniczną metodą GetAllAsync(), którą przekazuję za pośrednictwem interfejsu do
   kontrolera ListsOfPatientsController.
4. Usunięto ModifyPatientDataController.
5. Utworzono domyślny widok NotFound w katalogu Shared.
6. Zarejestrowano nowe serwisy w kontenerze wstrzykiwania zależności (Dependency Injection, DI) w klasie Program.cs.
7. Na stronie MainList zmieniono nazwy widoków z Edit na WithDoctor i WithoutDoctor.

<h3> Opublikowano wersję 5.4.0. </h3>
<hr/>

Data 13.07.2023

1. Przeniesiono bazę danych na lokalny serwer.
2. W widoku WithDoctor w sekcji "display: none" dodano formularze z parametrami pacjenta. Usunięto tym samym błąd, który powodował
   wyczyszczenie tych pól z bazy danych po wypisywaniu pacjenta z systemu.
3. Utworzono widoki Partial View do przesyłania ukrytych pól formularzy dla stron "Done", WithDoctor", "WithoutDoctor".
4. Listę lekarzy przeniesiono do Partial View jako DoctorsList.cshtml.
5. Listę lokalizacji w SOR przeniesiono do Partial View jako RoomList.cshtml.
6. Listę rozwijalną "Jaka decyzja?" przeniesiono do Partial View jako WhatDecision.cshtml.
7. Poprawiono wygląd i funkcjonalność formularza edycji danych pacjenta dla widoku "Admin".
<hr/>

Data 15.07.2023

1. Usunięto błąd ze strony WithDoctor, który polegał na błędnym odwoładniu to widoku ukrytych pól formularzy PartialView
   HiddenFormFields.cshtml.
2. Klasę Pacjent.cs zmieniono na Patient.cs.
3. W Klasie Patient.cs pole Id zmieniono na IdPacjenta, pole Room zmieniono na LocationId jako klucz obcy do tabeli Locations,
   pole Doctor zmieniono na DoctorId jako klucz obcy do tabeli Doctors.
4. Pole Diagnosis zmieniono na Symptoms, pole DateTime zmieniono na StartTime, string Active zmieniono na bool IsActive.
5. Usunięto pole Epikryza. Pole ObserwacjeRatPiel zmieniono na Remarks, pole CoDalejZPacjentem zmieniono na WhatNext.
6. Usunięto pole TriageDate.
7. Dla ciśnienia tętniczego, saturacji, tętna, temperatury i skali GCS pola te zmieniono ze string na int.
8. Utworzono klasę Location.cs, która będzie modelem do tabeli "Lokalizacja w Sor".
9. Utworzono klasę Doctor.cs, która będzie modelem do tabeli "Lekarze".
10. Poprawiono DetailsControler, TriageService, DocumentService, Admin.cshtml o zmienione pola z modelu Patient.
<h3>Utworzono nową gałąź - version 6.0.0</h3>
<hr/>

Data 16.07.2023

1. Poprawiono widok AdminList.cshtml, MainList.cshtml, Done.cshtml, Edit.cshtml, WithDoctor.cshtml, WithoutDoctor.cshtml
   o zmienione pola modelu Patient.
2. Ciąg dalszy poprawek: - poprawiono widok Statistics.cshtml, TodayEndList.cshtml, SearchPatients.cshtml,
   DoneFormFields.cshtml, EditFormFields.cshtml, HiddenFormFields.cshtml, AddNewPatient.cshtml.
3. Przeprowadzono migrację NewTables_Patients_Doctors_And_Locations i update testowej bazy danych.
4. Do klasy ListService dodano metodę GetAllDoctorsAsync(), która zwraca listę wszystkich lekarzy z tabeli "Doctors".
5. W widokach MainList.cshtml, WithDoctor.cshtml i WithoutDoctor.cshtml zastosowano listę lekarzy pobieraną z bazy danych.
6. Poprawiono wyświetlanie lekarza przy danym pacjencie z Id lekarza na jego imię i nazwisko.
<hr/>

Data 17.07.2023

1. W modelu Patient.cs umożliwiono, aby pola z parametrami jak ciśnienie, tętno, saturacja i skala GCS mogły być null,
   przeprowadzono migrację Patient_Parameters_Nullable i update bazy danych.
2. Do modelu Location.cs dodano pole bool IsAvailable, które będzie wskazywać czy dana lokalizacja jest dostępna.
3. Dodano logikę, która przypisuje wartość 'false' w polu IsAvailable w momencie położenia pacjenta na jakieś łóżko.
4. Zaimplementowano logikę, która zwalnia łóżko jeśli pacjent jest wypisany z SOR.
5. W widoku 'AddNewPatient.cshtml' dodano kolumnę, która wyświetla listę dostępnych łóżek.
6. W widoku 'MainList.cshtml' usunięto wartość null, która była przypisana do formularza wyboru lekarza i generowała błąd
   w momencie wybrania z listy opcji 'Wybierz lekarza ...'.
7. W kontrolerze TriageController utworzono metodę SetViewBagLocations(), która przekazuje aktualne łóżka do widoku
   AddNewPatient.cshtml.
8. Utworzono LocationServis, w którym są metody odpowiedzialne za generowanie listy dostępnych łóżek, przydzielanie
   pacjenta do danego łóżka i zwalniania go w momencie wypisania pacjenta.
9. W widok 'AddNewPatient.cshtml' listę dostępnych łóżek umieszczono w jednym kontenerze 'border shadow' z formularzami.