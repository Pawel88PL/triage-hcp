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

3. Dodano funkcję wyświetlającą widok "Triage" w nowym oknie.