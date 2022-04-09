# CCManager - program do zarządzania siecią przychodni
Program przedstawia system do zarządzania siecią przychodni. Jest dużo możliwości oraz został zaimplementowany menadżer baz danych który ułatwi pierwsze kroki przy uruchomieniu aplikacji. Aplikacja napisana na podstawie wzorzca architektonicznego MVVM, gdzie View - to będa poszczególne kontrolki, w roli Model - będzie występował DAL (Data Access Layer) który będzie przedstawial dostęp do bazy danych a naszym "Mediator" będzie ViewModel który będzie pobierał dane z DAL'a i przedstawiał do View oraz naodwrót.

# Zastosowane technologie  
💿 C# 7.3
💿 Windows Forms
💿 Entity Framework 6.0  
💿 ADO.NET  
💿 Microsoft SQL Server  

# Uruchomienie programu
1. Należy uruchomić program
2. Wejść w menadżer baz danych
3. Wpisać nazwę serwera na jakim musi być wykreowana baza
4. Kliknąć wykreuj bazę **(domyślnie tworzone konto : admin-admin)**

# Menadżer bazy 
Pozwala automatycznie wykreować strukturę (tabele, widoki, triggery, procedury itd.) oraz wypełnia przykładowymi danymi. Proces tworzenia można śledzić za pomocą loggera  
![Screenshot_4](https://user-images.githubusercontent.com/19534189/146606103-83539124-72eb-43ac-bf83-a93b394a0457.png)  

# Przykładowa architektura 
![Screenshot_2](https://user-images.githubusercontent.com/19534189/146605093-cba9a71c-9d48-4c06-9407-08c9c1e68923.png)

# Działanie programu - dostępne encje
- Użytkownicy 
- Pacjenci
- Lekarze
- Przychodnie
- Leki
- Narzędzia
- Wizyty
- Zamówienia na leki
- Zamówienia na narzędzia
- Producenci
- Lokalizacje
- Dane osobowe
- Opinie
- Cenniki
- Operacje

# Screenshot
![Screenshot_1](https://user-images.githubusercontent.com/19534189/135512422-faef3145-6605-48f4-b22f-df0b39a00f02.png)
![Screenshot_7](https://user-images.githubusercontent.com/19534189/146606766-c60e250a-f89f-4390-b8c3-0e6e8c415ad4.png)





