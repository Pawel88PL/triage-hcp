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