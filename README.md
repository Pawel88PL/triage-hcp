# triage-hcp

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

Data: 30.03.2023

1. Wprowadzono walidację pól w forlumarzu TRIAGE.
2. Poprawiono wyświetlanie daty i czasu wykonania triage.

Data: 01.04.2023

1. Wprowadzono sortowanie (wyświetlanie) listy pacjentów według priorytetu pilności: najpierw pacjent kolor czerwony -> pomarańczowy -> żółty -> zielony -> niebieski.
2. Zabezpieczono możwiwość dodania nowego użytkownika blokując wyświetlanie formularzy rejestracji stylowaniem "display: none".

Data: 02.04.2023

1. Do strony Lista pacjentów dodano js skrypt odświeżający listę pacjentów co 60 sekund.

Data 04.04.2023

1. Dodano Kontroler Modify do modyfikacji i usuwania danych pacjentów.
2. Zmieniono nazwę widoku Edit na Details.
3. Usunięto widok do usuwania pacjentów z kontrolera Triage.

Data 05.04.2023

1. Usunięto błąd uniemożliwiający edycje danych dla pacjentów bez lekarza i zakończonych.

Data 06.04.2023

1. Utworzono nową bazę danych.
2. Dodano możliwość edycji danych o pacjencie z widoku listy łóżek.
3. Utworzono migrację nowych właściwości kolumn.
4. Dodano listę lekarzy.

Data 10.04.2023

1. Dla strony "Lista zakończonych" stworzono algorytm wyświetlający zakończonych pacjentów z aktualnego dyżuru.
2. Utworzono widok "Lista zakończonych" z aktualnego dyżuru.
3. Listę zakończonych pacjentów posortowano według daty malejąco.
4. Zaktualizowano listę lekarzy.

Data 11.04.2023

1. Do bazy danych dodano nową kolumnę "TriageDate" i uwzględniono ją w formularzu Triage.
2. Utworzono stronę "Statystyki"

Data 13.04.2023

1. Dodano nowego lekarza.
2. Opublikowano aplikacje na serwerze szpitala.

Data 16.04.2023

1. Usunięto wymagane minimum znaków przy nr PESEL i Objawach pacjenta, które powodowały błąd w późniejszej
	aktualizacji informacji o pacjencie.
2. Dodano wymóg określenia "Jakie decyzje?" w widoku "Szczegóły pacjenta" jeśli chcemy zatwierdzić zmiany.

Data 17.04.2023

1. Dodano możliwość wybrania opcji "Zgon? w zakładce "Jakie decyzje".
2. Wprowadzono wybór "Do kogo pacjent: INTERNISTA lub CHIRURG" dla ratownika w sekcji Triage.

Data 20.04.2023

1. Zlikwidowano błąd powodująy usuwanie informacji "Do kogo pacjent" po każdorazowej aktualizacji informacji o pacjencie.
2. Zmieniono lokalizację przycisku "DRUKUJ DOKUMENTY" dla widoków "Szczegóły" i "Przypisz lekarza".
3. Dodano możliwość zmiany "Do kogo pacjent" z widoku "Szczegóły".
4. Zmieniono kolejność wyświetlania danych na liście pacjentów (najpierw nazwisko, następnie imię).

Data 26.04.2023

1. Poprawiono widok strony Lista pacjentów.
2. Dodano liczniki określające ile jest pacjentów z danej kategorii.
3. Utworzono dodatkową kategorię: "Pacjenci z ustalonym przyjęciem ...".
4. Usunięto możliwość wartości null dla wartości Co dalej z Pacjentem.
5. Poprawiono czytelność Listy zakończonych grupując dane w kolumnach.
6. Przeniesiono odwoładnie do skryptu css na początek stron z listami pacjentów.
7. Poprawiono czytelność strony Lista pacjentów (zgrupowano informacje o pacjentach w trzech kolumnach).

Data 01.05.2023

1. Dodano nowego lekarza do systemu.
2. Poprawiono wyświetlanie przycisków nawigacyjnych.

Data 03.05.2023

1. Zmieniono wygląd i funkcjonalność stron Details i WithoutDoctor.
2. Dodano możliwość edycji danych pacjenta w nowym widoku EditPatientData.
3. Przeniesiono przycisk "Statystyki" do panelu na nawigacyjnego.
4. Dodano jasny gradient tagu "body".

Data 04.05.2023

1. Utworzono właściwość "EndTime" do modelu Pacjent.cs, w celu przechowywania informacji o dacie zakończenia obsługi w SOR.
2. Utworzono migrację "EndTime" i przeprowadzono update-database.
3. Poprawiono wygląd i funkcjonalność stron Details, WithoutDoctor i Done.
4. W liscie zakończonych pacjntów umieszczono informację o dacie zakończenia obsługi w SOR.
5. Poprawiono wygląd i funkcjonalność strony Index i Edit w kontrolerze MODIFY.
6. Usunięto błąd przy aktualizacji danych pacjenta z widoku WithoutDoctor.

Data 05.05.2023

1. Zwiększono czcionkę wyboru lekarza na stronie Lista pacjentów.
2. Dodano nr Id pacjenta w Liście zakończonych z poprzednich dyżurów.
3. Poprawiono wygląd i funkcjonalność stron Lista wszystkich pacjentów i Lista zakończonych.
4. Dodano licznik pokazujący ilość pacjentów od początku funkcjonowania programu.

Data 07.05.2023

1. Na stronie Lista pacjentów dodano funkcję, która z numeru PESEL wyciąga informacje o płci pacjenta i wyświetla ją na ekranie.
2. Usunięto konieczność wybierania płci w sekcji Triage.

Data 08.05.2023

1. Na stronach Details, Done, EditPatientData i WithoutDoctor wprowadzono algorytmy wyciągające wiek i płeć pacjenta z nr PESEL.
2. Wprowadzono animacje (mruganie danych pacjenta naprzemiennie czerowny - czarny) jeśli czas bez przypisanego lekarza
	przekroczy dopuszczalny czas dla danego koloru według systemu Triage Manchester.
3. Usunięto konieczność podawania wieku pacjenta w sekcji Triage.

Data 10.05.2023

1. Przeniesiono ConnectionString do pliku appsettings.json, który wyłączono ze śledzenia w repezytorium GitHib.

Data 13.05.2023

1. ConnectionString przeniesiono z powrotem do pliku Program.cs.
2. Na stronie Details zmieniono formatowanie zmiennej EndTime do formatu DD-MM-RRRR GG-MM.

Data 14.05.2023

1. Algorytmy, które pobierają wiek i płeć z numeru PESEL pacjenta uzupełniono o funckję zapisania tej informacji z bazie danych.
2. Na stronie WithoutDoctor wprowadzono licznik czasu oczekiwania na lekarza i animację według schematu Triage Manchester.
3. Zmienne DateTime sformatowano funkcją ToString("g").

Data 15.05.2023

1. Utworzono dwie nowe kolumny dla tabeli Patients: WaitingTime i TotalTime. Przeprowadzono migrację i update bazy danych.
2. Na stronie Details utworzono przycisk "Wypisz pacjenta"

Data 19.05.2023

1. Utworzono okno dialogowe (modal) na stronie Detailas, gdzie trzeba podać jaką podjęło się decyzje przy wypisaniu pacjenta.
2. Modal ze strony Details przesunięto na środek dzięki czemu poprawiono czytelność.

Data 22.05.2023

1. Usunięto możliwość edycji danych pacjenta z widoku WithoutDoctor, usunięto przycisk Drukuj dokumenty.
2. Poprawiono czytelność strony WithoutDoctor.
3. W liście zakończonych z dzisiejszego dyżuru i liście wszystkich pacjentów zmieniono kolejność wyświetlania -> najpierw nazwisko.
4. Usunięto błąd powodujący kasowanie informacj o czasie oczekiwania za lekarzem.

Data 23.05.2023

1. Z listy do kogo pacjent usunięto wybór ORTOPEDA i NEUROLOG.
2. Przyciski na stronie Details połączono w jedną grupę.
<h3> Opublikowano wersję 4.2.0. </h3>

Data 24.05.2023

1. Usunięto możliwość wypisania pacjenta bez określenia do jakiego lekarza pacjent należy.
2. Przy liście lóżek zastosotwano algorytm (animacja nazwiska i imienia) przypominający o przekroczonym czasie na rozpoczęcie
   diagnostyki dla danego pacjenta.
3. Odzielono poszczególne lokalizacje SOR znakiem lini.
<h3> Opublikowano wersję 4.3.0. </h3>

Data 13.05.2023

1. Dodano nowego lekarza do systemu.

Data 28.06.2023

1. Dodano nowych lekarzy do systemu.
2. Zmieniono akcję w kontrolerze "Triage", która przekierowuje do dokumentów pacjenta po zakończeniu czynności triage.
<h3> Opublikowano wersję 4.4.0. </h3>

Data 30.06.2023

1. W kontrolerze TriageController utworzono metody, które generują plik ".docx" z danymi pacjenta po wykonaniu czynności triage.
2. W widoku "Lista pacjentów" utworzono link, po którym następuje pobranie wygenerowanego dokumentu klikając na pacjenta bez przypisanego lekarza.
3. W widoku "Szczegóły pacjenta" utworzono odnośnik do pobrania dokumentów.
4. Usunięto widok "Pacjent bez lekarza".
<h3> Opublikowano wersję 5.0.0. </h3>

Data 01.07.2023

1. Dodano metodę DELETE dla kontrolera ModifyPatientData
2. Poprawiono formularz TRIAGE o pobranie aktualnego czasu do bazy danych w momencie wysłania formularza.
3. Zmieniono przekierowanie po wykonaniu triażu na stronę "Lista pacjentów".
4. Do modelu Pacjent dodano pola takie jak: alergie na leki, ciśnienie tętnicze, puls, saturacja, temperatura, skala GCS.
5. Stworzono odpowiednie pola w formularzu Triage, aby pobrać te dane.